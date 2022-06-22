using Connect4.Classes.Implementation;

namespace Connect4.Services.Interfaces
{
    public interface ICheckPreconditions
    {
        public bool NoFloatingPieces(string input);
        public bool NumberOfPositions(string input);
        public bool CorrectNumberPieces(string input);
        public bool CheckPrecondition(string input, Board board);
    }
}
