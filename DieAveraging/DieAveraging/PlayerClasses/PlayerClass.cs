using DieAveraging.Characters;
using DieAveraging.PlayerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieAveraging
{
    abstract class PlayerClass
    {
        public enum PlayerClassType{Fighter};

        public int classLevel;
        public PlayerClassType playerClassType;
        public abstract void LevelUpClass(PlayerCharacter character);
        public abstract void AddFeaturesToCharacter(Character c);
    }
}
