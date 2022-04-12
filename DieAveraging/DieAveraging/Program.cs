using DieAveraging.Characters;
using DieAveraging.CombatSimulator;
using DieAveraging.PlayerClasses;
using DieAveraging.Selections;
using System;
using System.Collections.Generic;

namespace DieAveraging
{
    class Program
    {
        static void Main(string[] args)
        {
            Die d = new Die(1,12);
            d.additiveReroll.Add(1);
            d.additiveReroll.Add(2);
            Console.WriteLine(d.AverageRoll(true,true));
        }
    }
}
