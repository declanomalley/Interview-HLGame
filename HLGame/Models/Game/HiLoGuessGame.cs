using HLGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLGame.Models.Game
{
    public class HiLoGuessGame : GuessGame<bool>
    {
        public HiLoGuessGame() { }
        public HiLoGuessGame(IDBContext db, INumbersBoard board) : base(db, board) { }

        public HiLoGuessGame(IDBContext db, INumbersBoard board, int id) : base(db, board, id) { }

        public override bool Guess(bool Higher)
        {
            var currentNumber = NumbersBoard.CurrentNumber();
            var nextNumber = NumbersBoard.NextNumber();

            bool correct = false;
            if (Higher && currentNumber < nextNumber)
            {
                correct = true;
            }
            else if (!Higher && currentNumber > nextNumber)
            {
                correct = true;
            }

            ValidateAnswer(correct);


            return correct;
        }
    }
}
