

using System;

namespace Chess3
{
    class Player
    {
        private bool topPlayer;
        private Board board;

        public Player(bool topPlayer, Board board)
        {
            this.topPlayer = topPlayer;
            this.board = board;
        }

        public bool move(Tuple<int, int, int, int> positions)
        {
            BaseEntity e = board.getUnitAtPos(positions.Item1, positions.Item2);
            bool executedMove = false;

            if (e != null)
            {
                if (ownesUnit(e))
                {
                    executedMove = e.executeMove(positions.Item3, positions.Item4);
                }
            }
 
            return executedMove;
        }

        public bool ownesUnit(BaseEntity e)
        {
            if (topPlayer && e.color == BaseEntity.COLOR_FOR_TOP_PLAYER)
            {
                return true;
            }
            else if (!topPlayer && e.color == BaseEntity.COLOR_FOR_BOTTOM_PLAYER)
            {
                return true;
            }

            return false;
        }


    }
}
