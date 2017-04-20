﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{

    /// <summary>
    /// The solution of a algorithm.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Solution<T>
    {
        public List<State<T>> nodeList { get; set; } // List of all the nodes in the shortest path.
        public int numOfNodesEvaluated { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="numOfNodesEvaluated">Number of nodes evaluated.</param>
        public Solution(int numOfNodesEvaluated)
        {
            this.nodeList = new List<State<T>>();
            this.numOfNodesEvaluated = numOfNodesEvaluated;
        }

    }
}