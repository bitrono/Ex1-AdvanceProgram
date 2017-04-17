using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public class Solution<T>
    {
        public List<State<T>> nodeList { get; set; } // List of all the nodes in the shortest path.
        public int numOfNodesEvaluated { get; set; }

        // Ctor.
        public Solution(int numOfNodesEvaluated)
        {
            this.nodeList = new List<State<T>>();
            this.numOfNodesEvaluated = numOfNodesEvaluated;
        }

    }
}