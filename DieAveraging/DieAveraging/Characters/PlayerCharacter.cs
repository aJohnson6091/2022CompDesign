using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieAveraging.Characters
{
    class PlayerCharacter:Character
    {
        List<PlayerClass> playerClasses = new List<PlayerClass>();

        public PlayerCharacter()
        {
            armorClass = 0;
        }
        
        public bool AddPlayerClass(PlayerClass pc)
        {
            //Check to see if there are any other classes of same type
            foreach(PlayerClass currentClass in playerClasses)
            {
                if(currentClass.playerClassType == pc.playerClassType)
                {
                    return false;
                }
            }
            playerClasses.Add(pc);
            return true;
        }
        
        void AddClassFeatures()
        {
            foreach(PlayerClass pc in playerClasses)
            {
                pc.AddFeaturesToCharacter(this);
            }
        }

        public void AddFeatureBonuses()
        {
            foreach(Feature f in features)
            {
                f.AddBonusToCharacter(this);
            }
        }

        public void AddAttack(Attack attack)
        {
            foreach (Feature f in features)
            {
                f.AddBonusToAttack(attack);
            }
            attacks.Add(attack);
        }
    }
}
