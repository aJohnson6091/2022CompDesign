using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieAveraging
{
    abstract class Feature
    {
        public virtual void AddBonusToAttack(Attack attack) { }
        public virtual void AddBonusToCharacter(Character character) { }

    }
}
