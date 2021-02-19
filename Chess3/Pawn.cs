using System;


namespace Chess3
{
    class Pawn : BaseEntity
    {
        private bool madeFirstMove = false;
        public static readonly string NAME = "P";

        public Pawn(int xPos, int yPos, char color, bool directionDown, Board board) : base(xPos, yPos, color, directionDown, board, NAME)
        {

        }

        public override bool isLegalMove(int x, int y)
        {
            bool ignoreEndPos = true;
            bool legal = base.isLegalMoveHelper(x, y, ignoreEndPos);

            if (legal)
            {
                if (x != XPos)
                {
                    legal = false;
                }

                if (legal)
                {
                    int distanceMoveY = Math.Abs(y - YPos);

                    if (!madeFirstMove)
                    {
                        legal = distanceMoveY <= 2;

                        if (legal)
                        {
                            if (board.getUnitAtPos(XPos, YPos + 1) != null || board.getUnitAtPos(XPos, YPos + 2) != null)
                            {
                                legal = false;
                            }
                        }
                    }
                    else
                    {
                        legal = distanceMoveY == 1 && board.getUnitAtPos(XPos, YPos + 1) == null;
                    }

                  
                }

            }

            return legal;
        }

        public new bool executeMove(int x, int y)
        {
            bool executed = base.executeMove(x, y);
            if (executed) madeFirstMove = true;

            return executed;
        }

    }
}
