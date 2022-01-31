using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuntingYard
{
    class Functions
    {
        public static int precedence(string sym)
        {
            if (sym.Equals("POWOP"))
                return 50;
            if (sym.Equals("MULOP"))
                return 20;
            if (sym.Equals("ADDOP"))
                return 10;
            return 0;
        }

        private static char associativity(string sym)
        {
            if (sym.Equals("POWOP"))
                return 'R';
            return 'L';
        }

        public static void handleOperator(Token t, Stack<TreeNode> operatorStack, Stack<TreeNode> nodeStack)
        {
            char assoc = associativity(t.sym);
            while (true)
            {
                if (operatorStack.Count == 0)
                    break;
                string A = operatorStack.Peek().sym;
                if ((assoc == 'L' && precedence(A) >= precedence(t.sym)) || (assoc == 'R' && precedence(A) > precedence(t.sym)))
                {
                    TreeNode opNode = operatorStack.Pop();
                    TreeNode c1 = nodeStack.Pop();
                    TreeNode c2 = nodeStack.Pop();
                    opNode.children.Add(c2);
                    opNode.children.Add(c1);
                    nodeStack.Push(opNode);
                }
                else
                {
                    break;
                }
            }
            operatorStack.Push(new TreeNode(t.sym, t));
        }

        
    }
}
