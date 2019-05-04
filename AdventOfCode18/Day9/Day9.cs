using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode18.Day9
{
    public class Day9
    {
        public long getTotal(string file)
        {
            string line = System.IO.File.ReadAllLines(file)[0];
            string[] splitLine = line.Split(';');
            int players = Int32.Parse(splitLine[0].Substring(0, splitLine[0].IndexOf("players")).Trim());
            int lastMarbleScore = Int32.Parse(Regex.Match(splitLine[1].Split(':')[0], @"\d+").ToString());
//            int lastMarbleScore = Int32.Parse(Regex.Match(splitLine[1].Split(':')[0], @"\d+").ToString())*100;
            Dictionary<int, long> playerScores = new Dictionary<int, long>();

            LinkedList<long> marbles = new LinkedList<long>();
            LinkedListNode<long> current = marbles.AddFirst(0);

            int playerCount = 0;
            for (int score = 1; score < lastMarbleScore; score++)
            {
                // Do the special score thing when the score is a multiple of 23
                if (score % 23 == 0 && score != 0)
                {
                    // Go back 7 nodes to get the marble value
                    for (int y = 0; y < 7; y++)
                    {
                        current = current.Previous ?? marbles.Last;
                    }

                    // update players scores
                    if (playerScores.ContainsKey(playerCount))
                    {
                        playerScores[playerCount] += score;
                    }
                    else
                    {
                        playerScores.Add(playerCount, score);
                    }

                    LinkedListNode<long> toRemove = current;
                    current = current.Next ?? marbles.First;
                    playerScores[playerCount] += toRemove.Value;
                    marbles.Remove(toRemove);
                }
                else
                {
                    // add to the circle
                    current = current.Next ?? marbles.First;
                    current = marbles.AddAfter(current, score);
                }

                playerCount = playerCount+1 == players ? 0 : ++playerCount;
            }

            return playerScores.Max(player => player.Value);
        }
    }
}