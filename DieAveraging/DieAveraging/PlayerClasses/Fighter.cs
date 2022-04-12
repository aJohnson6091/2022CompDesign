using DieAveraging.Characters;
using DieAveraging.Selections;
using DieAveraging.Features.ClassFeatures.FighterFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DieAveraging.Features.ClassFeatures;

namespace DieAveraging.PlayerClasses
{
    class Fighter : PlayerClass
    {
        int level;
        FighterSelections fighterSelections;

        public Fighter(int level, FighterSelections selections)
        {
            this.level = level;
            fighterSelections = selections;
            playerClassType = PlayerClassType.Fighter;
        }

        public override void LevelUpClass(PlayerCharacter character)
        {
            this.level++;
            if(level == 2)
            {

            }
        }
        public override void AddFeaturesToCharacter(Character c)
        {
            //Level 1 Add FightingStyle
            
            c.features.Add(new FightingStyle(fighterSelections.fightingStyle));
            if(this.level >= 2)
            {
                c.features.Add(new ActionSurge());
            }
            if(this.level >= 5)
            {
                if(c.numberOfAttacks <= 1)
                {
                    c.numberOfAttacks += 1;
                }
            }
            if (this.level >= 11)
            {
                if (c.numberOfAttacks <= 2)
                {
                    c.numberOfAttacks += 1;
                }
            }
            if (this.level >= 20)
            {
                if (c.numberOfAttacks <= 3)
                {
                    c.numberOfAttacks += 1;
                }
            }
        }
    }
}
