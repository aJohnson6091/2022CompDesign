using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieAveraging.CombatSimulator
{
    class CombatSim
    {
        public List<List<int>> CalculateCharacterAttacks(Character attacker, Character defender)
        {
            List<List<int>> returnList = new List<List<int>>();
            foreach(Attack attack in attacker.attacks)
            {
                returnList.Add(CalculateAverageAttackArray(attack, defender));
            }

            return null;
        }


        public List<int> CalculateAverageAttackArray(Attack attack, Character defendingCharacter)
        {
            List<int> damageList = new List<int>();
            for(int i = attack.hitDie.minRoll; i<=attack.hitDie.maxRoll; i++)
            {
                if (attack.hitDie.critValues.Contains(i))
                {
                    damageList.Add(attack.calculateAverageDamage(i));
                }
                else if (i > defendingCharacter.armorClass - attack.hitModifier) 
                {
                    damageList.Add(attack.calculateAverageDamage(i));
                }
                else
                {
                    damageList.Add(0);
                }
            }
            return damageList;
        }
    }
}
