using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFollow
{
    class Follow
    {

        public Dictionary<string ,HashSet<string>> calculateFollowSet(Dictionary<string, List<Production>> nonterminals, Dictionary<string, HashSet<string>> first, HashSet<string> nullable, List<string> alteredSymbols)
        {
            Dictionary<string, HashSet<string>> follow = new Dictionary<string, HashSet<string>>();
            bool changed = true;
            foreach (string N in nonterminals.Keys)
            {
                if (alteredSymbols.Contains(N))
                {
                    continue;
                }
                else
                {

                    follow.Add(N, new HashSet<string>());
                }
                if (N == "S")
                {
                    follow[N].Add("$");
                }
            }
                while (changed)
            {
                changed = false;
                foreach (string N in nonterminals.Keys)
                {
                    foreach (Production P in nonterminals[N])
                    {
                        for(int i = 0; i< P.rhs.Count; i++)
                        {
                            string x = P.rhs[i];
                            if (nonterminals.ContainsKey(x))
                            {
                                bool broke = false;
                                foreach (string y in P.rhs.Skip(i + 1))
                                {
                                    if (first.ContainsKey(y))
                                    {
                                        int size1, size2;
                                        size1 = follow[x].Count;
                                        follow[x].UnionWith(first[y]);
                                        size2 = follow[x].Count;
                                        if (size1 != size2)
                                        {
                                            changed = true;
                                        }
                                        if (!nullable.Contains(y))
                                        {
                                            broke = true;
                                            break;
                                        }
                                    }
                                    else {
                                        broke = true;
                                    }
                                    
                                }
                                if (!broke&& follow.ContainsKey(x))
                                {
                                    follow[x].UnionWith(follow[N]);
                                }
                            }
                        }
                    }
                }
            }
                return follow;
        }
    }
}