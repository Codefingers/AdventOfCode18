using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode18.Day8
{
    public class Node
    {
        public List<int> Metadata { get; set; } = new List<int>();
        public List<Node> Nodes { get; set; } = new List<Node>();

        public int getTotalOfMetaData()
        {
            return Metadata.Sum() + Nodes.Sum(node => node.getTotalOfMetaData());
        }

        public int getValue()
        {
            if (!Nodes.Any())
            {
                return this.Metadata.Sum();
            }

            int value = 0;
            foreach (var meta in Metadata)
            {
                if (meta <= Nodes.Count)
                {
                    value += Nodes[meta-1].getValue();
                }
            }

            return value;
        }
    }
}