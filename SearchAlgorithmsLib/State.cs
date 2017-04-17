using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{

    public class State<T> : IComparable
    {
        public T state { get; set; } // the state represented by a string
        public double cost { get; set; } // cost to reach this state (set by a setter)
        public State<T> cameFrom { get; set; } // the state we came from to this state (setter)

        // Ctor.
        public State(T state)
        {
            this.state = state;
            this.cost = 0;
            this.cameFrom = null;
        }

        public bool Equals(State<T> s)
        {
            return state.Equals(s.state);
        }

        public int CompareTo(object obj)
        {

            State<T> otherState = obj as State<T>;
            if (this.cost > otherState.cost) return -1;
            if (this.cost == otherState.cost) return 0;
            return 1;
        }

    }
}