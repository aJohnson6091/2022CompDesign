using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShuntingYard
{
    class Terminal
    {
        public string sym;
        public Regex rex;
        public Terminal(string sym, Regex rex)
        {
            this.sym = sym;
            this.rex = rex;
        }
    }
}
