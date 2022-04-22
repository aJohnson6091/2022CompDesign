using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
    class SymbolTable
    {
        public List<Scope> scopes = new List<Scope>();
        public SymbolTable()
        {
            addScope();         // global scope
        }
        public void addScope()
        {
            scopes.Add(new Scope());
        }
        public void removeScope()
        {
            scopes.RemoveAt(scopes.Count - 1);
        }
        public VarInfo this[string vname]
        {
            get
            {
                for (int i = scopes.Count - 1; i >= 0; i--)
                {
                    VarInfo tmp = scopes[i][vname];
                    if (tmp != null)
                        return tmp;
                }
                return null;
            }
            set
            {
                scopes[scopes.Count - 1][vname] = value;
            }
        }
    }
}
