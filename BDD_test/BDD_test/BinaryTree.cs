using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_test
{
    class BinaryTree
    {
        protected BinaryTree zero, one;
        protected List<BinaryTree> root;
        protected int info;

        public BinaryTree(int pinfo, BinaryTree proot = null, BinaryTree pzero = null, BinaryTree pone = null)
        {
            root = new List<BinaryTree>();
            info = pinfo;
            if (proot != null)
            {
                root.Add(proot);
            }
            zero = pzero;
            one = pone;
        }
        public BinaryTree()
        {
           
        }
        public BinaryTree AddZero(int info)
        {
            BinaryTree temp = new BinaryTree(info, this, null, null);
            zero = temp;
            return zero;
        }
        public BinaryTree AddOne(int info)
        {
            BinaryTree temp = new BinaryTree(info, this, null, null);
            one = temp;
            return one;
        }     
        public bool CreateTree(int n)
        {
            if (n <= 0)
                return false;

            Queue<BinaryTree> q1 = new Queue<BinaryTree>();
            Queue<BinaryTree> q2 = new Queue<BinaryTree>(); 
            this.info = 1;
            q1.Enqueue(this);
            for(int i = 1; i < n; i++)
            {
                while(q1.Count > 0)
                {
                    BinaryTree treeFromq1 = q1.Dequeue();
                    BinaryTree newTreeOne = treeFromq1.AddZero(treeFromq1.info + 1);
                    q2.Enqueue(newTreeOne);
                    BinaryTree newTreeZero = treeFromq1.AddZero(treeFromq1.info + 1);
                    q2.Enqueue(newTreeZero);
                    treeFromq1.one = newTreeOne;
                    treeFromq1.zero = newTreeZero;
                }
                q1 = new Queue<BinaryTree>(q2);
                q2.Clear();
            }
            return true;
        }
    }
}
