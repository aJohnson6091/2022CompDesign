using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFollow
{
    class First
    {
        public Dictionary<string, HashSet<string>> calculateFirstSet(Dictionary<string, List<Production>> nonterminals,List<Terminal> terminals, HashSet<string> nullable,List<string> alteredSymbols)
        {
            Dictionary<string, HashSet<string>> first = new Dictionary<string, HashSet<string>>();
            foreach(Terminal t in terminals)
            {
                first.Add(t.sym, new HashSet<string>());
                first[t.sym].Add(t.sym);
            }
            bool changed = true;
            
            while (changed)
            {
                changed = false;
                foreach (string N in nonterminals.Keys)
                {
                    foreach (Production P in nonterminals[N])
                    {
                        if (!first.ContainsKey(N))
                        {
                            if (alteredSymbols.Contains(N))
                            {
                                break;
                            }
                            else
                            {

                                first.Add(N, new HashSet<string>());
                            }
                        }
                        foreach (string sym in P.rhs)
                        {
                            int size1, size2;
                            size1 = first[N].Count;
                            if (first.ContainsKey(sym))
                            {
                                first[N].UnionWith(first[sym]);
                            }
                            size2 = first[N].Count;
                            if (size1 != size2)
                            {
                                changed = true;
                            }
                            if (!nullable.Contains(sym))
                            {
                                break;
                            }
                        }
                    }
                }   
            }
            return first;
        }
    }
}
