using Connect4.Classes.Implementation;
using Connect4.Services.Interfaces;

namespace Connect4.Services.Implementations
{
    public class CheckPostconditions : ICheckPostconditions
    {
        public CheckPostconditions()
        {
        }

        /// <summary>
        /// Checks whether the winning chains share at least one position in common so they are plausible to be a correct position on the board
        /// </summary>
        /// <param name="chains"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool matchingWinningChains(List<List<int[]>> chains, Board board)
        {
            foreach (var chain in chains)
            {
                var shared = false;
                foreach (var position in chain)
                {
                    foreach (var restOfchains in chains)
                    {
                        if (restOfchains.Contains(position))
                        {
                            shared = true;
                            break; //If its shared once theres no point in keep checking
                        }
                    }
                }

                if (!shared)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Checks whether theres only one team in the winning chains
        /// </summary>
        /// <param name="chains">List of List that contains the positions for the winning chains</param>
        /// <returns></returns>
        public bool onlyOneWinner(List<List<int[]>> chains, Board board)
        {
            var position = chains.First().First();
            var winningTeam = board.BoardMatrix[position[0], position[1]];

            foreach (var chain in chains)
            {
                position = chain.First();

                if (winningTeam != board.BoardMatrix[position[0], position[1]])
                {
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chains"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string checkAllPostConditions(List<List<int[]>> chains, Board board)
        {
            if (chains.FirstOrDefault() != null)
            {
                if (!onlyOneWinner(chains, board))
                {
                    throw new ArgumentException("Found more than one winner on the board");
                }

                if (!matchingWinningChains(chains, board))
                {
                    throw new ArgumentException("Winning chains do not match");
                }

                var position = chains.First().First();
                return board.BoardMatrix[position[0], position[1]].ToString();
            }
            else
            {
                return "X";
            }
        }
    }
}
