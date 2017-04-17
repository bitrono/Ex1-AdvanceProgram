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

        // Ctor.
        public Adapter(int row, int col, int startX, int startY, int endX, int endY,
            string mazeName, StatePool<Position> sp)
        {
            this.maze = new Maze(row, col);
            maze.Name = mazeName;
            maze.InitialPos = new Position(startX, startY);
            maze.GoalPos = new Position(endX, endY);
            this.statePool = sp;
        }

        public State<Position> getInitialState()
        {
            return new State<Position>(this.maze.InitialPos);
        }

        public State<Position> getGoalState()
        {
            return new State<Position>(this.maze.GoalPos);
        }

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

        public string ToJson(Solution<Position> sol)
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

            SolutionJson sj = new SolutionJson(this.maze.Name, directionSb.ToString(),
                sol.numOfNodesEvaluated.ToString());

            return JsonConvert.SerializeObject(sj);

        }
    }
}