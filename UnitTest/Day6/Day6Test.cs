using Xunit;

namespace UnitTest.Day6
{
    public class Day6Test
    {
        [Fact]
        public void testRunTest()
        {
            AdventOfCode18.Day6.Day6 day6 = new AdventOfCode18.Day6.Day6();

            Assert.Equal(17, day6.getTotal("Day6/Day6.txt"));
        }
    }
}