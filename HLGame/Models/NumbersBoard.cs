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
        public NumbersBoard() {
        }
        public NumbersBoard(INumberGenerator Generator)
        {
            generator = Generator;
            Numbers = Generate();
            RevealedNumbers = new List<int>();
            RevealedNumbers.Add(Numbers[0]);
        }

        public NumbersBoard(int[] numbers, int Score)
        {
            this.Numbers = numbers;
            RevealedNumbers = Numbers.ToList().Take(Score).ToList();
        }

        private int[] Generate()
        {
            if (generator == null)
                throw new Exception("no generator supplied");

            return generator.Generate(_numberOfRounds);
        }

        public int NextNumber()
        {
            if ((RevealedNumbers.Count) >= Numbers.Length)
                return -1;

            return Numbers[RevealedNumbers.Count];

        }

        public bool MoveToNextNumber()
        {
            var nextNumber = NextNumber();
            if (nextNumber == -1)
                return false;

            RevealedNumbers.Add(nextNumber);

            return true;
        }

        public int CurrentNumber()
        {
            return RevealedNumbers.Last();
        }
    }

    public class HiLoNumbersBoard : NumbersBoard
    {
        public HiLoNumbersBoard(){ }
        public HiLoNumbersBoard(INumberGenerator generator) : base(generator)
        {

        }

        public HiLoNumbersBoard(int[] numbers, int index) : base(numbers, index)
        {

        }

    }
}
