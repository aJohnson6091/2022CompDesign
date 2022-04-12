using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFollow
{
    class Nullable
    {
        public HashSet<string> calculateNullableSet(Dictionary<string, List<Production>> nonterminals)
        {
            HashSet<string> nullableSet = new HashSet<string>();
            bool changedFlag = true;
            while (changedFlag)
            {
                changedFlag = false;
                foreach(string N in nonterminals.Keys)
                {
                    if (!nullableSet.Contains(N))
                    {
                        foreach(Production P in nonterminals[N])
                        {
                            bool allNullable = true;
                            foreach (string q in P.rhs)
                            {
                                if (!nullableSet.Contains(q))
                                {
                                    allNullable = false;
                                }
                            }
                            if(allNullable == true)
                            {
                                nullableSet.Add(N);
                                changedFlag = true;
                            }
                        }
                    }
                }
            }
            return nullableSet;
        }
    }
}
