using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
    public class TreeNode
    {
        public VType type = new VTypeVoid();
        public string sym;          //token's sym or production's lhs
        public Token token;        //might be null
        public int productionIndex;     //only if sym is nonterminal
        public string[] labels;
        public List<TreeNode> children = new List<TreeNode>();
        public DataLocation resultLocation = null;

        private ASM code_ = null;

        public TreeNode()
        {

        }
        public TreeNode(string sym, Token t, int pi)
        {
            this.sym = sym;
            this.token = t;
            this.productionIndex = pi;
        }


        public ASM code
        {
            get
            {
                if (this.code_ != null)
                    return this.code_;
                else
                {
                    ASM code = new ASM();
                    foreach (var c in this.children)
                        code.append(c.code);
                    code.readOnly = true;
                    return code;
                }
            }
            set
            {
                this.code_ = value;
            }
        }
        public int line
        {
            get
            {
                if (this.token != null)
                    return this.token.line;
                foreach (var c in this.children)
                {
                    int tmp = c.line;
                    if (tmp != -1)
                        return tmp;
                }
                return -1;
            }
        }
        public string text
        {
            get
            {
                if (this.token != null)
                    return this.token.lexeme;
                var tmp = new List<string>();
                foreach (var c in this.children)
                {
                    tmp.Add(c.text);
                }
                return string.Join(" ", tmp);
            }
        }
    }   
}
