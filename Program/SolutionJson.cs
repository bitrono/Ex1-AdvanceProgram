using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeAdapter
{
    public class SolutionJson
    {
        public string name { get; set; }
        public string solution { get; set; }
        public string evalNodes { get; set; }

        public SolutionJson(string name, string solution, string evalNodes)
        {
            this.name = name;
            this.solution = solution;
            this.evalNodes = evalNodes;
        }
    }
}
