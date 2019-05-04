using Xunit;

namespace UnitTest.Day9
{
    public class Day9Test
    {
        [Fact]
        public void testGetTotal()
        {
            AdventOfCode18.Day9.Day9 day9 = new AdventOfCode18.Day9.Day9();

            Assert.Equal(8317, day9.getTotal("Day9/Day9.txt"));
        }
    }
}