using System;
using System.Collections.Generic;

namespace AdventOfCode18
{
    public class Day3
    {
        public int runTest()
        {
            return getTotal();
        }

        private int getTotal()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day3.txt");
            Dictionary<string, int> idToCount = new Dictionary<string, int>();
            Dictionary<string, string> coordToId = new Dictionary<string, string>();
            
            int[,] sheet = new int[3000,3000];
            int totalCount = 0;
            List<int> noLaps = new List<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                var result = lines[i].Split(new [] {" "}, StringSplitOptions.None);

                var rectangle = result[2].Split(new [] {","}, StringSplitOptions.None);
                var fromLeft = int.Parse(rectangle[0]);
                var fromTop = int.Parse(rectangle[1].Remove(rectangle[1].Length - 1));

                var claimedWidth = result[3].Split(new [] {"x"}, StringSplitOptions.None);
                var width = int.Parse(claimedWidth[0]);
                var height = int.Parse(claimedWidth[1]);

                var id = result[0].Remove(0, 1);
                idToCount.Add(id, 0);
                
                
                noLaps.Add(int.Parse(id));
                for (int x = fromTop; x < fromTop + height; x++)
                {
                    for (int y = fromLeft; y < fromLeft + width; y++)
                    {
                        if (sheet[x, y] > 0)
                        {
                            if (coordToId.ContainsKey(x.ToString() + "," + y.ToString()))
                            {
                                var previousId = "";
                                coordToId.TryGetValue(x.ToString() + "," + y.ToString(), out previousId);
                                noLaps.Remove(int.Parse(id));
                                noLaps.Remove(int.Parse(previousId));
                            }
                            
                            totalCount++;
                            sheet[x, y]++;

                            idToCount[id]++;

//                            foreach (KeyValuePair<string, string> row in coordToId)
//                            {
//                                if (row.Key == x.ToString() + "," + y.ToString())
//                                {
//                                    idToCount[row.Value]++;
//                                }
//                            }

                            continue;
                        }

                        coordToId.Add(x.ToString() + "," + y.ToString(),id);
                        sheet[x, y]++;
                    }
                }
            }

//            foreach (KeyValuePair<string, int> anotherRow in idToCount)
//            {
//                if (anotherRow.Value == 0)
//                {
//                    return int.Parse((anotherRow.Key));
//                }
//            }
          
            return totalCount;
        }
    }
}