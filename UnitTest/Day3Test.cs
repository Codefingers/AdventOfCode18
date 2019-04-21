using System;
using AdventOfCode18;
using Xunit;

namespace UnitTest
{
    public class Day3Test
    {
        [Fact]
        public void testRunTest()
        {
            Day3 day3 = new Day3();

            Assert.Equal(day3.runTest("Day3.txt"), 4);
        }
    }
}