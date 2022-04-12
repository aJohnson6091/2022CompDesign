using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieAveraging.CombatSimulator
{
    class SimResults
    {
        //Inner most list is the attacks for a single attack
        //Second Inner list contains all the attacks with multiattack
        //Outter list contains all the varying types of attacks(different weapons)
        List<List<List<int>>> AllAttackActions;
        
    }
}
