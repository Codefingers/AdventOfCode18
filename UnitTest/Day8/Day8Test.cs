using Xunit;

namespace UnitTest.Day8
{
    public class Day8Test
    {
        [Fact]
        public void testRunTest()
        {
            AdventOfCode18.Day8.Day8 day8 = new AdventOfCode18.Day8.Day8();

            Assert.Equal(138, day8.getTotal("Day8/Day8.txt"));
        }
    }
}