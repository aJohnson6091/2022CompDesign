using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CFGIntro
{
    class Terminal
    {
        public string sym;
        public Regex rex;
        public string[] labels;
        public Terminal(string sym, Regex rex, string[] labels)
        {
            this.sym = sym;
            this.rex = rex;
            this.labels = labels;
        }
    }
}
