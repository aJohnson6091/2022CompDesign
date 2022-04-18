using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM
{
    public class ASM
    {
        public bool readOnly = false;
        public List<string> instructions = new List<string>();
        public ASM(params object[] instr)
        {
            this.append(instr);
        }
        public void append(params object[] instr)
        {
            if (readOnly)
                throw new Exception();
            foreach (var ob in instr)
            {
                if (ob is string)
                    instructions.Add(ob as string);
                else if (ob is ASM)
                {
                    foreach (var ins in (ob as ASM).instructions)
                        instructions.Add(ins);
                }
                else
                    throw new Exception("Bad type");
            }
        }
        public override string ToString()
        {
            string[] tmp = new string[instructions.Count];
            var rex = new Regex(@"^(\w+:|section|global|extern|bits|default)");
            for (int i = 0; i < instructions.Count; ++i)
            {
                string instr = instructions[i];
                if (rex.IsMatch((instr)))
                    tmp[i] = instr;
                else
                    tmp[i] = "    " + instr;
            }
            return string.Join("\n", tmp) + "\n";
        }
    }
}
