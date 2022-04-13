using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public class TreeNode
    {
        public VType type = new VTypeVoid();
        public string sym;          //token's sym or production's lhs
        public Token token;        //might be null
        public int productionIndex;     //only if sym is nonterminal
        public string[] labels;
        public List<TreeNode> children = new List<TreeNode>();
        public TreeNode(string sym, Token t, int pi)
        {
            this.sym = sym;
            this.token = t;
            this.productionIndex = pi;
        }
    }
}
