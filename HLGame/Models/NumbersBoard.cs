using HLGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLGame.Models
{


    public abstract class NumbersBoard : INumbersBoard
    {
        private INumberGenerator generator;
        private const int _numberOfRounds = 10;

        public int[] Numbers { get; set; }

        public List<int> RevealedNumbers { get; set; }

        public NumbersBoard(INumberGenerator Generator)
        {
            generator = Generator;
            Numbers = Generate();
            RevealedNumbers = new List<int>();
            RevealedNumbers.Add(Numbers[0]);
        }

        private int[] Generate()
        {
            if (generator == null)
                throw new Exception("no generator supplied");

            return generator.Generate(_numberOfRounds);
        }

      
    }

    public class HiLoNumbersBoard : NumbersBoard
    {

        public HiLoNumbersBoard(INumberGenerator generator) : base(generator)
        {

        }



    }
}
