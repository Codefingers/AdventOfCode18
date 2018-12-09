using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode18
{
    public class Day1
    {
        public int runTest()
        {
            return getTotal();
        }

        private int getTotal()
        {
            List<string> list = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(@"Day1.txt");
            list = lines.ToList();
            
            List<int> frequencies = new List<int>();
            int lastValue = 0;
            int firstDuplicatedFrequency = 0;
            int count = 0;
            while (firstDuplicatedFrequency == 0) 
            {
                if (count == lines.Length)
                {
                    count = 0;
                }
                
                string valueOperator = list[count].Substring(0, 1);
                int value = int.Parse(list[count].Substring(1));

                if (valueOperator.Equals("+"))
                {
                    lastValue += value;
                    if (frequencies.Contains(lastValue))
                    {
                        firstDuplicatedFrequency = lastValue;
                        continue;
                    }
                    frequencies.Add(lastValue);
                    
                    count++;
                    continue;
                }

                lastValue -= value;
                if (frequencies.Contains(lastValue))
                {
                    firstDuplicatedFrequency = lastValue;
                }
                frequencies.Add(lastValue);
               
                count++;
            }

            return firstDuplicatedFrequency;
        }
    }
}