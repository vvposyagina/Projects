using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD
{
    class NodeValueFunction
    {
        bool value;
        List<Node> variable;
        public NodeValueFunction(bool val)
        {
            value = val;
            variable = new List<Node>();
        }
        public NodeValueFunction(NodeValueFunction node)
        {
            value = node.Value;
            variable = new List<Node>();
            for (int i = 0; i < node.Variable.Count; i++)
            {
                variable.Add(node.Variable[i]);
            }
        }
        public NodeValueFunction(bool val, Node var)
        {
            value = val;
            variable = new List<Node>();
            variable.Add(var);
        }
        public List<Node> Variable
        {
            get { return variable; }
        }
        public bool Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public void AddNewVariable(Node newVar)
        {
            variable.Add(newVar);
        }
        
    }
}
