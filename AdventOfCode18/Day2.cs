using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode18
{
    public class Day2
    {
        public int runTest()
        {
            List<string> commonCharacters = getTotalPart2();
            string joinedChars = string.Join("", commonCharacters.ToArray());
            return getTotal();
        }

        private int getTotal()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day2.txt");
            int countOfTwo = 0;
            int countOfThree = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                Dictionary<string, int> lettersInRow = new Dictionary<string, int>();
                for (int z = 0; z < lines[i].Length; z++)
                {
                    string currentCharacter = lines[i][z].ToString();

                    if (lettersInRow.ContainsKey(currentCharacter))
                    {
                        lettersInRow[currentCharacter]++;
                        continue;
                    }
                    
                    lettersInRow.Add(currentCharacter, 1);
                }

                if (lettersInRow.ContainsValue(2))
                {
                    countOfTwo++;
                }
                
                if (lettersInRow.ContainsValue(3))
                {
                    countOfThree++;
                }
            }

            return countOfTwo * countOfThree;
        }

        private List<string> getTotalPart2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Day2.txt");
            
            // loop through original array
            for (int i = 0; i < lines.Length; i++)
            {
                // loop through copy
                for (int z = 0; z < lines.Length; z++)
                {
                    int differenceInCharacters = 0;
                    List<string> commonCharacters = new List<string>();
                    // loop through letters
                    for (int y = 0; y < lines[z].Length; y++)
                    {
                        if (lines[z][y] != lines[i][y])
                        {
                            differenceInCharacters++;
                            continue;
                        }
                        commonCharacters.Add(lines[z][y].ToString());
                    }

                    if (differenceInCharacters == 1)
                    {
                        return commonCharacters;
                    }
                }
            }

            return new List<string>();
        }
    }
}