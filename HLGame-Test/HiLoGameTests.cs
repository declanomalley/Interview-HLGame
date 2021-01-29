using HLGame.Interface;
using HLGame.Models;
using HLGame.Models.Game;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HLGame_Test
{
    public class HiLoGameTests
    {


        TestDBContextHiLoGuessGame dbContext;
        NumberGenerator_RandomNumbers_DifferFromPrevious NumberGenerator;
        private const int NumberOfRounds = 10;

        public HiLoGameTests()
        {
            
            NumberGenerator = new NumberGenerator_RandomNumbers_DifferFromPrevious();
            var board = new HiLoNumbersBoard(NumberGenerator);
            dbContext = new TestDBContextHiLoGuessGame(board);
        }


        [Fact]
        public void HiLoGame__NumberBoard_Should_Change_On_Correct_Answer()
        {
            bool validated = false;
            
            

            while (!validated)
            {
                var board = new HiLoNumbersBoard(NumberGenerator);
                var Game = new HiLoGuessGame(dbContext, board);
                var previousNumber = Game.NumbersBoard.CurrentNumber();
                // wrong guess
                if (!Game.Guess(true))
                {
                    // guessing moves to the next number so you can see what the number was
                    Assert.True(previousNumber > Game.NumbersBoard.CurrentNumber());

                }
                else
                {
                    validated = true;
                }
            }
        }

    
    }
}
