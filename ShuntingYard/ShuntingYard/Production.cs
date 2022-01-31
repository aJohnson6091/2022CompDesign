using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShuntingYard
{
    class Production
    {
        public string lhs;
        public string[] rhs;
        public string[] labels;
        public Production(string lhs, string[] rhs, string[] labels)
        {
            this.lhs = lhs;
            this.rhs = rhs;
            this.labels = labels;
        }
        public override string ToString()
        {
            if (rhs.Count() == 0)
                return this.lhs + " :: \u03bb";        //lambda
            else
                return this.lhs + " :: " + String.Join(" ", rhs);
        }
    }
}
