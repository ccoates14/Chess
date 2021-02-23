
namespace Chess3
{
    class Knight : BaseEntity
    {
        public static readonly string NAME = "N";
        public Knight(int xPos, int yPos, char color, bool directionDown, Board board) : base(xPos, yPos, color, directionDown, board, NAME) { }

        public override bool isLegalMove(int x, int y)
        {
            bool legal = false;
            int distanceX = getDistanceBetweenTwoPoints(x, XPos);
            int distanceY = getDistanceBetweenTwoPoints(y, YPos);

            //is the distance move for the x and y one of any of these possible options

            //to the left 2 and (down one or up one)
            //to the right 2 and (down one or up one)
            if (distanceX == 2 && distanceY == 1)
            {
                legal = true;
            }
            //up 2 and (left one or right one)
            //down 2 and (left one or right one)
            else if (distanceY == 2 && distanceX == 1)
            {
                legal = true;
            }

            //check if the move to pos is within the board and 
            //does not have a unit of the same team
            if (legal)
            {
                bool ignorePositionEntity = false;
                legal = isLegalMoveHelper(x, y, ignorePositionEntity);
            }


            return legal;
        }
    }
}
