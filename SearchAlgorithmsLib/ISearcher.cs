using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public interface ISearcher<T>
    {

        // The search method. 
        Solution<T> search(ISearchable<T> searchable);

        // Get how many nodes were evaluated by algorithm.
        int getNumberOfNodesEvaluate();
    }
}