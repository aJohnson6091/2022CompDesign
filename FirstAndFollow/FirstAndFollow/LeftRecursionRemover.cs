using FirstAndFollow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFollow
{
    class LeftRecursionRemover
    {
        public List<string> alteredSymbols;
        public Dictionary<string, List<Production>> nonterminals;

        public LeftRecursionRemover(Dictionary<string, List<Production>> nonterminals)
        {
            this.nonterminals = nonterminals;
            this.alteredSymbols = new List<string>();
        }
        struct RecursionDetection
        {
            public List<Production> leftRecursive;
            public List<Production> notLeftRecursive;
        }

        public bool removeOneRoundOfLeftRecursion()
        {
            bool flag = false;
            foreach (string N in nonterminals.Keys.ToList())
            {
                if (removeLeftRecursionForSymbol(N, alteredSymbols))
                {
                    flag = true;
                }
            }
            return flag;
        }

        bool removeLeftRecursionForSymbol(string symbol, List<string> alteredSymbols)
        {
            List<Production> productions = nonterminals[symbol];
            if (alteredSymbols.Contains(symbol))
                return false;
            RecursionDetection recursionDetection = classifyProductions(symbol, productions);
            if (recursionDetection.leftRecursive.Count == 0)
            {
                return false;
            }
            string newSymbol = makeUniqueSymbol(symbol);
            List<Production> newProductions1 = new List<Production>();
            foreach (Production P in recursionDetection.notLeftRecursive)
            {
                if (P.rhs.Count == 0)
                {
                    newProductions1.Add(new Production(symbol, P.rhs));
                }
                else
                {
                    P.rhs.Add(newSymbol);
                    newProductions1.Add(new Production(symbol, P.rhs));
                }
            }
            nonterminals[symbol] = newProductions1;
            List<Production> newProductions2 = new List<Production>();
            foreach (Production P in recursionDetection.leftRecursive)
            {
                P.rhs.RemoveAt(0);
                P.rhs.Add(newSymbol);
                newProductions2.Add(new Production(symbol, P.rhs));
            }
            nonterminals[newSymbol] = newProductions2;
            alteredSymbols.Add(symbol);
            return true;
        }

        RecursionDetection classifyProductions(string symbol, List<Production> productions)
        {
            RecursionDetection returnStruct = new RecursionDetection();
            returnStruct.leftRecursive = new List<Production>();
            returnStruct.notLeftRecursive = new List<Production>();
            foreach (Production production in productions)
            {
                if (production.rhs.Count > 0 && production.rhs[0] == symbol && !symbol.Contains('\''))
                {
                    returnStruct.leftRecursive.Add(production);
                }
                else
                {
                    returnStruct.notLeftRecursive.Add(production);
                }
            }
            return returnStruct;
        }

        string makeUniqueSymbol(string symbol)
        {
            while (nonterminals.ContainsKey(symbol))
            {
                symbol += "'";
            }
            return symbol;
        }
    }
}
