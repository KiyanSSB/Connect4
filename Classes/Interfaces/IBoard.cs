namespace Connect4.Classes.Interfaces
{
    public interface IBoard
    {
        public int GetWidth();
        public int GetHeight();
        public void FillBoard(string input);
        public List<List<int[]>> FindWinningChains();
    }
}
