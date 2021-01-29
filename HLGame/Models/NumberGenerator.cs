using HLGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLGame.Models
{
    public class NumberGenerator_RandomNumbers_DifferFromPrevious : INumberGenerator
    {
        public NumberGenerator_RandomNumbers_DifferFromPrevious() { }
        public int[] Generate(int Count)
        {
            int[] returnNumbers = new int[Count];

            int lastNumber = -1;
            Random rnd = new Random();

            for (int i = 0; i < Count;i++)
            {
                int number = rnd.Next(0, 100);

                // number differs add to array
                if (number != lastNumber)
                {
                    lastNumber = number;
                    returnNumbers[i] = number;
                }
                else
                {
                    //repeat the same iteration again
                    i--;
                }
            }

            return returnNumbers;

            
            
        }
    }
}
