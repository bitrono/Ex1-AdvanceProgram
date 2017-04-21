using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;

namespace MazeAdapter
{

    /// <summary>
    /// Main function.
    /// </summary>
    public class Start
    {
        static void Main(string[] args)
        {

            Program pg = new Program();
            pg.CompareSolvers();

            // Example of Usage:

            // The following gets 2 rows, 2 coloms and 0 (Bfs algorithm), Runs the bfs algorithm
            // and returns the solution to the algorithm.
             //Solution<Position> pos = pg.Solve(2, 2, 0); 

        }

    }
}
