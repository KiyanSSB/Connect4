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

        public string Solve(string input)
        {
            Board board = new(6, 7);
            checkValidInput.CheckPrecondition(input,board);
            board.FillBoard(input);
            return postConditions.CheckAllPostConditions(board.FindWinningChains(), board);
        }
    }
}
