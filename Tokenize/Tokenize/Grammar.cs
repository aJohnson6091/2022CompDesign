using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenize
{
    class Grammar
    {
        public List<Terminal> terminals = new List<Terminal>();
        public Grammar(string gramspec)
        {
            StringReader lineReader = new StringReader(gramspec);
            List<string> lines = new List<string>();

            //breakdown the spec into lines
            while (lineReader.Peek() != -1)
            {
                string line = lineReader.ReadLine();
                if (char.IsWhiteSpace(line[0]))
                {
                    lines.Last().Append((char)32); //magic number for space might deserve a const
                    line = line.Trim();
                    foreach(char c in line)
                    {
                        lines.Last().Append(c);
                    }
                }
                else
                {
                    if(!(line.Trim().Length == 0)){
                        lines.Add(line.Trim());
                    }
                    
                }
            }
            //Setup the actual data
            foreach(string line in lines)
            {
                if(!(line.StartsWith("#")||line.Length == 0))
                {
                    string[] sides;
                    string lhs, rhs;

                    //split at the :
                    sides = line.Split("::", 2);
                    
                    //
                    lhs = sides[0].Trim();
                    rhs = sides[1].Trim();
                    rhs = "\\G(" + rhs + ")";
                    if (char.IsUpper(lhs[0]))
                    {
                        terminals.Add(new Terminal(lhs, new System.Text.RegularExpressions.Regex(rhs)));
                    }
                }
            }
        }
    }
}
