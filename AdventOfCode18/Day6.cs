using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode18
{
    public class Day6
    {
        public int runTest()
        {
            return getTotal();
        }

        private int getTotal()
        {
            string[] linesOriginal = System.IO.File.ReadAllLines(@"Day6.txt");
            Dictionary<(int, int), int> coords = new Dictionary<(int, int), int>();

            int maxX = 0;
            int maxY = 0;
            for (int i = 0; i < linesOriginal.Length; i++)
            {
                string[] parts = linesOriginal[i].Split(',');
                int y = int.Parse(parts[0]);
                int x = int.Parse(parts[1]);

                coords[(x, y)] = i+1;

                if (x > maxX)
                {
                    maxX = x;
                }
                
                if (y > maxY)
                {
                    maxY = y;
                }
            }

            string mapInString = "";
            maxX = maxX > maxY ? maxX+1 : maxY+1;
            maxY = maxX;
            int[,] map = new int[maxX,maxY];
            Dictionary<int, int> coordCount = new Dictionary<int, int>();
            List<int> numbersOnEdge = new List<int>();
            int regionSize = 10000;
            int numberOfCoordinates = 0;

            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    int distanceFromCoord = 999999;
                    int coordToSet = 1;
                    int totalDistance = 0;
                    Dictionary<int, bool> distanceEqual = new Dictionary<int, bool>();
                    foreach (KeyValuePair<(int, int), int> coord in coords)
                    {
                        int distanceFromPoint = Math.Abs(coord.Key.Item1 - x) + Math.Abs(coord.Key.Item2 - y);
                        totalDistance += distanceFromPoint;
                        if (distanceFromPoint < distanceFromCoord)
                        {
                            distanceFromCoord = distanceFromPoint;
                            coordToSet = coord.Value;
                        }
                        
                        if (distanceEqual.ContainsKey(distanceFromPoint))
                        {
                            distanceEqual[distanceFromPoint] = true;
                            continue;
                        }

                        distanceEqual.Add(distanceFromPoint, false);
                    }
                    if (totalDistance < 10000)
                    {
                        numberOfCoordinates++;
                    }
                    
                    if (distanceEqual[distanceFromCoord])
                    {
                        coordToSet = 0;
                    }

                    map[x, y] = coordToSet;
                    mapInString += coordToSet + ",";
                    
                    // if on edge 
                    if (x == 0 || x == maxX - 1 || y == 0 || y == maxY - 1)
                    {
                        numbersOnEdge.Add(coordToSet);
                        continue;
                    }

                    if (numbersOnEdge.Contains(coordToSet))
                    {
                        continue;
                    }

                    int total = 0;
                    if (coordCount.ContainsKey(coordToSet))
                    {
                        total = coordCount[coordToSet];
                        coordCount[coordToSet] = total+1;
                    }
                    else
                    {
                        coordCount.Add(coordToSet, total+1);
                    }
                }

                mapInString += "\n";
            }

            var max = coordCount.Values.Max();
            
            return 0;
        }
    }
}