using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode18
{
    public class Day8
    {
        private int metaEntriesTotal;

        private Dictionary<int, (int, int)> nodeToEndPointerAndMetaDataEntries =
            new Dictionary<int, (int pointer, int metaDataEntries)>();

        private Dictionary<int, List<int>> nodeToChildren = new Dictionary<int, List<int>>();
        private Dictionary<int, int> nodeToMetaDataEntries = new Dictionary<int, int>();

        public int runTest()
        {
            int total = getTotal();

            return 0;
        }

        private int getTotal()
        {
            string[] linesOriginal = System.IO.File.ReadAllLines(@"Day8Test.txt");
            List<string> nodes = linesOriginal[0].Split(' ').ToList();

            // Loop through all nodes
            for (int i = 0; i < nodes.Count; i++)
            {
                i = getMetaDataEntries(nodes, i) - 1;
            }


//            for (int z = y - numberOfMetaDataEntries; z < y && y != 0; z++)
//            {
//                metaEntriesTotal += int.Parse(nodes[z]);
//            }

            return 0;
        }

        public int getMetaDataEntries(List<string> nodes, int pointer)
        {
            if (nodeToEndPointerAndMetaDataEntries.ContainsKey(pointer))
            {
                return nodes.Count + 1;
            }

            // get number of children
            var numberOfChildNodes = int.Parse(nodes[pointer]);
            // get number of meta data entriess
            var numberOfMetaDataEntries = int.Parse(nodes[pointer + 1]);

            int childCounter = 0;
            var lastPointer = 0;
            // Loop through node header
            for (int y = pointer; y < nodes.Count; y++)
            {
                // if we are are expecting children
                if (int.Parse(nodes[y]) == childCounter)
                {
//                    nodeToMetaDataEntries.Add(pointer, numberOfMetaDataEntries);

                    if (numberOfChildNodes > 0)
                    {
                        // Add children to node
                        if (nodeToChildren.ContainsKey(pointer))
                        {
                            var list = nodeToChildren[pointer];
                            list.Add(y);
                            nodeToChildren[pointer] = list;
                            nodeToMetaDataEntries.Add(y, int.Parse(nodes[y+1]));
                        }
                        else
                        {
                            var list = new List<int>();
                            list.Add(y);
                            nodeToChildren.Add(pointer, list);
                            nodeToMetaDataEntries.Add(y, int.Parse(nodes[y+1]));
                        }

                        childCounter++;

                        // getMetaDataEntries(nodes, y);
                    }
                }

                if (childCounter == numberOfChildNodes)
                {
                    nodeToEndPointerAndMetaDataEntries.Add(pointer, (y, numberOfMetaDataEntries));
                    lastPointer = y;
                    break;
                }
            }

            return lastPointer;
        }
    }
}