using HLGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLGame.Models
{
    public class DbContext : IDBContext
    {
        public IGame GetGame(int ID)
        {
            throw new NotImplementedException();
        }

        public IHighScore[] GetHighScores()
        {
            throw new NotImplementedException();
        }

        public bool SaveGame()
        {
            throw new NotImplementedException();
        }

        public bool SaveHighScore()
        {
            throw new NotImplementedException();
        }
    }
}
