using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using SearchAlgorithmsLib;
using Newtonsoft.Json;

namespace MazeAdapter
{
    public class Adapter : ISearchable<Position>
    {

        public Maze maze { get; set; }
        private StatePool<Position> statePool;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="row">number of rows of maze.</param>
        /// <param name="col">number of cols of maze.</param>
        /// <param name="startX">x coordinate of start point.</param>
        /// <param name="startY">y coordinate of start point.</param>
        /// <param name="endX">x coordinate of end point.</param>
        /// <param name="endY">y coordinate of end point.</param>
        /// <param name="mazeName">name of maze.</param>
        /// <param name="sp">state pool.</param>
        public Adapter(int row, int col, int startX, int startY, int endX, int endY,
            string mazeName, StatePool<Position> sp)
        {
            this.maze = new Maze(row, col);
            Console.WriteLine(this.maze.ToString());
            maze.Name = mazeName;
            maze.InitialPos = new Position(startX, startY);
            maze.GoalPos = new Position(endX, endY);
            this.statePool = sp;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="maze">maze object.</param>
        /// <param name="sp">state pool.</param>
        public Adapter(Maze maze, StatePool<Position> sp)
        {
            this.maze = maze;
            this.statePool = sp;
        }

        /// <summary>
        /// Returns the inital state.
        /// </summary>
        /// <returns>position of initial state.</returns>
        public State<Position> getInitialState()
        {
            return new State<Position>(this.maze.InitialPos);
        }

        /// <summary>
        /// Returns the goal state.
        /// </summary>
        /// <returns>position of goal state.</returns>
        public State<Position> getGoalState()
        {
            return new State<Position>(this.maze.GoalPos);
        }

        /// <summary>
        /// Returns all the possible states.
        /// </summary>
        /// <param name="s">Position current state.</param>
        /// <returns>States relative to s.</returns>
        public List<State<Position>> getAllPossibleStates(State<Position> s)
        {

            List<State<Position>> positionList = new List<State<Position>>();

            // If the block above is free add to list.
            if (s.state.Col - 1 >= 0 && this.maze[s.state.Row, s.state.Col - 1] == CellType.Free)
            {
                Position tempPos = new Position(s.state.Row, s.state.Col - 1);
                this.statePool.addToStatePool(tempPos);
                positionList.Add(this.statePool.getState(tempPos));
            }
            // If the block to the left is free add to list.
            if (s.state.Row - 1 >= 0 && this.maze[s.state.Row - 1, s.state.Col] == CellType.Free)
            {
                Position tempPos = new Position(s.state.Row - 1, s.state.Col);
                this.statePool.addToStatePool(tempPos);
                positionList.Add(this.statePool.getState(tempPos));
            }
            // If the block to the right is free add to list.
            if (s.state.Col + 1 < this.maze.Cols && this.maze[s.state.Row, s.state.Col + 1] == CellType.Free)
            {
                Position tempPos = new Position(s.state.Row, s.state.Col + 1);
                this.statePool.addToStatePool(tempPos);
                positionList.Add(this.statePool.getState(tempPos));
            }
            // If the block below is free add to list.
            if (s.state.Row + 1 < this.maze.Rows && this.maze[s.state.Row + 1, s.state.Col] == CellType.Free)
            {
                Position tempPos = new Position(s.state.Row + 1, s.state.Col);
                this.statePool.addToStatePool(tempPos);
                positionList.Add(this.statePool.getState(tempPos));
            }

            return positionList;
        }

        /// <summary>
        /// Converts the solution into Json format.
        /// </summary>
        /// <param name="sol">The solution.</param>
        /// <returns>Json of the solution.</returns>
        static public string ToJson(Solution<Position> sol, string mazeName)
        {

            StringBuilder directionSb = new StringBuilder();

            foreach (State<Position> currPosition in sol.nodeList)
            {
                if (currPosition.cameFrom == null)
                {
                    break;
                }
                else if (currPosition.cameFrom.state.Col == currPosition.state.Col + 1)
                {
                    directionSb.Append((int)Direction.Right);
                }
                else if (currPosition.cameFrom.state.Col == currPosition.state.Col - 1)
                {
                    directionSb.Append((int)Direction.Left);
                }
                else if (currPosition.cameFrom.state.Row == currPosition.state.Row + 1)
                {
                    directionSb.Append((int)Direction.Up);
                }
                else if (currPosition.cameFrom.state.Row == currPosition.state.Row - 1)
                {
                    directionSb.Append((int)Direction.Down);
                }
            }

            SolutionJson sj = new SolutionJson(mazeName, directionSb.ToString(),
                sol.numOfNodesEvaluated.ToString());

            return JsonConvert.SerializeObject(sj);

        }
    }
}