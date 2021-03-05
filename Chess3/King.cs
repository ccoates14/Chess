
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
            //Console.WriteLine("king legal " + legal);
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
            bool inCheck = false;
            //probably how to do this is to first pretend you are a queen
            //then seee if there are any units you could attack 
            // if so could those units attack back
            //in check

            //if still not in check pretend to be a knight
            //see if there are any units you could attack
            //if so are they on the other team and are they a knight
            //in check


//            Queen q = new Queen(XPos, YPos, color, directionDown, board);


            //these while loops could be refactored

            //look up
            int currentY = YPos + 1;
            while (currentY < Board.HEIGHT && !inCheck)
            {
                var unit = board.getUnitAtPos(XPos, currentY);

                if (unit != null)
                {
                    if (unit.isLegalMove(XPos, YPos))
                    {
                       // Console.WriteLine(1);
                        inCheck = true;
                    }
                }

                currentY++;
            }

            //look down
            currentY = YPos - 1;
            while (currentY >= 0 && !inCheck)
            {
                var unit = board.getUnitAtPos(XPos, currentY);

                if (unit != null)
                {
                    if (unit.isLegalMove(XPos, YPos))
                    {
                      //  Console.WriteLine(currentY);
                      ////  Console.WriteLine(unit.getPrintableName());
                       // Console.WriteLine(2);
                        inCheck = true;
                    }
                }

                currentY--;
            }

            //left 
            int currentX = XPos - 1;
            while (currentX >= 0 && !inCheck)
            {
                var unit = board.getUnitAtPos(currentX, YPos);

                if (unit != null)
                {
                    if (unit.isLegalMove(XPos, YPos))
                    {
                       // Console.WriteLine(3);
                        inCheck = true;
                    }
                }

                currentX--;
            }

            //right
            currentX = XPos + 1;
            while (currentX < Board.WIDTH && !inCheck)
            {
                var unit = board.getUnitAtPos(currentX, YPos);

                if (unit != null)
                {
                    if (unit.isLegalMove(XPos, YPos))
                    {
                       // Console.WriteLine(4);
                        inCheck = true;
                    }
                }

                currentX++;
            }

            //up left
            currentX = XPos - 1;
            currentY = YPos + 1;
            while (currentX >= 0 && currentY < Board.HEIGHT && !inCheck)
            {
                var unit = board.getUnitAtPos(currentX, currentY);

                if (unit != null)
                {
                    if (unit.isLegalMove(currentX, currentY))
                    {
                       // Console.WriteLine(5);
                        inCheck = true;
                    }
                }

                currentX--;
                currentY++;
            }

            //up right
            currentX = XPos + 1;
            currentY = YPos + 1;
            while (currentX < Board.WIDTH && currentY <Board.HEIGHT && !inCheck)
            {
                var unit = board.getUnitAtPos(currentX, currentY);

                if (unit != null)
                {
                    if (unit.isLegalMove(currentX, currentY))
                    {
                       // Console.WriteLine(6);
                        inCheck = true;
                    }
                }

                currentX++;
                currentY++;
            }

            //down left
            currentX = XPos - 1;
            currentY = YPos - 1;
            while (currentX >= 0 && currentY >= 0 && !inCheck)
            {
                var unit = board.getUnitAtPos(currentX, currentY);

                if (unit != null)
                {
                    if (unit.isLegalMove(currentX, currentY))
                    {
                        //Console.WriteLine(7);
                        inCheck = true;
                    }
                }

                currentX--;
                currentY--;
            }

            //down right
            currentX = XPos + 1;
            currentY = YPos - 1;
            while (currentX < Board.WIDTH && currentY >= 0 && !inCheck)
            {
                var unit = board.getUnitAtPos(currentX, currentY);

                if (unit != null)
                {
                    if (unit.isLegalMove(currentX, currentY))
                    {
                      //  Console.WriteLine(8);
                        inCheck = true;
                    }
                }

                currentX++;
                currentY--;
            }

            ////
            ///then we need to check if a horse can attack
            ///
            //to the left 2 and (down one or up one)
            //to the right 2 and (down one or up one)

            var units = new BaseEntity[] {board.getUnitAtPos(XPos - 2, YPos - 1), board.getUnitAtPos(XPos - 2, YPos + 1), board.getUnitAtPos(XPos + 2, YPos - 1), board.getUnitAtPos(XPos + 2, YPos + 1), board.getUnitAtPos(XPos + 1, YPos + 2), board.getUnitAtPos(XPos - 1, YPos + 2),
                                            board.getUnitAtPos(XPos + 1, YPos - 2), board.getUnitAtPos(XPos - 1, YPos - 2)};

            //up 2 and (left one or right one)
            //down 2 and (left one or right one)

            foreach (var unit in units)
            {
                if (unit != null)
                {
                    if (unit.isLegalMove(XPos, YPos))
                    {
                      //  Console.WriteLine(9);
                        inCheck = true;
                        break;
                    }
                }
            }


            return inCheck;
        }
    }
}
