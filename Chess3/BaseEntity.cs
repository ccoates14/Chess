

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


        public void printSelf()
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

        public abstract bool isLegalMove(int x, int y);

        public abstract bool executeMove(int x, int y);
    }
}
