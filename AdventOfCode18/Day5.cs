using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode18
{
    public class Day5
    {
        public int runTest()
        {
            return getTotal();
        }

        private int getTotal()
        {
            string[] alphabet = new string[]
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g",
                "h",
                "i",
                "j",
                "k",
                "l",
                "m",
                "n",
                "o",
                "p",
                "q",
                "r",
                "s",
                "t",
                "u",
                "v",
                "w",
                "x",
                "y",
                "z",
            };
            string[] linesOriginal = System.IO.File.ReadAllLines(@"Day5.txt");
            int totalRemoved = linesOriginal[0].Length;
            string shortestPolymer = "";

            for (int k = 0; k < alphabet.Length; k++)
            {
                string[] lines = System.IO.File.ReadAllLines(@"Day5.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    int removed = 1;
                    while (removed > 0)
                    {
                        removed = 0;
                        for (int x = 0; x < lines[i].Length; x++)
                        {
                            if (lines[i][x].ToString().ToLower() == alphabet[k])
                            {
                                lines[i] = lines[i].Remove(x, 1);
                                x--;
                                continue;
                            }
                            
                            if (lines[i].Length > x + 1)
                            {
                                if (lines[i][x + 1] == lines[i][x])
                                {
                                    continue;
                                }

                                if (lines[i][x + 1].ToString().ToLower().Equals(lines[i][x].ToString().ToLower()))
                                {
                                    lines[i] = lines[i].Remove(x, 2);
                                    x--;
                                    removed++;
                                }
                            }
                        }
                    }

                    if (lines[i].Length < totalRemoved)
                    {
                        totalRemoved = lines[i].Length;
                        shortestPolymer = lines[i];
                    }
                }
            }

            return totalRemoved;
        }
    }
}