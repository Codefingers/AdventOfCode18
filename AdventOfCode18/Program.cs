using System;

namespace AdventOfCode18
{
    class Program
    {
        static void Main(string[] args)
        {
            Day8 day8 = new Day8();
            int day8Total = day8.runTest();

            Console.WriteLine(day8Total);
            Console.ReadLine();
        }
    }
}