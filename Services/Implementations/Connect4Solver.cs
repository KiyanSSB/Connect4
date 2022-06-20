using Connect4.Classes.Implementation;
using Connect4.Services.Interfaces;

namespace Connect4.Services.Implementations
{
    public class Connect4Solver : IConnect4Solver
    {

        public readonly ICheckValidInput checkValidInput;

        public Connect4Solver(ICheckValidInput checkValidInput)
        {
            this.checkValidInput = checkValidInput;
        }

        public string solve(string input)
        {
            this.checkValidInput.checkPrecondition(input);
            Board board = new Board(6, 7);
            board.fillBoard(input);
            board.drawBoard();


            return "lmao";
        }
    }
}
