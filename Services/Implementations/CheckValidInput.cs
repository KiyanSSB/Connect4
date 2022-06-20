using Connect4.Services.Interfaces;

namespace Connect4.Services.Implementations
{
    public class CheckValidInput : ICheckValidInput
    {
        //- Only positions that are "physically" possible are to be considered. For example: a position where a piece is "floating" on the board without other pieces underneath is not possible due to gravity. 
        //- The number of pieces for "Team A" is either the same or exactly one more piece than the number of pieces for "Team B". For example after the third move, "Team A" has 2 pieces on the board and "Team B" only has one.
        //- There is *at most* one winner(no scenarios where both teams won should be considered)
        //- The positions in the board(i.e.number of holes in the board where the pieces are located) are always exactly 42 (which is 7 columns and 6 rows)
        //- Winning chains must share at least one piece.This means that there cannot be two winning chains of 4 pieces that do not share any piece since this is not possible in a real game of "Connect Four"
       


        /// <summary>
        ///  To check whether the pieces are floating or not we check the first position of a theoretical X inside the string
        ///  If there is no string, the position should be posible
        ///  If there is an X , we check whether the next positions contains either an A or B , in that case the position is not possible 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool noFloatingPieces(string input)
        {
            var positionX = input.IndexOf("X");

            var restOfString = input.Substring(positionX);

            if(restOfString.Contains("A") || restOfString.Contains("B"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether the board has 42 spaces
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool numberOfPositions(string input)
        {
            if(input.Length != 42)
            {
                return false;
            }
            return true;
        }

        public bool checkPrecondition(string input)
        {
            if (!this.numberOfPositions(input))
            {
                return false;
            }

            var startingPosition = 0;

            for(var i = 0; i < 7; i++)
            {
                var column = input.Substring(startingPosition,6);
                if (!noFloatingPieces(column))
                {
                    return false;
                }
                startingPosition += 6;
            }
            return true;
        }
    }
}
