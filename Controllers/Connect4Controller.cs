using Microsoft.AspNetCore.Mvc;
using Connect4.Services.Interfaces;
using Connect4.Services.Implementations;

namespace Connect4.Controllers
{
    public class Connect4Controller : Controller
    {
        public readonly IConnect4Solver connect4Solver;
        public readonly ICheckValidInput checkValidInput;

        public Connect4Controller(IConnect4Solver connect4Solver, ICheckValidInput checkValidInput)
        {
            this.connect4Solver = connect4Solver;
            this.checkValidInput = checkValidInput;
        }

        [HttpGet("api/connect-four/{input}")]
        public string Get(string input)
        {
            return (this.connect4Solver.solve(input));
        }
    }
}
