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

            points = points.OrderBy(point => point.y).ThenBy(point => point.x).ToList();

            int minX = points.Min(point => point.x);
            int maxX = points.Max(point => point.x);
            int minY = points.Min(point => point.y);
            int maxY = points.Max(point => point.y);

            // loop through time
            for (int seconds = 0; seconds < 3; seconds++)
            {
                int tmpMinX = 0;
                int tmpMaxX = 0;
                int tmpMinY = 0;
                int tmpMaxY = 0;
                List<Point> tmpPoints = new List<Point>();

                // loop through Y axis
                for (int y = minY; y <= maxY; y++)
                {
                    // loop through X axis
                    for (int x = minX; x <= maxX; x++)
                    {
                        bool match = false;
                        // attempt to find a match in the list of given points
                        foreach (Point point in points)
                        {
                            if (point.x == x && point.y == y)
                            {
                                if (point.x + point.xVelocity > maxX)
                                {
                                    tmpMaxX = x + point.xVelocity;
                                }

                                if (point.x + point.xVelocity < minX)
                                {
                                    tmpMinX = x + point.xVelocity;
                                }

                                if (point.y + point.yVelocity > maxY)
                                {
                                    tmpMaxY = y + point.yVelocity;
                                }

                                if (point.y + point.yVelocity > maxY)
                                {
                                    tmpMaxY = y + point.yVelocity;
                                }

                                match = true;
                                tmpPoints.Add(
                                    new Point(
                                        x + point.xVelocity,
                                        y + point.yVelocity,
                                        x,
                                        y
                                    )
                                );
                            }
                        }

                        if (match)
                        {
                            Console.Write("#");
                            continue;
                        }

                        Console.Write(".");
                    }

                    Console.WriteLine();
                }

                // set new bounds
                minX = tmpMinX;
                maxX = tmpMaxX;
                minY = tmpMinY;
                maxY = tmpMaxY;
                points = tmpPoints;

                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine();
            }

            return 0;
        }
    }
}