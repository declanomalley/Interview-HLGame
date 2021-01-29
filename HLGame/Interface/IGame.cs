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

        int ID { get; set; }
        string Name { get; set; }
        int[] Numbers { get; set; }
        INumbersBoard NumbersBoard { get; set; }
        int Score { get; set; }

        bool End(eState state);


    }




}
