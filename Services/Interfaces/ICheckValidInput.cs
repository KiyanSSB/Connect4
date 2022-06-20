namespace Connect4.Services.Interfaces
{
    public interface ICheckValidInput
    {
        public bool noFloatingPieces(string input);
        public bool numberOfPositions(string input);
        public bool checkPrecondition(string input);
    }
}
