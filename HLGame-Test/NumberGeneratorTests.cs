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


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void Numbers_Differ(int Count)
        {
            var generator = new NumberGenerator_RandomNumbers_DifferFromPrevious();
            var numbers = generator.Generate(Count);

            var previousnumber = -1;
            foreach (var number in numbers)
            {
                Assert.NotEqual(previousnumber, number);
                previousnumber = number;
            }
        }


    }
}
