using System;

namespace AdventOfCode18
{
    class Program
    {
        static void Main(string[] args)
        {
            Day10.Day10 day9 = new Day10.Day10();
            long total = day9.getTotal("Day10/Day10Test.txt");

            Console.WriteLine(total);
            Console.ReadLine();
        }
    }
}