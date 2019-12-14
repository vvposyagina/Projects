using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.ReadMatrix("input.txt");
            //g.AddRib(1, 5, 24);
            //g.DeleteRib(1, 5);
            //g.AddVertex();
            //g.DeleteVertex(1);
            //g.ChangeRib(0, 1, 5);
            //bool flag = g.Connectivity();
            //if (flag == true)
            //    Console.WriteLine("YES");
            //else
            //    Console.WriteLine("NO");
            //g.PrintMatrix();
            //g.PrintList();
            //List<rib> a = new List<rib>();
            //int x = 0;
            //a = g.MST(ref x);
            //for (int i = 0; i < a.Count(); i++)
            //{
            //    Console.WriteLine(a[i].fi + " " + a[i].se + " " + a[i].weight);
            //}
            //Console.WriteLine();
            List<int> s = new List<int>();
            s = g.Dijkstra(1);
            for (int i = 0; i < s.Count(); i++)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            //int[][] xq = g.Floyd();
            //for (int i = 0; i < xq.Count(); i++)
            //{
            //    for (int j = 0; j < xq.Count(); j++)
            //    {
            //       Console.Write(xq[i][j] + " ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
