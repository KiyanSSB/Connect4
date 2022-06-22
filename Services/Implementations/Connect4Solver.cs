using Connect4.Classes.Implementation;
using Connect4.Services.Interfaces;

namespace Connect4.Services.Implementations
{
    public class Connect4Solver : IConnect4Solver
    {

        public readonly ICheckPreconditions checkValidInput;
        public readonly ICheckPostconditions postConditions;

        public Connect4Solver(ICheckPreconditions checkValidInput, ICheckPostconditions postConditions)
        {
            this.checkValidInput = checkValidInput;
            this.postConditions = postConditions;    
        }

        public string solve(string input)
        {
            Board board = new(6, 7);
            checkValidInput.CheckPrecondition(input,board);
            board.fillBoard(input);
            board.drawBoard();
            return postConditions.checkAllPostConditions(board.findWinningChains(), board);

        }
    }
}
