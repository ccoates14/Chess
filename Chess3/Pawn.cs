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
            Console.WriteLine("l1: " + legal);
            if (legal)
            {
              
                if (x != XPos)
                {
                    legal = false;
                }
                Console.WriteLine("l2: " + legal + " x: " + XPos + " "  +x);
                if (legal)
                {
                    int distanceMoveY = Math.Abs(y - YPos);

                    if (!madeFirstMove)
                    {

                        legal = distanceMoveY <= 2;
                       
                        if (legal)
                        {
                            Console.WriteLine("l3: " + legal);
                            int incrementer = 1;

                            if (color == COLOR_FOR_BOTTOM_PLAYER) incrementer = -1;

                            if (board.getUnitAtPos(XPos, YPos + incrementer) != null || board.getUnitAtPos(XPos, YPos + incrementer) != null)
                            {
                                Console.WriteLine(board.getUnitAtPos(XPos, YPos + 1));
                                Console.WriteLine(board.getUnitAtPos(XPos, YPos + 2));
                                Console.WriteLine("l4: " + legal);
                                legal = false;
                            }
                        }
                    }
                    else
                    {
                    
                        legal = distanceMoveY == 1 && board.getUnitAtPos(XPos, YPos + 1) == null;
                        Console.WriteLine("l.5: " + legal);
                    }

                  
                }

            }

            Console.WriteLine("pawn legal " + legal);

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
