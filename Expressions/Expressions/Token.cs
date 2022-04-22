using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
    public class Token
    {
        public string sym;
        public string lexeme;
        public int line;
        public Token()
        {
            this.sym = null;
            this.lexeme = null;
            this.line = 0;
        }
        public Token(string sym, string lexeme, int line)
        {
            this.sym = sym;
            this.lexeme = lexeme;
            this.line = line;
        }
    }
}
