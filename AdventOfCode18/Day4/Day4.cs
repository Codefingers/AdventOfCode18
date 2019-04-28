using System;
using System.Collections.Generic;

namespace AdventOfCode18.Day4
{
    public class Day4
    {
        public int runTest()
        {
            return getTotal();
        }

        private int getTotal()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day4.txt");
            SortedList<DateTime, string> sortedList = new SortedList<DateTime, string>();
            SortedList<int, int> guardSleep = new SortedList<int, int>();
            Dictionary<int, Dictionary<int, int>> guardToMinutes = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i < lines.Length; i++)
            {
                var start = lines[i].IndexOf("[") + 1;
                var end = lines[i].IndexOf("]", start);
                var result = lines[i].Substring(start, end - start);
                var resultSplit = result.Split(" ");

                var dateSplit = resultSplit[0].Split("-");
                var timeSplit = resultSplit[1].Split(":");

                DateTime dateTime = getDate(
                    int.Parse(dateSplit[0]),
                    int.Parse(dateSplit[1]),
                    int.Parse(dateSplit[2]),
                    int.Parse(timeSplit[0]),
                    int.Parse(timeSplit[1])
                );

                sortedList.Add(dateTime, lines[i]);
            }

            int lastGuard = 0;
            DateTime startDateTime = new DateTime();
            foreach (KeyValuePair<DateTime, string> row in sortedList)
            {
                if (row.Value.Contains("begins"))
                {
                    int startOfGuardId = row.Value.IndexOf('#') + 1;
                    int endOfGuardId = row.Value.IndexOf("begins") - 1;
                    lastGuard = int.Parse(row.Value.Substring(startOfGuardId, endOfGuardId - startOfGuardId));
                }

                if (row.Value.Contains("falls"))
                {
                    startDateTime = row.Key;
                    continue;
                }

                if (row.Value.Contains("wakes"))
                {
                    for (int i = startDateTime.Minute; i < row.Key.Minute; i++)
                    {
                        if (!guardToMinutes.ContainsKey(lastGuard))
                        {
                            guardToMinutes.Add(lastGuard, new Dictionary<int, int>());
                        }
                        else
                        {
                            var dictionary = guardToMinutes[lastGuard];
                            if (dictionary.ContainsKey(i))
                            {
                                dictionary[i]++;
                            }
                            else
                            {
                                dictionary.Add(i, 1);
                            }
                        }
                    }


                    double diff = (row.Key - startDateTime).TotalMinutes;
                    if (!guardSleep.ContainsKey(lastGuard))
                    {
                        guardSleep.Add(lastGuard, Convert.ToInt32(diff));
                        continue;
                    }

                    guardSleep[lastGuard] += Convert.ToInt32(diff);
                }
            }

            var guardToFind = 0;
            var lastVal = 0;
            foreach (KeyValuePair<int, int> row in guardSleep)
            {
                if (row.Value > lastVal)
                {
                    lastVal = row.Value;
                    guardToFind = row.Key;
                }
            }

            var minuteToCalc = 0;
            var lastValMin = 0;
            foreach (KeyValuePair<int, int> row in guardToMinutes[guardToFind])
            {
                if (row.Value > lastValMin)
                {
                    lastValMin = row.Value;
                    minuteToCalc = row.Key;
                }
            }

            var theMinute = 0;
            var theGuard = 0;
            var lastValFromMinute = 0;
            var part2Total = theMinute * theGuard;
            foreach (int key in guardToMinutes.Keys)
            {
                foreach (KeyValuePair<int, int>row  in guardToMinutes[key])
                {
                    if (row.Value > lastValFromMinute)
                    {
                        lastValFromMinute = row.Value;
                        theMinute = row.Key;
                        theGuard = key;
                    }   
                }
            }
            

            return guardToFind*minuteToCalc;
        }

        private DateTime getDate(int year, int month, int day, int hour, int minute)
        {
            return new DateTime(year, month, day, hour, minute, 0);
        }
    }
}