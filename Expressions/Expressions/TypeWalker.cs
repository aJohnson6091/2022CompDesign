using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
    class TypeWalker : TreeWalker
    {
        RegisterManager registerManager = new RegisterManager();
        SymbolTable symtable = new SymbolTable();
        int lblCounter = 0;
        string label()
        {
            string tmp = "lbl" + lblCounter;
            lblCounter++;
            return tmp;
        }

        void typeCheck(TreeNode n, int[] chidx, params VType[] allowed)
        {
            TreeNode c0 = n.children[chidx[0]];
            foreach (int i in chidx)
            {
                TreeNode c = n.children[i];
                if (!Array.Exists(allowed, t => t == c.type))
                {
                    throw new Exception("Child is disallowed Type");
                }

                if (c0.type != c.type)
                {
                    throw new Exception("Mismatched Types");
                }

            }
            n.type = c0.type;
        }
        void typeCheck(TreeNode n, int i0, params VType[] allowed)
        {
            typeCheck(n, new int[] { i0 }, allowed);
        }
        void typeCheck(TreeNode n, int i0, int i1, params VType[] allowed)
        {
            typeCheck(n, new int[] { i0, i1 }, allowed);
        }


        void declInt(TreeNode n)
        {
            string vname = n.children[1].token.lexeme;
            var vi = new VarInfo(new VTypeInt(), n.children[1].token.line,null);
            symtable[vname] = vi;
        }
        void declDouble(TreeNode n)
        {
            string vname = n.children[1].token.lexeme;
            var vi = new VarInfo(new VTypeDouble(), n.children[1].token.line, null);
            symtable[vname] = vi;
        }
        void declString(TreeNode n)
        {
            string vname = n.children[1].token.lexeme;
            int capacity = Int32.Parse(n.children[0].children[2].token.lexeme);
            var vi = new VarInfo(new VTypeStringV(capacity),n.children[1].token.line, null);
            symtable[vname] = vi;
        }

        void binaryOpInt(TreeNode n, int c1idx, int c2idx, string op)
        {
            var loc1 = n.children[c1idx].resultLocation;
            var loc2 = n.children[c2idx].resultLocation;
            n.code = new ASM(
                n.children[c1idx].code,
                n.children[c2idx].code,
                $"{op} {loc1} , {loc2}"
            );
            n.resultLocation = loc1;
            registerManager.release(loc2);
            n.type = VType.INT;
        }

        public override void leave_vardecl(TreeNode n)
        {
            //vardecl :: type ID optsize SEMI
            switch (n.children[0].children[0].token.sym)
            {
                case "INT":
                    declInt(n); break;
                case "DOUBLE":
                    declDouble(n); break;
                case "STRING":
                    declString(n); break;
                default:
                    throw new Exception("Internal Compiler Error");     //internal compiler error: Not implemented
    }
        }
        public override void enter_bblock(TreeNode n)
        {
            symtable.addScope();
        }

        public override void leave_bblock(TreeNode n)
        {
            symtable.removeScope();
        }
        public override void leave_castint(TreeNode n)
        {
            //cast :: INT LP expr RP
            typeCheck(n, 2, VType.INT, VType.DOUBLE);
            n.type = VType.INT;
        }
        public override void leave_castdouble(TreeNode n)
        {
            //cast :: INT LP expr RP
            typeCheck(n, 2, VType.DOUBLE, VType.INT);
            n.type = VType.DOUBLE;
        }
        public override void leave_sum(TreeNode n)
        {
            typeCheck(n, 0, 2, VType.INT, VType.DOUBLE);
            VType t1 = n.children[0].type;
            VType t2 = n.children[2].type;
            if (t1 == VType.DOUBLE || t2 == VType.DOUBLE)
                n.type = VType.DOUBLE;
            else if (t1 == VType.INT || t2 == VType.INT )
                n.type = VType.INT;
            else
                throw new Exception("Leave Sum Exception");
            if (n.children[0].type == VType.INT)
            {
                switch (n.children[1].text)
                {
                    case "+":
                        binaryOpInt(n, 0, 2, "add");
                        break;
                    case "-":
                        binaryOpInt(n, 0, 2, "sub");
                        break;
                    default:
                        throw new Exception("Incorrect Binary Operation");
                        return;
                }
            }
            else
            {
                throw new Exception("No Float integration");         //not yet implemented for floats
            }
        }
        public override void leave_product(TreeNode n)
        {
            typeCheck(n, 0, 2, VType.INT, VType.DOUBLE);
            VType t1 = n.children[0].type;
            VType t2 = n.children[2].type;
            if (t1 == VType.DOUBLE || t2 == VType.DOUBLE)
                n.type = VType.DOUBLE;
            else if (t1 == VType.INT || t2 == VType.INT)
                n.type = VType.INT;
            else
                throw new Exception("Leave Sum Exception");
            if (n.children[0].type == VType.INT)
            {
                switch (n.children[1].text)
                {
                    case "+":
                        binaryOpInt(n, 0, 2, "mul");
                        break;
                    case "-":
                        binaryOpInt(n, 0, 2, "div");
                        break;
                    default:
                        throw new Exception("Incorrect Binary Operation");
                        return;
                }
            }
            else
            {
                throw new Exception("No Float integration");         //not yet implemented for floats
            }
        }
        public override void leave_num(TreeNode n)
        {
            n.type = VType.INT;
            var d = Int64.Parse(n.text);
            var loc = registerManager.allocateInt();
            n.code = new ASM($"mov {loc}, {d}");
            n.resultLocation = loc;
        }
        public override void leave_fnum(TreeNode n)
        {
            n.type = VType.DOUBLE;
            var d = Double.Parse(n.text);
            string ds = d.ToString();

            //nasm insists float constants must have . or E in them
            if (ds.IndexOf(".") == -1 && ds.IndexOf("E") == -1)
                ds += ".0";

            n.code = new ASM(
                $"mov rax, __float64__({ds})",
                "movq xmm0,rax"
            );
        }

        public override void leave_while(TreeNode n)
        {
            typeCheck(n, 2, VType.INT);
            string startWhile = label();
            string endWhile = label();
            n.code = new ASM(
                n.children[2].code,       //expr
                $"{startWhile}:",
                "cmp rax,0",        //Check if we want to execute brace block
                $"je {endWhile}",
                n.children[4].code,//braceBlock
                "jmp startWhile", //return to top
                $"{endWhile}:"
            );
        }
        public override void walk_if(TreeNode n)
        {
            //cond :: IF LP expr RP braceBlock  @if

            //do any callbacks for enter_XXX
            walkEnter(n);

            //handle expr node
            walk(n.children[2]);

            //type checking
            typeCheck(n, 2, VType.INT);

            //restore register for body of if block so
            //braceBlock can re-use it
            registerManager.release(n.children[2].resultLocation);

            //"if-true" code
            walk(n.children[4]);

            string endif = label();

            n.code = new ASM(
                n.children[2].code,       //expr
                $"cmp {n.children[2].resultLocation},0",
                $"je {endif}",
                n.children[4].code,       //braceBlock
                $"{endif}:"
            );

            //do callbacks for leave_XXX
            walkLeave(n);
        }
        public override void leave_if(TreeNode n)
        {
            typeCheck(n, 2, VType.INT);
            string endif = label();
            n.code = new ASM(
                n.children[2].code,       //expr
                $"cmp qword {n.children[2].resultLocation}, 0",
                $"je {endif}",
                n.children[4].code,       //braceBlock
                $"{endif}:"
            );
            availReg.Push(n.children[2].resultLocation);
        }
        public override void leave_ifelse(TreeNode n)
        {
            typeCheck(n, 2, VType.INT);
            string elseLabel = label();
            n.code = new ASM(
                n.children[2].code,       //expr
                "cmp rax,0",
                $"je {elseLabel}",
                n.children[4].code,       //braceBlock
                $"{elseLabel}:,",
                n.children[6].code
            );
        }
       
        public override void leave_str(TreeNode n)
        {
            n.type = new VTypeStringC();
        }
        public override void leave_copyType(TreeNode n)
        {
            n.type = n.children[0].type;
            n.resultLocation = n.children[0].resultLocation;
        }
        public override void leave_expr(TreeNode n)
        {
            n.type = n.children[1].type;
        }
        
        public override void leave_andexp(TreeNode n)
        {
            typeCheck(n, 0, 2, VType.INT, VType.INT);
            if (n.children[0].type == VType.INT)
            {
                switch (n.children[1].text)
                {
                    case "+":
                        binaryOpInt(n, 0, 2, "and");
                        break;
                    default:
                        throw new Exception("Incorrect Binary Operation");
                        return;
                }
            }
            else
            {
                throw new Exception("No Float integration");         //not yet implemented for floats
            }
        }
        public override void leave_orexp(TreeNode n)
        {
            typeCheck(n, 0, 2, VType.INT, VType.INT);
            if (n.children[0].type == VType.INT)
            {
                switch (n.children[1].text)
                {
                    case "+":
                        binaryOpInt(n, 0, 2, "or");
                        break;
                    default:
                        throw new Exception("Incorrect Binary Operation");
                        return;
                }
            }
            else
            {
                throw new Exception("No Float integration");         //not yet implemented for floats
            }

        }
        public override void leave_notexp(TreeNode n)
        {
            typeCheck(n, 1, VType.INT);
        }
        public override void leave_bitexp(TreeNode n)
        {
            typeCheck(n, 0, 2, VType.INT, VType.INT);
        }
        public override void leave_relexp(TreeNode n)
        {
            typeCheck(n, 0, 2, VType.INT, VType.DOUBLE, VType.STRING);
        }
        public override void leave_bitnot(TreeNode n)
        {
            typeCheck(n, 1, VType.INT);
        }
        public override void leave_plus(TreeNode n)
        {
            typeCheck(n, 1, VType.INT,VType.DOUBLE);
        }
        public override void leave_id(TreeNode n)
        {
            string vname = n.children[0].token.lexeme;
            n.type = symtable[vname].type;
        }
        public override void leave_assign(TreeNode n)
        {
            string vname = n.children[0].token.lexeme;
            if(symtable[vname] == null || !symtable[vname].type.Equals(n.children[3].type))
            {
                throw new Exception("Mismatch assignment");
            }
        }

        public override void leave_returnvoid(TreeNode n)
        {
            n.code = new ASM("ret");
        }
        public override void leave_returnexpr(TreeNode n)
        {
            n.code = new ASM(n.children[1].code, "ret");
        }

        public override void leave_funcdecl(TreeNode n)
        {
            //funcdecl::type ID LP paramlist RP braceBlock
            string name = n.children[1].text;
            string lbl = label();
            symtable[name] = new VarInfo(new VTypeFunction(),
                n.line, new FunctionLocation(lbl));
            n.code = new ASM(
                lbl + ":",
                n.children[5].code,
                "ret");
        }

    }

}
