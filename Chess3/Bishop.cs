using System;


namespace Chess3
{
    class Bishop : BaseEntity
    {
        public static readonly string NAME = "B"; 
        public Bishop(int xPos, int yPos, char color, bool directionDown, Board board) : base(xPos, yPos, color, directionDown, board)
        {

        }

        public override bool isLegalMove(int x, int y)
        {
            int distanceMovedX = Math.Abs(x - this.XPos);
            int distanceMovedY = Math.Abs(y - this.YPos);
            bool legal = false;
            bool ignorePositionEntity = false;

            if (base.isLegalMoveHelper(x, y, ignorePositionEntity) && distanceMovedX == distanceMovedY) // if the moveto pos is within the board and we are moving diagonal 
            {
    
                int xIncrementer = 1;
                int yIncrementer = 1;

                if (y < this.YPos)
                {
                    yIncrementer = -1;
                }

                if (x < this.XPos)
                {
                    xIncrementer = -1;
                }

                int currentXPos = XPos;
                int currentYPos = YPos;
                legal = true;

                for (int i = 0; i < distanceMovedX - 1 && legal; i++)
                {
                    //if we ecounter an obstacle as we move
                    if (board.getUnitAtPos(currentXPos, currentYPos) != null)
                    {
                        legal = false;
                    }
                    else
                    {
                        currentYPos += yIncrementer;
                        currentXPos += xIncrementer;
                    }
                }
                    
                
            }

            return legal;
        }
    }
}
