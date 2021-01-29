using HLGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLGame.Models
{
    public class HighScore : IHighScore
    {
        public int GameID { get; set ; }
        public string Name { get ; set ; }
        public TimeSpan Time { get ; set ; }
        public int Score { get ; set ; }
    }
}
