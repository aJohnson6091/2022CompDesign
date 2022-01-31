using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFGIntro
{
    class Output
    {
        public List<string> terminals;
        public Dictionary<string,List<Production>> nonterminals;
        public string specification;
        public Output(List<Terminal> terminals, Dictionary<string, List<Production>> nonterminals, string specification)
        {
            this.terminals = new List<string>();
            foreach(Terminal terminal in terminals)
            {
                this.terminals.Add(terminal.sym);
            }
            this.nonterminals = nonterminals;
            this.specification = specification;
        }
    }
}
