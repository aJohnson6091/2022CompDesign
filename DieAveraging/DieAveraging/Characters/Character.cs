using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieAveraging
{
    abstract class Character
    {
        public int armorClass;
        public List<Attack> attacks = new List<Attack>();
        public List<Feature> features = new List<Feature>();
        public int numberOfActions;
        public int numberOfAttacks;
    }
}
