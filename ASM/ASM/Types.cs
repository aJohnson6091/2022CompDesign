using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM
{
    public class VType
    {
        readonly string name;
        public VType(string n)
        {
            this.name = n;
        }
        public override string ToString()
        {
            return this.name;
        }
        public override bool Equals(object o)
        {
            VType t2 = o as VType;
            if (t2 == null)
                return false;
            return this.name == t2.name;
        }
        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
        public static bool operator ==(VType a, VType b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null))
                return false;
            return a.Equals(b);
        }
        public static bool operator !=(VType a, VType b)
        {
            return !(a == b);
        }
        //for convenience
        public static readonly VType INT;
        public static readonly VType DOUBLE;
        public static readonly VType STRING;
        public static readonly VType VOID;
        static VType()
        {
            INT = new VTypeInt();       //next slide
            DOUBLE = new VTypeDouble(); //next slide
            STRING = new VTypeString();
            VOID = new VTypeVoid();     //next slide
        }
    }

    public class VTypeInt : VType
    {
        public VTypeInt() : base("int") { }
    }

    public class VTypeDouble : VType
    {
        public VTypeDouble() : base("double") { }
    }

    public class VTypeVoid : VType
    {
        public VTypeVoid() : base("void") { }
    }

    public class VTypeString : VType
    {
        public VTypeString() : base("string") { }
    }

    public class VTypeStringC : VTypeString
    {
        public VTypeStringC() : base() { }
    }

    public class VTypeStringV : VTypeString
    {
        public int capacity;
        public VTypeStringV(int cap) : base()
        {
            this.capacity = cap;
        }
    }
    public class VTypeFunction : VType
    {
        public VTypeFunction() : base("function") { }
    }

    public class VarLocation
    {
    }

    public class FunctionLocation : VarLocation
    {
        public string label;
        public FunctionLocation(string lbl)
        {
            this.label = lbl;
        }
    }

    class VarInfo
    {
        public VType type;
        public int declaredLine;        //optional
        public VarLocation location;
        public VarInfo(VType t, int decl, VarLocation loc)
        {
            type = t;
            declaredLine = decl;
            this.location = loc;
        }
    }
}
