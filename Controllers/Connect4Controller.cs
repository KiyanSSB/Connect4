using Microsoft.AspNetCore.Mvc;
using Connect4.Services.Interfaces;
using Connect4.Services.Implementations;

namespace Connect4.Controllers
{
    public class Connect4Controller : Controller
    {
        public readonly IConnect4Solver connect4Solver;

        public Connect4Controller(IConnect4Solver connect4Solver)
        {
            this.connect4Solver = connect4Solver;
        }

        [HttpGet("api/connect-four/{input}")]
        public string Get(string input)
        {
            return connect4Solver.Solve(input);
        }
    }
}
