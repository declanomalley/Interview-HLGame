using HLGame.Interface;
using HLGame.Models;
using HLGame.Models.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLGame_Test
{
    public class TestDBContextHiLoGuessGame : IDBContext
    {
        public TestDBContextHiLoGuessGame() { }
        public TestDBContextHiLoGuessGame(INumbersBoard board)
        {
            Board = board;
        }

        INumbersBoard Board;

        public IGame GetGame(int ID)
        {
            return new HiLoGuessGame(new TestDBContextHiLoGuessGame(), Board);
        }

        public IHighScore[] GetHighScores()
        {
            return new List<IHighScore>().ToArray();
        }

        public bool SaveGame()
        {
            return true;
        }

        public bool SaveHighScore()
        {
            return true;
        }
    }
}
