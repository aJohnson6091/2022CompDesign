using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable
{
    class TreeNode
    {
        public string sym;
        public Token token;
        public List<TreeNode> children = new List<TreeNode>();
        public TreeNode(string sym, Token token)
        {
            this.sym = sym;
            this.token = token;
        }
        
    }
}
