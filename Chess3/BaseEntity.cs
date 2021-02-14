

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
        private readonly string name;

        public BaseEntity(int xPos, int yPos, char color, string name)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.color = color;
            this.name = name;
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


    }
}
