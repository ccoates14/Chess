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

            if (directionDown)
            {
                if (y <= YPos)
                {
                    legal = false;
                }
            }else if (y >= YPos)
            {
                legal = false;
            }
       
            if (legal)
            {
                int distanceMovedX = Math.Abs(x - XPos);
                legal = distanceMovedX == 0;

                if (!legal && (board.getUnitAtPos(x, y) != null && board.getUnitAtPos(x, y).color != color))
                {
                    legal = distanceMovedX == 1;
                }

                if (legal)
                {
    

                    int distanceMoveY = Math.Abs(y - YPos);

                    if (!madeFirstMove)
                    {
                  
                        legal = distanceMoveY <= 2;

                        if (legal)
                        {

                            int incrementer = 1;

                            if (color == COLOR_FOR_BOTTOM_PLAYER) incrementer = -1;

                            if (board.getUnitAtPos(XPos + distanceMovedX, YPos + incrementer) != null || board.getUnitAtPos(XPos + distanceMovedX, YPos + incrementer) != null)
                            {

                                legal = false;
                            }
                        }
                    }
                    else
                    {
                        legal = distanceMoveY == 1 && (board.getUnitAtPos(XPos + distanceMovedX, YPos + 1) == null || board.getUnitAtPos(XPos + distanceMovedX, YPos + 1).color != color);
                    }
                }

            }


            return legal;
        }

        public override bool executeMove(int x, int y)
        {
            bool executed = base.executeMove(x, y);
       
            if (executed) madeFirstMove = true;

            return executed;
        }

    }
}
