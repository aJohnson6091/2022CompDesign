using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAndFollow
{
    class OutputObject
    {
        public Dictionary<string, HashSet<string>> first = new Dictionary<string, HashSet<string>>();
        public Dictionary<string, HashSet<string>> follow = new Dictionary<string, HashSet<string>>();
    }
}
