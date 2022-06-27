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
        public bool MatchingWinningChains(List<List<int[]>> chains, Board board)
        {
            foreach (var chain in chains)
            {
                var shared = false;
                foreach (var position in chain)
                {
                    foreach (var restOfchains in chains)
                    {
                        if(restOfchains != chain)
                        {
                            for(int i = 0; i < restOfchains.LongCount(); i++)
                            {
                                if (position[0] == restOfchains[i][0] && position[1] == restOfchains[i][1])
                                {
                                    shared = true;
                                    break; //If its shared once theres no point in keep on checking
                                }
                            }
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
        public bool OnlyOneWinner(List<List<int[]>> chains, Board board)
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
        /// Checks all postConditions to check whether the position is correct
        /// </summary>
        /// <param name="chains"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string CheckAllPostConditions(List<List<int[]>> chains, Board board)
        {
            if (chains.FirstOrDefault() != null)
            {
                if (!OnlyOneWinner(chains, board))
                {
                    throw new ArgumentException("Found more than one winner on the board");
                }

                if (!MatchingWinningChains(chains, board))
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
