using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    class TypeWalker : TreeWalker
    {

        SymbolTable symtable = new SymbolTable();

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
            var vi = new VarInfo(new VTypeInt(), n.children[1].token.line);
            symtable[vname] = vi;
        }
        void declDouble(TreeNode n)
        {
            string vname = n.children[1].token.lexeme;
            var vi = new VarInfo(new VTypeDouble(), n.children[1].token.line);
            symtable[vname] = vi;
        }
        void declString(TreeNode n)
        {
            string vname = n.children[1].token.lexeme;
            int capacity = Int32.Parse(n.children[0].children[2].token.lexeme);
            var vi = new VarInfo(new VTypeStringV(capacity),
                                    n.children[1].token.line);
            symtable[vname] = vi;
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
        }
        public override void leave_num(TreeNode n)
        {
            n.type = VType.INT;
        }
        public override void leave_while(TreeNode n)
        {
            typeCheck(n, 2, VType.INT);
        }
        public override void leave_if(TreeNode n)
        {
            typeCheck(n, 2, VType.INT);
        }
        public override void leave_ifelse(TreeNode n)
        {
            typeCheck(n, 2, VType.INT);
        }
        public override void leave_fnum(TreeNode n)
        {
            n.type = VType.DOUBLE;
        }
        public override void leave_str(TreeNode n)
        {
            n.type = new VTypeStringC();
        }
        public override void leave_copyType(TreeNode n)
        {
            n.type = n.children[0].type;
        }
        public override void leave_expr(TreeNode n)
        {
            n.type = n.children[1].type;
        }
        
        public override void leave_andexp(TreeNode n)
        {
            typeCheck(n, 0, 2, VType.INT, VType.INT);
        }
        public override void leave_orexp(TreeNode n)
        {
            typeCheck(n, 0, 2, VType.INT, VType.INT);
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

    }

}
