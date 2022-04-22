using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
    class RegisterManager
    {
        Stack<RegisterLocation> availReg = new Stack<RegisterLocation>();
        Stack<XMMLocation> availXMM = new Stack<XMMLocation>();

        public RegisterManager()
        {
            string[] tmp = new string[] {
            "rbx","rsi","rdi","r8","r9","r10","r11",
            "r12","r13","r14","r15"};
            foreach (string s in tmp)
                availReg.Push(new RegisterLocation(s));
            foreach (string s in tmp)
                availXMM.Push(new XMMLocation(s));
         }
        public DataLocation allocateInt()
        {
            return availReg.Pop();
        }
        public DataLocation allocateFloat()
        {
            return availXMM.Pop();
        }
        public void release(DataLocation item)
        {
            if (item is RegisterLocation)
                availReg.Push(item as RegisterLocation);
            else if (item is XMMLocation)
                availXMM.Push(item as XMMLocation);
            else
                throw new Exception("Register Manager Release Error")
        }
    }
}
