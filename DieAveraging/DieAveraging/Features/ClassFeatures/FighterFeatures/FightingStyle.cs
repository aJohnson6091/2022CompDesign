using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DieAveraging.PlayerClasses;
using DieAveraging.Selections;

namespace DieAveraging.Features.ClassFeatures.FighterFeatures
{
    class FightingStyle : ClassFeature
    {
        FighterSelections.FightingStyles fightingStyle;

        public FightingStyle(FighterSelections.FightingStyles fightingStyle)
        {
            this.fightingStyle = fightingStyle;
        }

        public override void AddBonusToAttack(Attack attack)
        {
            switch (fightingStyle)
            {
                case FighterSelections.FightingStyles.Archery:
                    //Add 2 to the hit modifier
                    if(attack.attackProperties.Contains(Attack.AttackProperties.Ranged))
                    {
                        attack.hitModifier += 2;
                    }
                    break;
                case FighterSelections.FightingStyles.Dueling:
                    //Add 2 to the damage modifier
                    if (attack.attackProperties.Contains(Attack.AttackProperties.SingleHanded))
                    {
                        attack.damageModifier += 2;
                    }
                    break;
                case FighterSelections.FightingStyles.GreatWeaponFighting:
                    //Add 1 and 2 for rerolls on the damage Die
                    if (attack.attackProperties.Contains(Attack.AttackProperties.TwoHanded))
                    {
                        foreach(Die d in attack.damageDice)
                        {
                           
                            d.reroll.Add(1);
                            d.reroll.Add(2);
                        }
                    }
                    break;
                case FighterSelections.FightingStyles.TwoWeaponFighting:
                    break;
            }
        }
    }
}
