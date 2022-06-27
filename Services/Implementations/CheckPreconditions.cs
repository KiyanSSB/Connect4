using Connect4.Classes.Implementation;
using Connect4.Services.Interfaces;

namespace Connect4.Services.Implementations
{
    public class CheckPreconditions : ICheckPreconditions
    {

        /// <summary>
        /// Checks every precondition before proceding 
        /// </summary>
        /// <param name="input">Full string representing the board</param>
        /// <param name="board">The board object</param>
        /// <returns></returns>
        public bool CheckPrecondition(string input, Board board)
        {
            if (!this.NumberOfPositions(input))
            {
                throw new ArgumentException("The string provided doesnt have 42 wholes");
            }

            if (input.Contains('X'))
            {
                var startingPosition = 0;
                for (var i = 0; i < board.GetWidth(); i++)
                {
                    var column = input.Substring(startingPosition, board.GetHeight());
                    if (!NoFloatingPieces(column))
                    {
                        throw new ArgumentException("The board contains floating pieces");
                    }
                    startingPosition += board.GetHeight();
                }
            }

            if (!CorrectNumberPieces(input))
            {
                throw new ArgumentException("The board contains an inadequate number of pieces");
            }
            return true;
        }
        
        /// <summary>
        ///  To check whether the pieces are floating or not we check the first position of a theoretical X inside the string
        ///  If there is no X in the string, the position should be posible
        ///  If there is an X , we check whether the next positions contains either an A or B , in that case the position is not possible 
        /// </summary>
        /// <param name="input">Substring representing a column inside the board</param>
        /// <returns>Whether the position is correct or not</returns>
        public bool NoFloatingPieces(string input)
        {
            var positionX = input.IndexOf("X");

            var restOfString = input.Substring(positionX);

            if (restOfString.Contains("A") || restOfString.Contains("B"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether the input has 42 spaces as stated in the document
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Whether the board contains </returns>
        public bool NumberOfPositions(string input)
        {
            if (input.Length != 42)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check whether the amount of Pieces for team A is equal or greater by 1 
        /// </summary>
        /// <param name="input">Full string representing the board</param>
        /// <returns>Whether the board contains the correct number of pieces</returns>
        public bool CorrectNumberPieces(string input)
        {
            int freqA = input.Count(f => (f == 'A'));
            int freqB = input.Count(f => (f == 'B'));

            int difference = freqA - freqB;

            if (difference < 0 || difference > 1)
            {
                return false;
            }
            return true;
        }
    }
}
