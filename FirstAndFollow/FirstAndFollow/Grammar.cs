using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFollow
{
    class Grammar
    {
        public List<Terminal> terminals = new List<Terminal>();
        public Dictionary<string, List<Production>> nonterminal = new Dictionary<string, List<Production>>();
        public Grammar(string gramspec)
        {
            StringReader lineReader = new StringReader(gramspec);
            List<string> lines = new List<string>();

            //breakdown the spec into lines
            while (lineReader.Peek() != -1)
            {
                string line = lineReader.ReadLine();
                if(line.Length == 0)
                {
                    continue;
                }
                if (char.IsWhiteSpace(line[0]))
                {
                    lines[lines.Count-1] = lines.Last() + " " + line.Trim(); //magic number for space might deserve a const
                }
                else
                {
                    if(!(line.Trim().Length == 0)){
                        lines.Add(line.Trim());
                    }
                    
                }
            }
            //Setup the actual data
            string lhs;
            foreach(string line in lines)
            {
                if(!(line.StartsWith("#")||line.Length == 0))
                {
                    string[] sides;
                    sides = line.Split("::", 2);
                    //nonterminal
                    if (sides[0].Trim().Equals("S") || !(char.IsUpper(line[0])))
                    {

                        
                        string[] rhsLabelSplit, rhsProductionSplit;
                        lhs = sides[0].Trim();

                        //splits the labels away
                        
                        
                        //split an ORs
                        rhsProductionSplit = sides[1].Split("|", StringSplitOptions.RemoveEmptyEntries);
                        
                        foreach (string stringstoSplit in rhsProductionSplit)
                        {
                            List<string> rhs = new List<string>();
                            List<string> labels = new List<string>();
                            rhsLabelSplit = stringstoSplit.Split("@", 2);
                            foreach (string splitString in rhsLabelSplit[0].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                            {
                                if(splitString != "lambda")
                                {
                                    rhs.Add(splitString);
                                }
                            }
                            if (rhsLabelSplit.Length > 1)
                            {
                                foreach(string stringSplit in rhsLabelSplit[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                                {
                                    labels.Add(stringSplit.Trim());
                                }

                            }

                            if (nonterminal.ContainsKey(lhs))
                            {
                                nonterminal[lhs].Add(new Production(lhs, rhs));
                            }
                            else
                            {
                                nonterminal.Add(lhs, new List<Production>());
                                nonterminal[lhs].Add(new Production(lhs, rhs));
                            }
                        }
                    }
                    //terminal
                    else
                    {
                        string rhs;
                        string[] labels;
                        lhs = sides[0].Trim();
                        rhs = sides[1].Trim();
                        labels = rhs.Split("@");
                        rhs = "\\G(" + rhs + ")";
                        terminals.Add(new Terminal(lhs, new System.Text.RegularExpressions.Regex(rhs)));
                    }
                }
            }
            /*
            bool whiteSpaceFlag = false;
            foreach(Terminal terminal in terminals)
            {
                
                if (terminal.sym.Equals("WHITESPACE"))
                {
                    whiteSpaceFlag = true;
                }
            }
            if(whiteSpaceFlag == false)
            {
                terminals.Add(new Terminal("WHITESPACE", new System.Text.RegularExpressions.Regex("\\s+"),null));
            }
            */
        }
    }
}
