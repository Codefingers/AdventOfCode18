using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode18.Day10
{
    public class Day10
    {
        public int getTotal(string file)
        {
            string[] lines = System.IO.File.ReadAllLines(file);

            List<Point> points = new List<Point>();
            for (int i = 0; i < lines.Length; i++)
            {
                MatchCollection matches = Regex.Matches(lines[i], @"-?\d+");
                Point point = new Point(
                    Int32.Parse(matches[0].ToString()),
                    Int32.Parse(matches[1].ToString()),
                    Int32.Parse(matches[2].ToString()),
                    Int32.Parse(matches[3].ToString())
                );

                points.Add(point);
            }

            points = points.OrderBy(point => point.x).ThenBy(point => point.y).ToList();
            
            int[][] grid = new int[points.Max(point => point.x)][];

            return 0;
        }
    }
}