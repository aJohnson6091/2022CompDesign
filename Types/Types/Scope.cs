using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    class Scope
    {
        public Dictionary<string, VarInfo> vars;
        public Scope()
        {
            vars = new Dictionary<string, VarInfo>();
        }
        public VarInfo this[string vname]
        {
            get
            {
                if (vars.ContainsKey(vname))
                    return vars[vname];
                else
                    return null;
            }
            set
            {
                if (vars.ContainsKey(vname))
                    throw new Exception("Duplicate variable");
                else
                    vars[vname] = value;
            }
        }
    }
}
