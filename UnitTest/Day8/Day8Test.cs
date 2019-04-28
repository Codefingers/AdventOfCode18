using Xunit;

namespace UnitTest.Day8
{
    public class Day8Test
    {
        [Fact]
        public void testGetTotal()
        {
            AdventOfCode18.Day8.Day8 day8 = new AdventOfCode18.Day8.Day8();

            Assert.Equal(138, day8.getTotal("Day8/Day8.txt"));
        }

        [Fact]
        public void testGetTotalPart2()
        {
            AdventOfCode18.Day8.Day8 day8 = new AdventOfCode18.Day8.Day8();

            Assert.Equal(66, day8.getTotalPart2("Day8/Day8.txt"));
        }
    }
}