namespace Connect4.Classes.Interfaces
{
    public interface IBoard
    {
        public int getWidth();
        public int getHeight();
        public void fillBoard(string input);
        public void drawBoard();
        public void fillWithX();
        public List<List<int[]>> findWinningChains();
    }
}
