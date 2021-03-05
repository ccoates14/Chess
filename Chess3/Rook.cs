using System;


namespace Chess3
{
    class Rook : BaseEntity
    {
        public static readonly string NAME = "R";
        public Rook(int xPos, int yPos, char color, bool directionDown, Board board) : base(xPos, yPos, color, directionDown, board, NAME) { }


        public override bool isLegalMove(int x, int y)
        {
            bool ignorePositionEntity = false;
            bool legal = base.isLegalMoveHelper(x, y, ignorePositionEntity);

            if (legal)
            {
                //a rook can move in a cross pattern to the outer edges of the board

                //we already know the new pos is within the board and there either is no other units there or it contains an enemy unit
                int distanceToNewX = getDistanceBetweenTwoPoints(x, XPos);
                int distanceToNewY = getDistanceBetweenTwoPoints(y, YPos);
                int distance;

                //it will either move along the x axis or the y axis

                int iteratorX = 0;
                int iteratorY = 0;

                if (distanceToNewX > 0)
                {
                    iteratorX = 1;
                    if (x < XPos)
                    {
                        iteratorX = -1;
                    }

                    distance = distanceToNewX;
                }
                else
                {
                    iteratorY = 1;
                    if (y < YPos)
                    {
                        iteratorY = -1;
                    }

                    distance = distanceToNewY;
                }

                int currentX = XPos;
                int currentY = YPos;

                for (int i = 0; i < distance - 1 && legal; i++) //we don't bother looking at the last pos because it was already checked
                {
                    currentX += iteratorX;
                    currentY += iteratorY;

                    if (board.getUnitAtPos(currentX, currentY) != null)
                    {
                        Console.WriteLine(123);
                        legal = false;
                    }

                }


            }
     
            return legal;
        }
    }
}
