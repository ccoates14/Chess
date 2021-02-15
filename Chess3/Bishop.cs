using System;


namespace Chess3
{
    class Bishop : BaseEntity
    {
        public Bishop(int xPos, int yPos, char color, string name, bool directionDown, Board board) : base(xPos, yPos, color, name, directionDown, board)
        {

        }

        public override bool executeMove(int x, int y)
        {
            if (isLegalMove(x, y))
            {
                //if it is legal then we place our piece into the new position and replace whatever is already there
                return this.board.movePiece(XPos, YPos, x, y);
            }

            return false;
        }

        public override bool isLegalMove(int x, int y)
        {
            int distanceMovedX = Math.Abs(x - this.XPos);
            int distanceMovedY = Math.Abs(y - this.YPos);
            bool legal = false;

            if (Board.positionWithinBoard(x, y) && distanceMovedX == distanceMovedY) // if the moveto pos is within the board and we are moving diagonal 
            {
                BaseEntity e = this.board.getUnitAtPos(x, y);

                //if the moveto pos is empty or contains an enemy
                if (e == null || e.color != this.color)
                {
                    if (directionDown)
                    {
                        if (y > this.YPos)
                        {
                            int incrementer = 1;

                            if (x < this.XPos)
                            {
                                incrementer *= -1;
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
                                    currentYPos++;
                                    currentXPos += incrementer;
                                }
                            }

        
                        }
                    }
                }
            }

            return legal;
        }
    }
}
