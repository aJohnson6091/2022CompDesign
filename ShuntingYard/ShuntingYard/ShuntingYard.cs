using System;
using System.Collections.Generic;

namespace ShuntingYard
{
    class ShuntingYard
    {
        static void Main(string[] args)
        {
            string gfile = "Gram.txt";
            string gramspec;
            using (var r = new System.IO.StreamReader(gfile))
            {
                gramspec = r.ReadToEnd();
            }
            var g = new Grammar(gramspec);
            var tokenizer = new Tokenizer(g);
            string input;

            //get input
            input = Console.ReadLine();

            tokenizer.setInput(input);
            List<Token> tokens = new List<Token>();
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            Stack<TreeNode> operatorStack = new Stack<TreeNode>();
            while (true)
            {
                try
                {
                    Token t = tokenizer.next();
                    
                    if (t.sym == "$")
                    {
                        break;
                    }

                    if(t.lexeme == "-")
                    {
                        string p = tokens[tokens.Count - 1].sym;
                        if(p == null || p.Equals("LP") || p.Equals("MULOP") || p.Equals("POWOP")|| p.Equals("ADDOP"))
                        {
                            t.sym = "NEGATE";
                        }
                    }

                    tokens.Add(t);

                    if (t.sym == "NUM" || t.sym == "ID")
                    {
                        nodeStack.Push(new TreeNode(t.sym, t));
                    }
                    else
                    {
                        Functions.handleOperator(t, operatorStack, nodeStack);
                    }

                }
                catch (Exception e)
                {
                    break;

                }
            }while(operatorStack.Count != 0)
            {
                TreeNode opNode = operatorStack.Pop();
                TreeNode c1 = nodeStack.Pop();
                TreeNode c2 = nodeStack.Pop();
                opNode.children.Add(c2);
                opNode.children.Add(c1);
                nodeStack.Push(opNode);
            }

        }

        
    }
}
