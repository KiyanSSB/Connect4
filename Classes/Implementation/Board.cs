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

        public int GetHeight()
        {
            return (this.BoardMatrix.GetLength(0));
        }

        public int GetWidth()
        {
            return (this.BoardMatrix.GetLength(1));
        }


        /// <summary>
        /// Fills the Board Matrix with the values recieved by the input
        /// </summary>
        /// <param name="input">The input with the board to set up</param>
        public void FillBoard(string input)
        {
            var FirstPosition = 0;
            var Max = GetHeight() - 1;
            var leng = GetWidth() - 1;

            for (var i = 0; i < leng; i++) //Seleccionamos la columna 
            {
                var column = input.Substring(FirstPosition, GetHeight());
                var helper = 0;
                for (var j = Max; j >= 0; j--) //Seleccionamos la columna 
                {
                    BoardMatrix[j, i] = column[helper];
                    helper++;
                }
                FirstPosition += GetHeight();
            }
        }

        /// <summary>
        /// Finds all the winning chains inside the board
        /// </summary>
        /// <returns>A List containig Lists that contains the arrays in which we have the positions for a winning chain </returns>
        public List<List<int[]>> FindWinningChains()
        {
            List<List<int[]>> foundPositions = new List<List<int[]>>();

            // horizontalCheck 
            for (int j = 0; j < (GetHeight()-1) - 3; j++)
            {
                for (int i = 0; i < GetWidth()-1; i++)
                {
                    if (BoardMatrix[i, j] != 'X' &&
                        BoardMatrix[i, j + 1] == BoardMatrix[i, j] &&
                        BoardMatrix[i, j + 2] == BoardMatrix[i, j] &&
                        BoardMatrix[i, j + 3] == BoardMatrix[i, j])
                    {
                        List<int[]> list = new List<int[]>()
                        {
                            new int[] {i,j},
                            new int[] {i,j+1},
                            new int[] {i, j+2},
                            new int[] {i,j+3}
                        };

                        foundPositions.Add(list);
                    }
                }
            }
            // verticalCheck
            for (int i = 0; i < (GetWidth()-1) - 3; i++)
            {
                for (int j = 0; j < GetHeight()-1; j++)
                {
                    if (BoardMatrix[i, j] != 'X' &&
                        BoardMatrix[i + 1, j] == BoardMatrix[i, j] &&
                        BoardMatrix[i + 2, j] == BoardMatrix[i, j] &&
                        BoardMatrix[i + 3, j] == BoardMatrix[i, j])
                    {
                        List<int[]> list = new List<int[]>()
                        {
                            new int[] {i,j},
                            new int[] {i+1,j},
                            new int[] {i+2,j},
                            new int[] {i+3,j}
                        };

                        foundPositions.Add(list);
                    }
                }
            }
            // ascendingDiagonalCheck 
            for (int i = 3; i < GetWidth()-1; i++)
            {
                for (int j = 0; j < (GetHeight()-1) - 3; j++)
                {
                    if (BoardMatrix[i, j] != 'X' &&
                        BoardMatrix[i - 1, j + 1] == BoardMatrix[i, j] &&
                        BoardMatrix[i - 2, j + 2] == BoardMatrix[i, j] &&
                        BoardMatrix[i - 3, j + 3] == BoardMatrix[i, j])
                    {
                        List<int[]> list = new List<int[]>()
                        {
                            new int[] {i,j},
                            new int[] {i-1,j+1},
                            new int[] {i-2,j+2},
                            new int[] {i-3,j+3}
                        };
                        foundPositions.Add(list);
                    }
                }
            }
            // descendingDiagonalCheck
            for (int i = 3; i < GetWidth()-1; i++)
            {
                for (int j = 3; j < GetHeight()-1; j++)
                {
                    if (BoardMatrix[i, j] != 'X' &&
                        BoardMatrix[i - 1, j - 1] == BoardMatrix[i, j] &&
                        BoardMatrix[i - 2, j - 2] == BoardMatrix[i, j] &&
                        BoardMatrix[i - 3, j - 3] == BoardMatrix[i, j])

                    {
                        List<int[]> list = new List<int[]>()
                        {
                            new int[] {i,j},
                            new int[] {i-1,j-1},
                            new int[] {i-2,j-2},
                            new int[] {i-3,j-3}
                        };

                        foundPositions.Add(list);
                    }
                }
            }

            return foundPositions;
        }

    }
}
