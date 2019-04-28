using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode18.Day8
{
    public class Day8
    {
        public int getTotal(string file)
        {
            string[] linesOriginal = System.IO.File.ReadAllLines(file);
            List<string> nodes = linesOriginal[0].Split(' ').ToList();
            int pointer = 0;
            Node node = getChildren(nodes, ref pointer);

            return node.getTotalOfMetaData();
        }

        public int getTotalPart2(string file)
        {
            string[] linesOriginal = System.IO.File.ReadAllLines(file);
            List<string> nodes = linesOriginal[0].Split(' ').ToList();
            int pointer = 0;
            Node node = getChildren(nodes, ref pointer);

            return node.getValue();
        }

        public Node getChildren(List<string> nodes, ref int pointer)
        {
            Node node = new Node();
            int childNodes = Int32.Parse(nodes[pointer++]);
            int metaDataEntries = pointer + 1 < nodes.Count ? Int32.Parse(nodes[pointer++]) : 0;

            for (int y = 0; y < childNodes; y++)
            {
                node.Nodes.Add(getChildren(nodes, ref pointer));
            }
            
            for (int i = 0; i < metaDataEntries; i++)
            {
                node.Metadata.Add(Int32.Parse(nodes[pointer++]));
            }

            return node;
        }
    }
}