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
        public void HiLoGame_NumberBoard_Should_Change_On_Correct_Answer()
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

        [Fact]
        public void HiLoGame_NumberBoard_All_Correct_Answers()
        {
            var Board = new HiLoNumbersBoard(NumberGenerator);
            var Game = new HiLoGuessGame(dbContext, Board);


            for (int i = 0; i <= NumberOfRounds; i++)
            {
                Assert.True(Game.Guess(Game.NumbersBoard.NextNumber() > Game.NumbersBoard.CurrentNumber()));
            }
        }

        [Fact]
        public void HiLoGame_NumberBoard_Guess_Some_Answers()
        {
            var Board = new HiLoNumbersBoard(NumberGenerator);
            var Game = new HiLoGuessGame(dbContext, Board);
            var random = new Random();
            var triesbeforefail = random.Next(1, 9);
            for (int i = 0; i < NumberOfRounds; i++)
            {
                if (i == triesbeforefail)
                {
                    Assert.False(Game.Guess(Game.NumbersBoard.NextNumber() < Game.NumbersBoard.CurrentNumber()));
                    return;
                }
                else
                {
                    Assert.True(Game.Guess(Game.NumbersBoard.NextNumber() > Game.NumbersBoard.CurrentNumber()));
                }
            }
        }


    }
}
