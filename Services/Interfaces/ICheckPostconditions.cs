using Connect4.Classes.Implementation;

namespace Connect4.Services.Interfaces
{
    public interface ICheckPostconditions
    {
        public bool OnlyOneWinner(List<List<int[]>> chains, Board board);
        public bool MatchingWinningChains(List<List<int[]>> chains, Board board);
        public string CheckAllPostConditions(List<List<int[]>> chains, Board board);
    }
}
