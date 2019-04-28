using Xunit;

namespace UnitTest.Day3
{
    public class Day3Test
    {
        [Fact]
        public void testRunTest()
        {
            AdventOfCode18.Day3.Day3 day3 = new AdventOfCode18.Day3.Day3();

            Assert.Equal(day3.runTest("Day3/Day3.txt"), 4);
        }
    }
}