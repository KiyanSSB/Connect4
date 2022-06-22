using Connect4.Classes.Implementation;

namespace Connect4.Services.Interfaces
{
    public interface ICheckPostconditions
    {
        public bool onlyOneWinner(List<List<int[]>> chains, Board board);
        public bool matchingWinningChains(List<List<int[]>> chains, Board board);
        public string checkAllPostConditions(List<List<int[]>> chains, Board board);
    }
}
