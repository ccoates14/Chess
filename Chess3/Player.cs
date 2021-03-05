

using System;

namespace Chess3
{
    class Player
    {
        private bool topPlayer;
        private Board board;
        private King k;

        public Player(bool topPlayer, Board board, King k)
        {
            this.topPlayer = topPlayer;
            this.board = board;
            this.k = k;
        }

        public bool move(Tuple<int, int, int, int> positions)
        {
            BaseEntity e = board.getUnitAtPos(positions.Item1, positions.Item2);

            if (e.XPos != positions.Item1 || e.YPos != positions.Item2) throw new Exception("User from pos does not match entity pos! " + positions.ToString() + " " + e.XPos + " " + e.YPos);

            bool executedMove = false;

            if (e != null)
            {
                if (ownesUnit(e))
                {
                    //get unit at new pos
                    var u = board.getUnitAtPos(positions.Item3, positions.Item4);

                    executedMove = e.executeMove(positions.Item3, positions.Item4);

                    //if player is now in check
                    if (executedMove && k.isInCheck())
                    {
                        //put moved unit back to original pos
                        board.setPos(positions.Item1, positions.Item2, e);

                        //put unit at new pos back into new pos
                        board.setPos(positions.Item3, positions.Item4, u);

                        executedMove = false;

                        Console.WriteLine("Invalid move , puts king in check");
                    }

                }
                else
                {
                    Console.WriteLine("Player does not own unit selected!");
                }
            }
            else
            {
                Console.WriteLine("E was null!");
            }
 
            return executedMove;
        }

        public bool inCheck()
        {
            return k.isInCheck();
        }

        public bool ownesUnit(BaseEntity e)
        {
            if (topPlayer && e.color == BaseEntity.COLOR_FOR_TOP_PLAYER)
            {
                return true;
            }
            if (!topPlayer && e.color == BaseEntity.COLOR_FOR_BOTTOM_PLAYER)
            {
                return true;
            }

            return false;
        }

        public char getColor()
        {
            if (topPlayer) return BaseEntity.COLOR_FOR_TOP_PLAYER;

            return BaseEntity.COLOR_FOR_BOTTOM_PLAYER;
        }




    }
}
