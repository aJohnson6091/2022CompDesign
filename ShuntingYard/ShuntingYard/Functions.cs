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
            if (sym.Equals("NEGATE"))
                return 40;            
            if (sym.Equals("MULOP"))
                return 20;
            if (sym.Equals("ADDOP"))
                return 10;
            return 0;
        }

        private static char associativity(string sym)
        {
            if (sym.Equals("POWOP")||sym.Equals("NEGATE"))
                return 'R';
            return 'L';
        }

        public static int arity(string sym)
        {
            if (sym.Equals("NEGATE"))
                return 1;
            return 2;
        }

        public static void handleOperator(Token t, Stack<TreeNode> operatorStack, Stack<TreeNode> nodeStack)
        {
            char assoc = associativity(t.sym);
            while (true)
            {
                if (operatorStack.Count == 0)
                    break;
                string A = operatorStack.Peek().sym;
                if (((assoc == 'L' && precedence(A) >= precedence(t.sym)) || (assoc == 'R' && precedence(A) > precedence(t.sym))) && precedence(t.sym)!=0)
                {
                    TreeNode opNode = operatorStack.Pop();
                    TreeNode c1 = nodeStack.Pop();
                    if (arity(A) == 2)
                    {
                        TreeNode c2 = nodeStack.Pop();
                        opNode.children.Add(c2);
                    }
                    opNode.children.Add(c1);
                    nodeStack.Push(opNode);
                }else if(t.sym.Equals("RP"))
                {
                    while (true)
                    {
                        TreeNode opNode = operatorStack.Pop();
                        if (opNode.sym.Equals("LP"))
                            return;
                        TreeNode c1 = nodeStack.Pop();
                        if (arity(A) == 2)
                        {
                            TreeNode c2 = nodeStack.Pop();
                            opNode.children.Add(c2);
                        }
                        opNode.children.Add(c1);
                        nodeStack.Push(opNode);
                    } 
                }
                else
                {
                    break;
                }
            }
            operatorStack.Push(new TreeNode(t.sym, t));
        }

        public static float parseTree(TreeNode node)
        {
            if (node.sym.Equals("NEGATE"))
            {
                return float.Parse(node.children[0].token.lexeme) * -1;
            }
            if(node.sym.Equals("MULOP") || node.sym.Equals("POWOP") || node.sym.Equals("ADDOP"))
            {
                float c1Value, c2Value;
                if (node.children.Count == 2)
                {
                    if(node.children[0].token.sym == "NUM")
                    {
                        c1Value = float.Parse(node.children[0].token.lexeme);
                    }
                    else
                    {
                        c1Value = parseTree(node.children[0]);
                    }
                    if (node.children[1].token.sym == "NUM")
                    {
                        c2Value = float.Parse(node.children[1].token.lexeme);
                    }
                    else
                    {
                        c2Value = parseTree(node.children[1]);
                    }

                    switch (node.token.lexeme)
                    {
                        case "+":
                            return c1Value + c2Value;                           
                        case "-":
                            return c1Value - c2Value;                            
                        case "*":
                            return c1Value * c2Value;                            
                        case "/":
                            return c1Value / c2Value;                            
                        case "**":
                            return (int)Math.Pow(c1Value,c2Value);                           
                    }
                }
                else
                {
                    return float.Parse(node.token.lexeme);
                }
            }
            return 0;
        }

        
    }
}
