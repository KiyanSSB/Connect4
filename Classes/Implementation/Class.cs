using Connect4.Classes.Interfaces;

namespace Connect4.Classes.Implementation
{
    public class Board : IBoard
    {
        public char[,] BoardMatrix { get; set; }


        public Board(int height, int width )
        {
            this.BoardMatrix = new char[height, width];
        }

        public int getHeight()
        {
            return this.BoardMatrix.GetLength(0);
        }

        public int getWidth()
        {
            return this.BoardMatrix.GetLength(1);
        }

        public void fillBoard(string input)
        {
            var FirstPosition = 0;

            for(var i = 0;  i < getHeight(); i++)
            {
                var column = input.Substring(FirstPosition, getHeight());
                
                for( var j = 0; j < column.Length; j++ )
                {
                    BoardMatrix[i, j] = column[j];
                }
                FirstPosition += getHeight();
            }
        }

        public void drawBoard()
        {
            for (var i = 0; i < getHeight(); i++)
            {
                for (var j = 0; j < getWidth(); j++ )
                    Console.Write(this.BoardMatrix[j, i]);
            }
            Console.WriteLine();
        }
    }
}
