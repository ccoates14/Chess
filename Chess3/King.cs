
using System;


namespace Chess3
{
    class King : BaseEntity
    {
        public static readonly string NAME = "K";
        public King(int xPos, int yPos, char color, bool directionDown, Board board) : base(xPos, yPos, color, directionDown, board, NAME) { }

        public override bool isLegalMove(int x, int y) //i still need to program to make sure that the player doesn't put the king in check
        {
            bool ignoreEndPos = true;
            bool legal = base.isLegalMoveHelper(x, y, ignoreEndPos);

            //to check if it is adjacent the x should be at most 1 away and the y should be at most one away
            if (legal)
            {
                legal = Math.Abs(x - XPos) <= 1 || Math.Abs(y - YPos) <= 1;

                //check that if unit at move to pos then it should be of other team
                if (legal)
                {
                    legal = board.getUnitAtPos(x, y) == null || board.getUnitAtPos(x, y).color == this.color;
                }
            }
            Console.WriteLine("king legal " + legal);
            return legal;
        }

        public bool isInCheckMate()
        {
            //first check if there is a move the king can make that would put it out of check, 
            //else see if there is a move of one of our units that can remove the king out of check from the other unit that is putting the king into check
            //if we have exhausted all options we are in check mate


            throw new NotImplementedException();
        }
        
        public bool isInCheck()
        {
            throw new NotImplementedException();
        }
    }
}
