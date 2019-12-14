using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int>.F comp = new BinaryTree<int>.F(compare);
            BinaryTree<int> newTree = new BinaryTree<int>(4, comp);
            System.IO.StreamReader file = new System.IO.StreamReader(@"list.txt");
            int x;
            x = Convert.ToInt32(file.Read());
            while(x != null)
            {
                newTree.CreateTree(x);
                x = Convert.ToInt32(file.Read());
            }

            newTree.DFS();
        }

        public static int compare(int x, int y)
        {
            if (x > y)
                return 1;
            if (x == y) 
                return 0;
            return -1;
        }
    }
}
