using System;

namespace AdventOfCode18
{
    class Program
    {
        static void Main(string[] args)
        {
            Day8.Day8 day8 = new Day8.Day8();
            int total = day8.getTotal("Day8/Day8Test.txt");

            Console.WriteLine(total);
            Console.ReadLine();
        }
    }
}