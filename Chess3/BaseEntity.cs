

using System;

namespace Chess3
{
    abstract class BaseEntity
    {
        public static readonly char COLOR_FOR_TOP_PLAYER = 'B';
        public static readonly char COLOR_FOR_BOTTOM_PLAYER = 'W';
        public int XPos { get; set; }
        public int YPos { get; set; }
        public readonly char color;
        protected readonly string name;
        protected readonly bool directionDown;
        protected readonly Board board;

        public BaseEntity(int xPos, int yPos, char color, string name, bool directionDown, Board board)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.color = color;
            this.name = name;
            this.directionDown = directionDown;
            this.board = board;
        }


        public virtual void printSelf()
        {
            if (color == COLOR_FOR_TOP_PLAYER)
            {
                Console.Write(name + "B");
            }
            else
            {
                Console.Write(name + "W");
            }
        }

        protected virtual bool isLegalMoveHelper(int x, int y, bool ignorePositionEntity)
        {
            if (x != XPos || y != YPos)
            {
                if (Board.positionWithinBoard(x, y))
                {
                    BaseEntity e = this.board.getUnitAtPos(x, y);

                    if (!ignorePositionEntity && (e == null || e.color != this.color)) return true;
                }
            }

            return false;
        }

        public abstract bool isLegalMove(int x, int y);

        public virtual bool executeMove(int x, int y)
        {
            if (isLegalMove(x, y))
            {
                return this.board.movePiece(XPos, YPos, x, y);
            }

            return false;
        }
    }
}
