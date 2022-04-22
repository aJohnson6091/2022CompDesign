// this file is auto-generated. Do not edit.

using System.Collections.Generic;

namespace Expressions
{
    public class TreeWalker
    {
        public void walkEnter(TreeNode n)
        {
            enter(n);
            switch (n.sym)
            {
                case "S": enterNonterminal_S(n); break;
                case "addexp": enterNonterminal_addexp(n); break;
                case "andexp": enterNonterminal_andexp(n); break;
                case "assign": enterNonterminal_assign(n); break;
                case "bitexp": enterNonterminal_bitexp(n); break;
                case "braceBlock": enterNonterminal_braceBlock(n); break;
                case "calllist": enterNonterminal_calllist(n); break;
                case "calllist2": enterNonterminal_calllist2(n); break;
                case "cast": enterNonterminal_cast(n); break;
                case "cond": enterNonterminal_cond(n); break;
                case "decl": enterNonterminal_decl(n); break;
                case "expr": enterNonterminal_expr(n); break;
                case "factor": enterNonterminal_factor(n); break;
                case "funccall": enterNonterminal_funccall(n); break;
                case "funcdecl": enterNonterminal_funcdecl(n); break;
                case "itemsel": enterNonterminal_itemsel(n); break;
                case "mulexp": enterNonterminal_mulexp(n); break;
                case "notexp": enterNonterminal_notexp(n); break;
                case "optsize": enterNonterminal_optsize(n); break;
                case "orexp": enterNonterminal_orexp(n); break;
                case "param": enterNonterminal_param(n); break;
                case "paramlist": enterNonterminal_paramlist(n); break;
                case "paramlist2": enterNonterminal_paramlist2(n); break;
                case "postfix": enterNonterminal_postfix(n); break;
                case "relexp": enterNonterminal_relexp(n); break;
                case "return": enterNonterminal_return(n); break;
                case "stmt": enterNonterminal_stmt(n); break;
                case "stmts": enterNonterminal_stmts(n); break;
                case "structdecl": enterNonterminal_structdecl(n); break;
                case "type": enterNonterminal_type(n); break;
                case "unaryexp": enterNonterminal_unaryexp(n); break;
                case "vardecl": enterNonterminal_vardecl(n); break;
                case "vardecls": enterNonterminal_vardecls(n); break;
                case "whileExpr": enterNonterminal_whileExpr(n); break;
            }
            foreach (var sym in n.labels)
            {
                switch (sym)
                {
                    case "andexp": enter_andexp(n); break;
                    case "array": enter_array(n); break;
                    case "arraysel": enter_arraysel(n); break;
                    case "assign": enter_assign(n); break;
                    case "bblock": enter_bblock(n); break;
                    case "bitexp": enter_bitexp(n); break;
                    case "bitnot": enter_bitnot(n); break;
                    case "castdouble": enter_castdouble(n); break;
                    case "castint": enter_castint(n); break;
                    case "castvec2": enter_castvec2(n); break;
                    case "char": enter_char(n); break;
                    case "copyType": enter_copyType(n); break;
                    case "expr": enter_expr(n); break;
                    case "fcall": enter_fcall(n); break;
                    case "fcallsel": enter_fcallsel(n); break;
                    case "fnum": enter_fnum(n); break;
                    case "funccall": enter_funccall(n); break;
                    case "funcdecl": enter_funcdecl(n); break;
                    case "id": enter_id(n); break;
                    case "if": enter_if(n); break;
                    case "ifelse": enter_ifelse(n); break;
                    case "manyparams": enter_manyparams(n); break;
                    case "member": enter_member(n); break;
                    case "membersel": enter_membersel(n); break;
                    case "noparams": enter_noparams(n); break;
                    case "notexp": enter_notexp(n); break;
                    case "num": enter_num(n); break;
                    case "oneparam": enter_oneparam(n); break;
                    case "optsize": enter_optsize(n); break;
                    case "orexp": enter_orexp(n); break;
                    case "param": enter_param(n); break;
                    case "paramlist2a": enter_paramlist2a(n); break;
                    case "paramlist2b": enter_paramlist2b(n); break;
                    case "plus": enter_plus(n); break;
                    case "product": enter_product(n); break;
                    case "relexp": enter_relexp(n); break;
                    case "returnexpr": enter_returnexpr(n); break;
                    case "returnvoid": enter_returnvoid(n); break;
                    case "str": enter_str(n); break;
                    case "structdecl": enter_structdecl(n); break;
                    case "sum": enter_sum(n); break;
                    case "vardecl": enter_vardecl(n); break;
                    case "while": enter_while(n); break;
                }
            }
        }
        public void walkLeave(TreeNode n)
        {
            foreach (var sym in n.labels)
            {
                switch (sym)
                {
                    case "andexp": leave_andexp(n); break;
                    case "array": leave_array(n); break;
                    case "arraysel": leave_arraysel(n); break;
                    case "assign": leave_assign(n); break;
                    case "bblock": leave_bblock(n); break;
                    case "bitexp": leave_bitexp(n); break;
                    case "bitnot": leave_bitnot(n); break;
                    case "castdouble": leave_castdouble(n); break;
                    case "castint": leave_castint(n); break;
                    case "castvec2": leave_castvec2(n); break;
                    case "char": leave_char(n); break;
                    case "copyType": leave_copyType(n); break;
                    case "expr": leave_expr(n); break;
                    case "fcall": leave_fcall(n); break;
                    case "fcallsel": leave_fcallsel(n); break;
                    case "fnum": leave_fnum(n); break;
                    case "funccall": leave_funccall(n); break;
                    case "funcdecl": leave_funcdecl(n); break;
                    case "id": leave_id(n); break;
                    case "if": leave_if(n); break;
                    case "ifelse": leave_ifelse(n); break;
                    case "manyparams": leave_manyparams(n); break;
                    case "member": leave_member(n); break;
                    case "membersel": leave_membersel(n); break;
                    case "noparams": leave_noparams(n); break;
                    case "notexp": leave_notexp(n); break;
                    case "num": leave_num(n); break;
                    case "oneparam": leave_oneparam(n); break;
                    case "optsize": leave_optsize(n); break;
                    case "orexp": leave_orexp(n); break;
                    case "param": leave_param(n); break;
                    case "paramlist2a": leave_paramlist2a(n); break;
                    case "paramlist2b": leave_paramlist2b(n); break;
                    case "plus": leave_plus(n); break;
                    case "product": leave_product(n); break;
                    case "relexp": leave_relexp(n); break;
                    case "returnexpr": leave_returnexpr(n); break;
                    case "returnvoid": leave_returnvoid(n); break;
                    case "str": leave_str(n); break;
                    case "structdecl": leave_structdecl(n); break;
                    case "sum": leave_sum(n); break;
                    case "vardecl": leave_vardecl(n); break;
                    case "while": leave_while(n); break;
                }
            }
            switch (n.sym)
            {
                case "S": leaveNonterminal_S(n); break;
                case "addexp": leaveNonterminal_addexp(n); break;
                case "andexp": leaveNonterminal_andexp(n); break;
                case "assign": leaveNonterminal_assign(n); break;
                case "bitexp": leaveNonterminal_bitexp(n); break;
                case "braceBlock": leaveNonterminal_braceBlock(n); break;
                case "calllist": leaveNonterminal_calllist(n); break;
                case "calllist2": leaveNonterminal_calllist2(n); break;
                case "cast": leaveNonterminal_cast(n); break;
                case "cond": leaveNonterminal_cond(n); break;
                case "decl": leaveNonterminal_decl(n); break;
                case "expr": leaveNonterminal_expr(n); break;
                case "factor": leaveNonterminal_factor(n); break;
                case "funccall": leaveNonterminal_funccall(n); break;
                case "funcdecl": leaveNonterminal_funcdecl(n); break;
                case "itemsel": leaveNonterminal_itemsel(n); break;
                case "mulexp": leaveNonterminal_mulexp(n); break;
                case "notexp": leaveNonterminal_notexp(n); break;
                case "optsize": leaveNonterminal_optsize(n); break;
                case "orexp": leaveNonterminal_orexp(n); break;
                case "param": leaveNonterminal_param(n); break;
                case "paramlist": leaveNonterminal_paramlist(n); break;
                case "paramlist2": leaveNonterminal_paramlist2(n); break;
                case "postfix": leaveNonterminal_postfix(n); break;
                case "relexp": leaveNonterminal_relexp(n); break;
                case "return": leaveNonterminal_return(n); break;
                case "stmt": leaveNonterminal_stmt(n); break;
                case "stmts": leaveNonterminal_stmts(n); break;
                case "structdecl": leaveNonterminal_structdecl(n); break;
                case "type": leaveNonterminal_type(n); break;
                case "unaryexp": leaveNonterminal_unaryexp(n); break;
                case "vardecl": leaveNonterminal_vardecl(n); break;
                case "vardecls": leaveNonterminal_vardecls(n); break;
                case "whileExpr": leaveNonterminal_whileExpr(n); break;
            }
            leave(n);
        }
        public void walk(TreeNode n)
        {
            if (n.labels.Length == 0)
            {
                walkGeneric(n);
                return;
            }
            switch (n.labels[0])
            {
                case "andexp": walk_andexp(n); break;
                case "array": walk_array(n); break;
                case "arraysel": walk_arraysel(n); break;
                case "assign": walk_assign(n); break;
                case "bblock": walk_bblock(n); break;
                case "bitexp": walk_bitexp(n); break;
                case "bitnot": walk_bitnot(n); break;
                case "castdouble": walk_castdouble(n); break;
                case "castint": walk_castint(n); break;
                case "castvec2": walk_castvec2(n); break;
                case "char": walk_char(n); break;
                case "copyType": walk_copyType(n); break;
                case "expr": walk_expr(n); break;
                case "fcall": walk_fcall(n); break;
                case "fcallsel": walk_fcallsel(n); break;
                case "fnum": walk_fnum(n); break;
                case "funccall": walk_funccall(n); break;
                case "funcdecl": walk_funcdecl(n); break;
                case "id": walk_id(n); break;
                case "if": walk_if(n); break;
                case "ifelse": walk_ifelse(n); break;
                case "manyparams": walk_manyparams(n); break;
                case "member": walk_member(n); break;
                case "membersel": walk_membersel(n); break;
                case "noparams": walk_noparams(n); break;
                case "notexp": walk_notexp(n); break;
                case "num": walk_num(n); break;
                case "oneparam": walk_oneparam(n); break;
                case "optsize": walk_optsize(n); break;
                case "orexp": walk_orexp(n); break;
                case "param": walk_param(n); break;
                case "paramlist2a": walk_paramlist2a(n); break;
                case "paramlist2b": walk_paramlist2b(n); break;
                case "plus": walk_plus(n); break;
                case "product": walk_product(n); break;
                case "relexp": walk_relexp(n); break;
                case "returnexpr": walk_returnexpr(n); break;
                case "returnvoid": walk_returnvoid(n); break;
                case "str": walk_str(n); break;
                case "structdecl": walk_structdecl(n); break;
                case "sum": walk_sum(n); break;
                case "vardecl": walk_vardecl(n); break;
                case "while": walk_while(n); break;
                default:
                    walkGeneric(n); break;
            }
        }
        public void walkGeneric(TreeNode n)
        {
            walkEnter(n);
            foreach (var c in n.children)
            {
                walk(c);
            }
            walkLeave(n);
        }
        public void rwalk(TreeNode n)
        {
            walkEnter(n);
            for (int i = n.children.Count - 1; i >= 0; i--)
            {
                rwalk(n.children[i]);
            }
            walkLeave(n);
        }
        public virtual void enterNonterminal_S(TreeNode n) { }
        public virtual void leaveNonterminal_S(TreeNode n) { }
        public virtual void enterNonterminal_addexp(TreeNode n) { }
        public virtual void leaveNonterminal_addexp(TreeNode n) { }
        public virtual void enterNonterminal_andexp(TreeNode n) { }
        public virtual void leaveNonterminal_andexp(TreeNode n) { }
        public virtual void enterNonterminal_assign(TreeNode n) { }
        public virtual void leaveNonterminal_assign(TreeNode n) { }
        public virtual void enterNonterminal_bitexp(TreeNode n) { }
        public virtual void leaveNonterminal_bitexp(TreeNode n) { }
        public virtual void enterNonterminal_braceBlock(TreeNode n) { }
        public virtual void leaveNonterminal_braceBlock(TreeNode n) { }
        public virtual void enterNonterminal_calllist(TreeNode n) { }
        public virtual void leaveNonterminal_calllist(TreeNode n) { }
        public virtual void enterNonterminal_calllist2(TreeNode n) { }
        public virtual void leaveNonterminal_calllist2(TreeNode n) { }
        public virtual void enterNonterminal_cast(TreeNode n) { }
        public virtual void leaveNonterminal_cast(TreeNode n) { }
        public virtual void enterNonterminal_cond(TreeNode n) { }
        public virtual void leaveNonterminal_cond(TreeNode n) { }
        public virtual void enterNonterminal_decl(TreeNode n) { }
        public virtual void leaveNonterminal_decl(TreeNode n) { }
        public virtual void enterNonterminal_expr(TreeNode n) { }
        public virtual void leaveNonterminal_expr(TreeNode n) { }
        public virtual void enterNonterminal_factor(TreeNode n) { }
        public virtual void leaveNonterminal_factor(TreeNode n) { }
        public virtual void enterNonterminal_funccall(TreeNode n) { }
        public virtual void leaveNonterminal_funccall(TreeNode n) { }
        public virtual void enterNonterminal_funcdecl(TreeNode n) { }
        public virtual void leaveNonterminal_funcdecl(TreeNode n) { }
        public virtual void enterNonterminal_itemsel(TreeNode n) { }
        public virtual void leaveNonterminal_itemsel(TreeNode n) { }
        public virtual void enterNonterminal_mulexp(TreeNode n) { }
        public virtual void leaveNonterminal_mulexp(TreeNode n) { }
        public virtual void enterNonterminal_notexp(TreeNode n) { }
        public virtual void leaveNonterminal_notexp(TreeNode n) { }
        public virtual void enterNonterminal_optsize(TreeNode n) { }
        public virtual void leaveNonterminal_optsize(TreeNode n) { }
        public virtual void enterNonterminal_orexp(TreeNode n) { }
        public virtual void leaveNonterminal_orexp(TreeNode n) { }
        public virtual void enterNonterminal_param(TreeNode n) { }
        public virtual void leaveNonterminal_param(TreeNode n) { }
        public virtual void enterNonterminal_paramlist(TreeNode n) { }
        public virtual void leaveNonterminal_paramlist(TreeNode n) { }
        public virtual void enterNonterminal_paramlist2(TreeNode n) { }
        public virtual void leaveNonterminal_paramlist2(TreeNode n) { }
        public virtual void enterNonterminal_postfix(TreeNode n) { }
        public virtual void leaveNonterminal_postfix(TreeNode n) { }
        public virtual void enterNonterminal_relexp(TreeNode n) { }
        public virtual void leaveNonterminal_relexp(TreeNode n) { }
        public virtual void enterNonterminal_return(TreeNode n) { }
        public virtual void leaveNonterminal_return(TreeNode n) { }
        public virtual void enterNonterminal_stmt(TreeNode n) { }
        public virtual void leaveNonterminal_stmt(TreeNode n) {4567}
        public virtual void enterNonterminal_stmts(TreeNode n) { }
        public virtual void leaveNonterminal_stmts(TreeNode n) { }
        public virtual void enterNonterminal_structdecl(TreeNode n) { }
        public virtual void leaveNonterminal_structdecl(TreeNode n) { }
        public virtual void enterNonterminal_type(TreeNode n) { }
        public virtual void leaveNonterminal_type(TreeNode n) { }
        public virtual void enterNonterminal_unaryexp(TreeNode n) { }
        public virtual void leaveNonterminal_unaryexp(TreeNode n) { }
        public virtual void enterNonterminal_vardecl(TreeNode n) { }
        public virtual void leaveNonterminal_vardecl(TreeNode n) { }
        public virtual void enterNonterminal_vardecls(TreeNode n) { }
        public virtual void leaveNonterminal_vardecls(TreeNode n) { }
        public virtual void enterNonterminal_whileExpr(TreeNode n) { }
        public virtual void leaveNonterminal_whileExpr(TreeNode n) { }
        public virtual void enter_andexp(TreeNode n) { }
        public virtual void walk_andexp(TreeNode n) { walkGeneric(n); }
        public virtual void leave_andexp(TreeNode n) { }
        public virtual void enter_array(TreeNode n) { }
        public virtual void walk_array(TreeNode n) { walkGeneric(n); }
        public virtual void leave_array(TreeNode n) { }
        public virtual void enter_arraysel(TreeNode n) { }
        public virtual void walk_arraysel(TreeNode n) { walkGeneric(n); }
        public virtual void leave_arraysel(TreeNode n) { }
        public virtual void enter_assign(TreeNode n) { }
        public virtual void walk_assign(TreeNode n) { walkGeneric(n); }
        public virtual void leave_assign(TreeNode n) { }
        public virtual void enter_bblock(TreeNode n) { }
        public virtual void walk_bblock(TreeNode n) { walkGeneric(n); }
        public virtual void leave_bblock(TreeNode n) { }
        public virtual void enter_bitexp(TreeNode n) { }
        public virtual void walk_bitexp(TreeNode n) { walkGeneric(n); }
        public virtual void leave_bitexp(TreeNode n) { }
        public virtual void enter_bitnot(TreeNode n) { }
        public virtual void walk_bitnot(TreeNode n) { walkGeneric(n); }
        public virtual void leave_bitnot(TreeNode n) { }
        public virtual void enter_castdouble(TreeNode n) { }
        public virtual void walk_castdouble(TreeNode n) { walkGeneric(n); }
        public virtual void leave_castdouble(TreeNode n) { }
        public virtual void enter_castint(TreeNode n) { }
        public virtual void walk_castint(TreeNode n) { walkGeneric(n); }
        public virtual void leave_castint(TreeNode n) { }
        public virtual void enter_castvec2(TreeNode n) { }
        public virtual void walk_castvec2(TreeNode n) { walkGeneric(n); }
        public virtual void leave_castvec2(TreeNode n) { }
        public virtual void enter_char(TreeNode n) { }
        public virtual void walk_char(TreeNode n) { walkGeneric(n); }
        public virtual void leave_char(TreeNode n) { }
        public virtual void enter_copyType(TreeNode n) { }
        public virtual void walk_copyType(TreeNode n) { walkGeneric(n); }
        public virtual void leave_copyType(TreeNode n) { }
        public virtual void enter_expr(TreeNode n) { }
        public virtual void walk_expr(TreeNode n) { walkGeneric(n); }
        public virtual void leave_expr(TreeNode n) { }
        public virtual void enter_fcall(TreeNode n) { }
        public virtual void walk_fcall(TreeNode n) { walkGeneric(n); }
        public virtual void leave_fcall(TreeNode n) { }
        public virtual void enter_fcallsel(TreeNode n) { }
        public virtual void walk_fcallsel(TreeNode n) { walkGeneric(n); }
        public virtual void leave_fcallsel(TreeNode n) { }
        public virtual void enter_fnum(TreeNode n) { }
        public virtual void walk_fnum(TreeNode n) { walkGeneric(n); }
        public virtual void leave_fnum(TreeNode n) { }
        public virtual void enter_funccall(TreeNode n) { }
        public virtual void walk_funccall(TreeNode n) { walkGeneric(n); }
        public virtual void leave_funccall(TreeNode n) { }
        public virtual void enter_funcdecl(TreeNode n) { }
        public virtual void walk_funcdecl(TreeNode n) { walkGeneric(n); }
        public virtual void leave_funcdecl(TreeNode n) { }
        public virtual void enter_id(TreeNode n) { }
        public virtual void walk_id(TreeNode n) { walkGeneric(n); }
        public virtual void leave_id(TreeNode n) { }
        public virtual void enter_if(TreeNode n) { }
        public virtual void walk_if(TreeNode n) { walkGeneric(n); }
        public virtual void leave_if(TreeNode n) { }
        public virtual void enter_ifelse(TreeNode n) { }
        public virtual void walk_ifelse(TreeNode n) { walkGeneric(n); }
        public virtual void leave_ifelse(TreeNode n) { }
        public virtual void enter_manyparams(TreeNode n) { }
        public virtual void walk_manyparams(TreeNode n) { walkGeneric(n); }
        public virtual void leave_manyparams(TreeNode n) { }
        public virtual void enter_member(TreeNode n) { }
        public virtual void walk_member(TreeNode n) { walkGeneric(n); }
        public virtual void leave_member(TreeNode n) { }
        public virtual void enter_membersel(TreeNode n) { }
        public virtual void walk_membersel(TreeNode n) { walkGeneric(n); }
        public virtual void leave_membersel(TreeNode n) { }
        public virtual void enter_noparams(TreeNode n) { }
        public virtual void walk_noparams(TreeNode n) { walkGeneric(n); }
        public virtual void leave_noparams(TreeNode n) { }
        public virtual void enter_notexp(TreeNode n) { }
        public virtual void walk_notexp(TreeNode n) { walkGeneric(n); }
        public virtual void leave_notexp(TreeNode n) { }
        public virtual void enter_num(TreeNode n) { }
        public virtual void walk_num(TreeNode n) { walkGeneric(n); }
        public virtual void leave_num(TreeNode n) { }
        public virtual void enter_oneparam(TreeNode n) { }
        public virtual void walk_oneparam(TreeNode n) { walkGeneric(n); }
        public virtual void leave_oneparam(TreeNode n) { }
        public virtual void enter_optsize(TreeNode n) { }
        public virtual void walk_optsize(TreeNode n) { walkGeneric(n); }
        public virtual void leave_optsize(TreeNode n) { }
        public virtual void enter_orexp(TreeNode n) { }
        public virtual void walk_orexp(TreeNode n) { walkGeneric(n); }
        public virtual void leave_orexp(TreeNode n) { }
        public virtual void enter_param(TreeNode n) { }
        public virtual void walk_param(TreeNode n) { walkGeneric(n); }
        public virtual void leave_param(TreeNode n) { }
        public virtual void enter_paramlist2a(TreeNode n) { }
        public virtual void walk_paramlist2a(TreeNode n) { walkGeneric(n); }
        public virtual void leave_paramlist2a(TreeNode n) { }
        public virtual void enter_paramlist2b(TreeNode n) { }
        public virtual void walk_paramlist2b(TreeNode n) { walkGeneric(n); }
        public virtual void leave_paramlist2b(TreeNode n) { }
        public virtual void enter_plus(TreeNode n) { }
        public virtual void walk_plus(TreeNode n) { walkGeneric(n); }
        public virtual void leave_plus(TreeNode n) { }
        public virtual void enter_product(TreeNode n) { }
        public virtual void walk_product(TreeNode n) { walkGeneric(n); }
        public virtual void leave_product(TreeNode n) { }
        public virtual void enter_relexp(TreeNode n) { }
        public virtual void walk_relexp(TreeNode n) { walkGeneric(n); }
        public virtual void leave_relexp(TreeNode n) { }
        public virtual void enter_returnexpr(TreeNode n) { }
        public virtual void walk_returnexpr(TreeNode n) { walkGeneric(n); }
        public virtual void leave_returnexpr(TreeNode n) { }
        public virtual void enter_returnvoid(TreeNode n) { }
        public virtual void walk_returnvoid(TreeNode n) { walkGeneric(n); }
        public virtual void leave_returnvoid(TreeNode n) { }
        public virtual void enter_str(TreeNode n) { }
        public virtual void walk_str(TreeNode n) { walkGeneric(n); }
        public virtual void leave_str(TreeNode n) { }
        public virtual void enter_structdecl(TreeNode n) { }
        public virtual void walk_structdecl(TreeNode n) { walkGeneric(n); }
        public virtual void leave_structdecl(TreeNode n) { }
        public virtual void enter_sum(TreeNode n) { }
        public virtual void walk_sum(TreeNode n) { walkGeneric(n); }
        public virtual void leave_sum(TreeNode n) { }
        public virtual void enter_vardecl(TreeNode n) { }
        public virtual void walk_vardecl(TreeNode n) { walkGeneric(n); }
        public virtual void leave_vardecl(TreeNode n) { }
        public virtual void enter_while(TreeNode n) { }
        public virtual void walk_while(TreeNode n) { walkGeneric(n); }
        public virtual void leave_while(TreeNode n) { }
        public virtual void enter(TreeNode n) { }
        public virtual void leave(TreeNode n) { }
    }
}//end TreeWalker}

