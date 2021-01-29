using HLGame.Interface;
using HLGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HLGame_Test
{
    public class HiLoNumberBoardTests
    {
        INumberGenerator generator;
        private const int NumberOfRounds = 10;

        

        [Fact]
        public void HiLoNumberBoard_Has_Numbers_Generated()
        {
            var board = new HiLoNumbersBoard(generator);

            Assert.True(board.Numbers.Length > 0);
        }

       
    }
}
