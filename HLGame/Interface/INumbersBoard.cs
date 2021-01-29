using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLGame.Interface
{
    public interface INumbersBoard
    {
        int[] Numbers { get; set; }
        List<int> RevealedNumbers { get; set; }

        int CurrentNumber();
        bool MoveToNextNumber();
        int NextNumber();

    }
}
