using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLGame.Interface
{
    public interface IHighScore
    {
        public int GameID { get; set; }
        public int Name { get; set; }
        public TimeSpan Time { get; set; }
        public int Score { get; set; }
    }
}
