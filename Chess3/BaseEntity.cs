﻿

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

        public BaseEntity(int xPos, int yPos, char color, bool directionDown, Board board, string name)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.color = color;
            this.directionDown = directionDown;
            this.board = board;
            this.name = name;
        }


        public virtual void printSelf()
        {
            Console.Write(getPrintableName());
        }

        public string getPrintableName()
        {
            string n ;

            if (color == COLOR_FOR_TOP_PLAYER)
            {
                n = name + "B";
            }
            else
            {
                n = name + "W";
            }

            return n;
        }

        protected virtual bool isLegalMoveHelper(int x, int y, bool ignorePositionEntity)
        {
            if (x != XPos || y != YPos)
            {
                if (Board.positionWithinBoard(x, y))
                {
                    BaseEntity e = this.board.getUnitAtPos(x, y);
        
                    if (!ignorePositionEntity) {
                        if (e == null || e.color != this.color) {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                    
                }
               
            }

            return false;
        }

        public abstract bool isLegalMove(int x, int y);

        public virtual bool executeMove(int x, int y)
        {
           // King k = board.whiteKing;
            bool moved = false;

            if (isLegalMove(x, y))
            {
                moved = board.movePiece(XPos, YPos, x, y);

            }

            return moved;
        }

        public static int getDistanceBetweenTwoPoints(int n, int n1)
        {
            return Math.Abs(n - n1);
        }

    }
}
