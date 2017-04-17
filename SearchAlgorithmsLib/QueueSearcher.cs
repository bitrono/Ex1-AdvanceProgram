using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Collections.Generic;

namespace SearchAlgorithmsLib
{
    public abstract class QueueSearcher<T> : ISearcher<T>
    {

        public PriorityQueue<State<T>> priorityQueue { get; set; } // Priority queue.
        public int numOfNodesEvaluted { get; set; } // Number of nodes that were evaluated.

        // Ctor.
        public QueueSearcher()
        {
            this.priorityQueue = new PriorityQueue<State<T>>();
        }

        // Searches for the path.
        public abstract Solution<T> search(ISearchable<T> searchable);

        // Adds a state to the queue.
        protected void addToQueue(State<T> s)
        {
            priorityQueue.Enqueue(s);
        }

        // Gets how many nodes have been evaluated.
        public int getNumberOfNodesEvaluate()
        {
            return this.numOfNodesEvaluted;
        }

    }
}