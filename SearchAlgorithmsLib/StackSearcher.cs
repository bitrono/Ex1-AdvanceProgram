using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public abstract class StackSearcher<T> : ISearcher<T>
    {

        public Stack<State<T>> stack { get; set; }
        public int numOfNodesEvaluated { get; set; }

        // Ctor.
        protected StackSearcher()
        {
            this.stack = new Stack<State<T>>();
        }

        // Searches for the path.
        public abstract Solution<T> search(ISearchable<T> searchable);

        // Adds a state to the stack.
        protected void addToStack(State<T> s)
        {
            stack.Push(s);
        }

        // Gets number of nodes that have been evaluated.
        public int getNumberOfNodesEvaluate()
        {
            return this.numOfNodesEvaluated;
        }

    }
}