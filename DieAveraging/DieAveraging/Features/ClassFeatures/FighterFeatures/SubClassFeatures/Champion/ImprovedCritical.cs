using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieAveraging.Features.ClassFeatures.FighterFeatures.SubClassFeatures.Champion
{
    class ImprovedCritical:ClassFeature
    {
        public override void AddBonusToAttack(Attack attack)
        {
            attack.hitDie.critValues.Append(19);
        }
    }
}
