using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable
{
    class Production
    {
        public string lhs;
        public List<string> rhs;
        public Production(string lhs, List<string> rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
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
