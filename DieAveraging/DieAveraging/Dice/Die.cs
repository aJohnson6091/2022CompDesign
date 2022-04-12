using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieAveraging
{
    class Die
    {
        public int maxRoll;
        public int minRoll;
        private double rawAverage;
        public List<int> reroll = new List<int>();
        public List<int> additiveReroll = new List<int>();
        public List<int> critValues = new List<int>();
        public List<int> failValues = new List<int>();

        public Die(int minRoll, int maxRoll)
        {
            this.maxRoll = maxRoll;
            this.minRoll = minRoll;
            reroll = new List<int>();
            critValues = new List<int>();
            rawAverage = ((double)maxRoll + minRoll)/2;
        }

        public double AverageRoll(bool usingReroll, bool usingAdditiveReroll)
        {
            List<double> valueList = new List<double>();
            List<int> exclusionList = new List<int>();
            if (usingAdditiveReroll)
            {
                for (int i = minRoll; i <= maxRoll; i++)
                {
                    if (additiveReroll.Contains(i))
                    {
                        //This is assuming one layer of rerolls allowed
                        valueList.Add(i + rawAverage);
                        exclusionList.Add(i);
                    }
                    else
                    {
                        valueList.Add(i);
                    }
                }
            }
            if (usingReroll)
            {
                for (int i = minRoll; i <= maxRoll; i++)
                {
                    if (!exclusionList.Contains(i))
                    {
                        if (reroll.Contains(i))
                        {
                            valueList.Add(rawAverage);
                        }
                        else
                        {
                            valueList.Add(i);
                        }
                    }
                }
            }
            return valueList.Sum() / valueList.Count;
        }

    }
}
