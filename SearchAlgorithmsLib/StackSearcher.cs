﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{

    /// <summary>
    /// Searchers that use a stack.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StackSearcher<T> : ISearcher<T>
    {

        /// <summary>
        /// The stack of the searcher.
        /// </summary>
        public Stack<State<T>> stack { get; set; }

        /// <summary>
        /// The number of nodes that were evaluated.
        /// </summary>
        public int numOfNodesEvaluated { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        protected StackSearcher()
        {
            this.stack = new Stack<State<T>>();
        }

        /// <summary>
        /// Searches for the shortest path.
        /// </summary>
        /// <param name="searchable">The searchable object.</param>
        /// <returns>The Solution of the algorithm.</returns>
        public abstract Solution<T> Search(ISearchable<T> searchable);

        /// <summary>
        /// Adds a state to the stack.
        /// </summary>
        /// <param name="s">The state that needs to be added to the stack.</param>
        protected void AddToStack(State<T> s)
        {
            stack.Push(s);
        }

        /// <summary>
        /// Gets number of nodes that have been evaluated.
        /// </summary>
        /// <returns>The number of nodes evaluated.</returns>
        public int GetNumberOfNodesEvaluate()
        {
            return this.numOfNodesEvaluated;
        }

    }
}