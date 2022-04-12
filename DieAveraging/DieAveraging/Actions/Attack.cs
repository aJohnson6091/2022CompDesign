using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieAveraging
{
    class Attack : Action
    {
        public enum AttackProperties {Ranged, SingleHanded, DualWeilding, TwoHanded }

        public Die hitDie;
        public int hitModifier;
        public List<Die> damageDice = new List<Die>();
        public int damageModifier;
        public AttackProperties[] attackProperties;

        public Attack(Die hitDie, int hitModifier, List<Die> damageDice, int damageModifier)
        {
            this.hitDie = hitDie;
            this.hitModifier = hitModifier;
            this.damageDice = damageDice;
            this.damageModifier = damageModifier;
        }

        public int calculateMaxDamage(int hitValue)
        {
            int damage = 0;
            if (this.hitDie.critValues.Contains(hitValue))
            {
                foreach(Die d in damageDice)
                {
                    damage += d.maxRoll*2;
                }
            }
            else
            {
                foreach (Die d in damageDice)
                {
                    damage += d.maxRoll;
                }
            }
            return damage+damageModifier;
        }
        public int calculateMinDamage(int hitValue)
        {
            int damage = 0;
            if (this.hitDie.critValues.Contains(hitValue))
            {
                foreach (Die d in damageDice)
                {
                    damage += d.minRoll * 2;
                }
            }
            else
            {
                foreach (Die d in damageDice)
                {
                    damage += d.minRoll;
                }
            }
            return damage + damageModifier;
        }
        public int calculateAverageDamage(int hitValue)
        {
            int damage = 0;
            if (this.hitDie.critValues.Contains(hitValue))
            {
                foreach (Die d in damageDice)
                {
                    damage += ((d.maxRoll+d.minRoll)/2)* 2;
                }
            }
            else
            {
                foreach (Die d in damageDice)
                {
                    damage += ((d.maxRoll + d.minRoll) / 2);
                }
            }
            return damage + damageModifier;
        }
        public int calculateRandomDamage(int hitValue)
        {
            int damage = 0;
            Random rd = new Random();
            if (this.hitDie.critValues.Contains(hitValue))
            {
                foreach (Die d in damageDice)
                {
                    damage += rd.Next(d.minRoll,d.maxRoll) * 2;
                }
            }
            else
            {
                foreach (Die d in damageDice)
                {
                    damage += rd.Next(d.minRoll, d.maxRoll);
                }
            }
            return damage + damageModifier;
        }

    }
}
