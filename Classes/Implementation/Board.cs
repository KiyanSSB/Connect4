using Connect4.Classes.Interfaces;

namespace Connect4.Classes.Implementation
{
    public class Board : IBoard
    {
        public char[,] BoardMatrix { get; set; }

        public Board(int height, int width)
        {
            this.BoardMatrix = new char[height, width];
        }

        public int getHeight()
        {
            return (this.BoardMatrix.GetLength(0));
        }

        public int getWidth()
        {
            return (this.BoardMatrix.GetLength(1));
        }

        public void fillBoard(string input)
        {
            var FirstPosition = 0;
            var Max = getHeight()-1;
            var leng = getWidth()-1;

            for (var i = 0; i < leng; i++) //Seleccionamos la columna 
            {
                var column = input.Substring(FirstPosition, getHeight());
                var helper = 0;
                for (var j = Max; j >= 0; j--) //Seleccionamos la columna 
                {
                    BoardMatrix[j, i] = column[helper];
                    helper++;
                }
                FirstPosition += getHeight();
            }

        }

        public void drawBoard()
        {
            for (int i = 0; i < this.getHeight(); i++)
            {
                for (int j = 0; j < this.getWidth(); j++)
                {
                    Console.Write(this.BoardMatrix[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        public char whoWins()
        {
            // horizontalCheck 
            for (int j = 0; j < getHeight() - 3; j++)
            {
                for (int i = 0; i < getWidth(); i++)
                {

                    if (BoardMatrix[i, j] != 'X' &&
                        BoardMatrix[i, j + 1] == BoardMatrix[i, j] &&
                        BoardMatrix[i, j + 2] == BoardMatrix[i, j] &&
                        BoardMatrix[i, j + 3] == BoardMatrix[i, j])
                    {
                        return BoardMatrix[i, j];
                    }
                }
            }
            // verticalCheck
            for (int i = 0; i < getWidth() - 3; i++)
            {
                for (int j = 0; j < this.getHeight(); j++)
                {
                    if (BoardMatrix[i, j] != 'X' &&
                        BoardMatrix[i + 1, j] == BoardMatrix[i, j] &&
                        BoardMatrix[i + 2, j] == BoardMatrix[i, j] &&
                        BoardMatrix[i + 3, j] == BoardMatrix[i, j])
                    {
                        return BoardMatrix[i, j];
                    }
                }
            }
            // ascendingDiagonalCheck 
            for (int i = 3; i < getWidth(); i++)
            {
                for (int j = 0; j < getHeight() - 3; j++)
                {
                    if (BoardMatrix[i, j] != 'X' &&
                        BoardMatrix[i - 1, j + 1] == BoardMatrix[i, j] &&
                        BoardMatrix[i - 2, j + 2] == BoardMatrix[i, j] &&
                        BoardMatrix[i - 3, j + 3] == BoardMatrix[i, j])
                        return BoardMatrix[i, j];
                }
            }
            // descendingDiagonalCheck
            for (int i = 3; i < getWidth(); i++)
            {
                for (int j = 3; j < getHeight(); j++)
                {
                    if (BoardMatrix[i, j] != 'X' &&
                        BoardMatrix[i - 1, j - 1] == BoardMatrix[i, j] &&
                        BoardMatrix[i - 2, j - 2] == BoardMatrix[i, j] &&
                        BoardMatrix[i - 3, j - 3] == BoardMatrix[i, j])
                        return BoardMatrix[i, j];
                }
            }
            return 'X';
        }

        
        
        
        
        public void fillWithX()
        {
            for (int i = 0; i < this.getHeight(); i++)
            {
                for (int j = 0; j < this.getWidth(); j++)
                {
                    this.BoardMatrix[i, j] = 'X';
                }
            }
        }

        public bool doesWin(char team)
        {
            throw new NotImplementedException();
        }

        public string winningTeam()
        {
            throw new NotImplementedException();
        }
    }
}
