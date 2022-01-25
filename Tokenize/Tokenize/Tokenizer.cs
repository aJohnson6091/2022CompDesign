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
        string input;
        int lineNumber;
        public Tokenizer(Grammar g)
        {
            terminals = g.terminals;
        }
        public void setInput(string input)
        {
            this.index = 0;
            this.input = input;
            this.lineNumber = 1;
        }
        public Token next()
        {
            Token returnToken = new Token("","",0);
            
            if(this.index >= input.Length)
            {
                return new Token("$", "", -1);
            }
            foreach(Terminal terminal in terminals)
            {
                string temp = "";
                if (terminal.rex.Match(this.input.Substring(this.index, this.input.Length - this.index)).Success){
                    temp = terminal.rex.Match(this.input.Substring(this.index, this.input.Length - this.index)).Value;
                }
                

                if (temp.Length > returnToken.lexeme.Length)
                {
                    returnToken.lexeme = temp;
                    returnToken.sym = terminal.sym;

                }
            }

            index +=returnToken.lexeme.Length;

            
            if(returnToken.sym == "COMMENT" || returnToken.sym == "WHITESPACE")
            {
                if(returnToken.lexeme.Contains("\n"))
                {
                    lineNumber += returnToken.lexeme.Split("\n").Length-1;
                }
                return next();
            }

            returnToken.line = this.lineNumber;

            if (returnToken.lexeme.Length <= 0)
            {
                throw new Exception(returnToken.line.ToString());
            }
                
            return returnToken;
            
        }
        /*
        public Token peek()
        {
            
        }
        */
    }
}
