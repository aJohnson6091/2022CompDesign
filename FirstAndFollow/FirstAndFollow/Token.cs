using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFollow
{
    class Token
    {
        public string sym;
        public string lexeme;
        public int line;
        public Token(string sym, string lexeme, int line)
        {
            this.sym = sym;
            this.lexeme = lexeme;
            this.line = line;
        }
    }
}
