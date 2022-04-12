using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DieAveraging.Selections;
namespace DieAveraging.Selections
{
    class FighterSelections:ClassSelections
    {
        public enum FightingStyles { Archery, Dueling, GreatWeaponFighting, TwoWeaponFighting };
        public FightingStyles fightingStyle;
    }
}
