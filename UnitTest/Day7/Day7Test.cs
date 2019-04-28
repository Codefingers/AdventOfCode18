using Xunit;

namespace UnitTest.Day7
{
    public class Day7Test
    {
        [Fact]
        public void testRunTest()
        {
            AdventOfCode18.Day7.Day7 day7 = new AdventOfCode18.Day7.Day7();

            Assert.Equal(253, day7.getTotal("Day7/Day7.txt"));
        }
    }
}