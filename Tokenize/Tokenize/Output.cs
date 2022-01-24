using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tokenize
{
    class Output
    {
        public int error;
        public List<Token> tokens;
        public Output()
        {
            error = -1;
            tokens = new List<Token>();
        }
        public Output(int error, List<Token> tokens)
        {
            this.error = error;
            this.tokens = tokens;
        }
    }
}
