using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HLGame.Interface.IGameState;

namespace HLGame.Interface
{
    public interface IGameState
    {
        public enum eState { Unknown = 0, Active = 1, GameOver = 2, Success = 3 }
    }

    public interface IGame
    {
        
        public IUser User { get; set; }
        public int ID { get; set; }
        public int[] Numbers { get; set; }
        public int Score { get; set; }

        public INumbersBoard NumbersBoard { get; }

        
    }




}
