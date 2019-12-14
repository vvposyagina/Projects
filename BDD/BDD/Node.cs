using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    class Node
    {
        String key;
        int val;
        List<Node> parents;
        Node one, zero;
        NodeValueFunction resultOne, resultZero;
        public Node(Node node)
        {
            parents = new List<Node>();
            key = node.Key;
            val = node.Value;
            for (int i = 0; i < node.Parents.Count; i++ )
            {
                if (node.Parents[i] != null)
                {
                    parents.Add(node.Parents[i]);
                }
            }
            if (node.Zero != null)
            {
                zero = new Node(node.Zero);
                zero.ConnectToParent(zero);
            }
            if(node.One != null)
            {
                one = new Node(node.One);
                one.ConnectToParent(one);
            }
            if(node.ResultOne != null)
            {
                resultOne = new NodeValueFunction(node.ResultOne);
            }
            if (node.ResultZero != null)
            {
                resultZero = new NodeValueFunction(node.ResultZero);
            }
        }
        public void ConnectToParent(Node node)
        {
            if (node.Zero != null)
            {
                node.Zero.parents.Add(node);
            }
            if (node.One != null)
            {
                node.One.parents.Add(node);
            }
        }
        public Node(string k, int v, Node o = null, Node z = null, Node p = null, NodeValueFunction rOne = null, NodeValueFunction rZero = null)
        {
            parents = new List<Node>();
            key = k;
            val = v;
            if (p != null)
            {
                parents.Add(p);
            }
            zero = z;
            one = o;
            resultOne = rOne;
            resultZero = rZero;
        }
        public Node(int v, Node o = null, Node z = null, Node p = null, NodeValueFunction rOne = null, NodeValueFunction rZero = null)
        {
            parents = new List<Node>();
            key = "";
            val = v;
            if (p != null)
            {
                parents.Add(p);
            }
            zero = z;
            one = o;
            resultOne = rOne;
            resultZero = rZero;
        }
        public int Value
        {
            get { return val; }
            set 
            {
                if (value >= 0)
                {
                    val = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public string Key
        {
            get { return key; }
            set
            {
                bool flag = true;
                for (int i = 0; i < value.Length; i++)
                {
                    if ((value[i] < 'а' || value[i] > 'я') &&
                        (value[i] <  'А' || value[i] > 'Я') &&
                        (value[i] <  'a' || value[i] > 'z') &&
                        (value[i] <  'A' || value[i] > 'Z'))
                    {
                        flag = false;
                    }                    
                }
                if (flag)
                {
                    key = value;
                }
                else
                {
                    throw new FormatException();
                    
                }
            }
        }
        public Node One
        {
            get { return one; }
            set 
            {
                one = value;                
            }
        }
        public Node Zero
        {
            get { return zero; }
            set
            {
                zero = value;
            }
        }
        public NodeValueFunction ResultOne
        {
            get { return resultOne; }
            set
            {
                resultOne = value;                
            }
        }
        public NodeValueFunction ResultZero
        {
            get { return resultZero; }
            set
            {
                resultZero = value;
            }
        }
        public List<Node> Parents
        {
            get { return parents; }
        }
    }
}
