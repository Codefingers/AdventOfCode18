using Xunit;

namespace UnitTest.Day5
{
    public class Day5Test
    {
        [Fact]
        public void testRunTest()
        {
            AdventOfCode18.Day5.Day5 day5 = new AdventOfCode18.Day5.Day5();

            Assert.Equal(6, day5.runTest("Day5/Day5.txt"));
        }
    }
}