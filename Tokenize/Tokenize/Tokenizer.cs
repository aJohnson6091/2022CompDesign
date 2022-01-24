using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tokenize
{
    class Tokenizer
    {
        List<Terminal> terminals = new List<Terminal>();
        int index;
        List<string> input;
        int lineNumber;
        public Tokenizer(Grammar g)
        {
            terminals = g.terminals;
        }
        public void setInput(string input)
        {
            this.index = 0;
            this.input = new List<string>(input.Split((char)32));
            this.lineNumber = 1;
        }
        public Token next()
        {
            Token returnToken = new Token("","",0);
            
            if(this.index >= input.Count)
            {
                return new Token("$", "", -1);
            }
            foreach(Terminal terminal in terminals)
            {
                string temp = terminal.rex.Match(this.input.ElementAt(index)).Value;

                if (temp.Length > returnToken.lexeme.Length)
                {
                    returnToken.lexeme = temp;
                    returnToken.sym = terminal.sym;

                }
            }

            this.index++;

            if (returnToken.lexeme.Length <= 0)
            {
                throw new Exception();
            }
            if(returnToken.sym == "COMMENT" || returnToken.sym == "WHITESPACE")
            {
                return next();
            }
            else
            {
                returnToken.line = this.lineNumber;
                this.lineNumber++;
                return returnToken;
            }
        }
        /*
        public Token peek()
        {
            
        }
        */
    }
}
