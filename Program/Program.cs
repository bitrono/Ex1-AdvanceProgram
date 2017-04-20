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
    /// The program options.
    /// </summary>
    public class Program
    {

        public AlgorithmFactory<Position> algorithmFac { get; } // Algorithm Factory.

        /// <summary>
        /// Ctor.
        /// </summary>
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
            

            // Print the maze.
            //Console.WriteLine(dfsMaze.ToString());
            StatePool<Position> spDfs = new StatePool<Position>();
            //Adapter adDfs = new Adapter(2, 2, 0, 0, 1, 1, "test Dfs", spDfs);
            Maze maze = dfsMaze.Generate(500, 500);
            Console.WriteLine(maze.ToString());
            Adapter adDfs = new Adapter(maze, spDfs);
            ISearcher<Position> dfs = new Dfs<Position>();
            Solution<Position> solDfs = dfs.search(adDfs);
            Console.WriteLine(Adapter.ToJson(solDfs, "test")); // Creates the solution in Json format.
            
            /*
            StatePool<Position> spBfs = new StatePool<Position>();
            // Adapter adBfs = new Adapter(10, 10, 0, 0, 8, 1, "test Bfs", spBfs);
            Maze maze = dfsMaze.Generate(500, 500);
            Console.WriteLine(maze.ToString());
            Adapter adBfs = new Adapter(maze, spBfs);
            ISearcher<Position> bfs = new Bfs<Position>();
            Solution<Position> solBfs = bfs.search(adBfs);
            //Console.WriteLine(adBfs.ToJson(solBfs));
            */
        }
    }
}
