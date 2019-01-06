using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventCode2018
{
    class Day08
    {
        class Node
        {
            public List<Node> children = new List<Node>();
            public List<int> metadata = new List<int>();
            //public int startoffset = 0;
            public int size = 0;
            public Node parent = null;
            
            public Node(int[] ar)
            {
                int c = ar[0];
                int m = ar[1];

                int offset = 2;
                for (int i = 0; i < c; i++)
                {
                    Node n = new Node(ar.Skip(offset).ToArray());
                    children.Add(n);
                    n.parent = this;

                    offset += n.size;
                }

                for (int i = 0; i < m; i++)
                {
                    metadata.Add(ar[offset + i]);
                }

                size = offset + m;
            }

            public long SumMetadata()
            {
                long n = 0;
                foreach (var item in children)
                {
                    n += item.SumMetadata();
                }

                return n + metadata.Sum();
            }

            public long GetValue()
            {
                if (children.Count == 0)
                {
                    return metadata.Sum();
                }

                long n = 0;
                foreach (int item in metadata)
                {
                    n += item <= children.Count ? children[item -1].GetValue() : 0;
                }

                return n;
            }
        }

        public static long Test1(string file)
        {
            string input = File.ReadAllText(file);
            int[] ar = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Int32.Parse(s)).ToArray();

            Node n = new Node(ar);

            long result = n.SumMetadata(); ;

            Console.WriteLine(result);
            return result;
        }

        public static long Test2(string file)
        {
            string input = File.ReadAllText(file);
            int[] ar = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Int32.Parse(s)).ToArray();

            Node n = new Node(ar);

            long result = n.GetValue(); ;

            Console.WriteLine(result);
            return result;
        }

    }
}
