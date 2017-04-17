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
    public class Program
    {

        public AlgorithmFactory<Position> algorithmFac { get; } // Algorithm Factory.

        // Ctor.
        public Program()
        {
            this.algorithmFac = new AlgorithmFactory<Position>();
        }

        /// <summary>
        /// Creates a maze according to row and colom size, and solves the maze using the 
        /// relevant algorithm.
        /// </summary>
        /// <param name="row">Num of rows.</param>
        /// <param name="colom">Num of coloms.</param>
        /// <param name="algorithmId">The id of the relevant algorithm to run.</param>
        /// <returns>The solution to the algorithm. </returns>
        public Solution<Position> Solve(int row, int colom, int algorithmId)
        {

            StatePool<Position> sp = new StatePool<Position>();
            Adapter ad = new Adapter(row, colom, 0, 0, 1, 1, "test", sp);
            ISearcher<Position> algorithm = this.algorithmFac.CreateAlgorithm(algorithmId);
            return algorithm.search(ad);

        }

        /// <summary>
        /// Function Compares Bfs and Dfs algorithm functions.
        /// </summary>
        public void CompareSolvers()
        {

            IMazeGenerator dfsMaze = new DFSMazeGenerator();
            dfsMaze.Generate(2, 2);

            // Print the maze.
            Console.WriteLine(dfsMaze.ToString());

            StatePool<Position> spDfs = new StatePool<Position>();
            Adapter adDfs = new Adapter(2, 2, 0, 0, 1, 1, "test Dfs", spDfs);
            ISearcher<Position> dfs = new Dfs<Position>();
            Solution<Position> solDfs = dfs.search(adDfs);
            Console.WriteLine(adDfs.ToJson(solDfs)); // Creates the solution in Json format.

            StatePool<Position> spBfs = new StatePool<Position>();
            Adapter adBfs = new Adapter(2, 2, 0, 0, 1, 1, "test Bfs", spBfs);
            ISearcher<Position> bfs = new Bfs<Position>();
            Solution<Position> solBfs = bfs.search(adBfs);
            Console.WriteLine(adBfs.ToJson(solBfs));
        }
    }
}
