using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Expressions
{
    class TreeData
    {
        public bool ok = true;
        public TreeNode? tree;
    }

    public class MainClass
    {
        static void Main(string[] args)
        {
            //string grammarfile = args [0];
            //string inputfile = args [1];
            //string grammarspec = args[2];
            string treefile = args[3];
            string treedata;
            using (var r = new System.IO.StreamReader(treefile))
            {
                treedata = r.ReadToEnd();
            }

            var opts = new System.Text.Json.JsonSerializerOptions();
            opts.IncludeFields = true;
            TreeData data = (TreeData)System.Text.Json.JsonSerializer.Deserialize(
                treedata, typeof(TreeData), opts);

            TreeNode root = data.tree;
            //this is just for testing, to verify that the tree was read in correctly
            //dump(root, 0);
            OutputObject output = new OutputObject();
            try
            {
                TypeWalker walker = new TypeWalker();
                walker.walk(root);
                output.ok = true;
            }
            catch(Exception e)
            {
                output.ok = false;
            }
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(output, opts));
        }

        //testing
        static void dump(TreeNode n, int indent)
        {
            for (int i = 0; i < indent; ++i)
                Console.Write(" ");
            Console.WriteLine($"[TreeNode {n.sym} {n.token} {n.children.Count} children ]");
            foreach (TreeNode c in n.children)
            {
                dump(c, indent + 4);
            }
        }
    }
}
