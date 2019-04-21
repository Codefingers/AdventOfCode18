using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode18
{
    public class Day7
    {
        private string order = "";

        public int runTest()
        {
            int total = getTotal();

            return 0;
        }

        private int getTotal()
        {
            string[] linesOriginal = System.IO.File.ReadAllLines(@"Day7.txt");
            var dependencies = new List<(string, string)>();
            List<string> letters = new List<string>();
            List<int> workers = new List<int>(5) {0, 0, 0, 0, 0};

            // build instruction lists
            for (int i = 0; i < linesOriginal.Length; i++)
            {
                int indexOfMust = linesOriginal[i].IndexOf("must");
                int indexOfCan = linesOriginal[i].IndexOf("can");

                string dependant = linesOriginal[i].Substring(indexOfCan - 2, 1);
                string independant = linesOriginal[i].Substring(indexOfMust - 2, 1);

                dependencies.Add((independant, dependant));
                letters.Add(independant);
                letters.Add(dependant);
            }

            dependencies.Sort();
            letters = letters.Distinct().ToList();

            string result = "";
            int second = 0;
            int total = 0;
            var stepsDone = new List<(string, int)>();
            while (letters.Count > 0 || workers.Any(worker => worker > second))
            {
                stepsDone.Where(d => d.Item2 <= second).ToList().ForEach(step => dependencies.RemoveAll(d => d.Item1 == step.Item1));
                stepsDone.RemoveAll(d => d.Item2 <= second);

                var currentStepList = letters.Where(step => !dependencies.Any(dependency => dependency.Item2 == step)).ToList();

                for (int i = 0; i < workers.Count && currentStepList.Any(); i++)
                {
                    if (workers[i] <= second)
                    {
                        workers[i] = ((currentStepList.First().ToCharArray()[0] - 'A') + 61) + second;
                        letters.Remove(currentStepList.First());
                        
                        result += currentStepList.First();
                        stepsDone.Add((currentStepList.First(), workers[i]));

                        currentStepList.Remove(currentStepList.First());
                    }
                }

                second++;
            }

            return 0;
        }
    }
}