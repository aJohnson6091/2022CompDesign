using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieAveraging.Features.ClassFeatures.FighterFeatures
{
    class ActionSurge: ClassFeature
    {
        public override void AddBonusToCharacter(Character character)
        {
            character.numberOfAttacks *= 2;
        }
    }
}
