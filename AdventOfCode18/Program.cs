using System;

namespace AdventOfCode18
{
    class Program
    {
        static void Main(string[] args)
        {
            Day3 day3 = new Day3();
            int day3Total = day3.runTest(@"Day3.txt");

            Console.WriteLine(day3Total);
            Console.ReadLine();
        }
    }
}