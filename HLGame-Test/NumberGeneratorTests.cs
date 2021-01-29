using HLGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HLGame_Test
{
    public class NumberGenerator__RandomNumbers_DifferFromPrevious_Tests
    {
        [Fact]
        public void Has_Enough_Numbers()
        {
            var generator = new NumberGenerator_RandomNumbers_DifferFromPrevious();
            var numbers = generator.Generate(10);

            Assert.Equal(10,numbers.Length);
        }

       
    }
}
