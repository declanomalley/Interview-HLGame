using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HLGame.Interface.IGameState;

namespace HLGame.Interface
{
    public interface IGuess<AnswerType>
    {
        public bool Guess(AnswerType Higher);
        public bool End(eState state);
    }
}
