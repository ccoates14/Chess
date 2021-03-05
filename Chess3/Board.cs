
using System;

namespace Chess3
{
    class Board
    {
        public static readonly int WIDTH = 8;
        public static readonly int HEIGHT = 8;
        public King blackKing { get; protected set; }
        public King whiteKing { get; protected set; }

        private BaseEntity[,] grid;

        public Board()
        {
            grid = new BaseEntity[WIDTH, HEIGHT];

            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    grid[i, j] = null;
                }
            }

            //init non pawn row top
            initNonPawns();
            //init non pawn row bottom
            initNonPawns(false);

            //init pawn row top
            initPawns();
            //init pawn row bottom
            initPawns(false);
        }

        public bool isGameOver()
        {
            return false;
        }

        public void printSelf()
        {
            Console.WriteLine();
            for (int i = 0; i < HEIGHT; i++)//y
            {
                Console.Write((HEIGHT - (i + 1)) + " ");
                for (int j = 0; j < WIDTH; j++)//x
                {
                    Console.Write("|");

                    if (grid[i, j] != null) grid[i, j].printSelf();
                    else Console.Write("  ");

                }
               
                Console.WriteLine("|");
            }

            Console.Write("   ");
            for (int j = 0; j < WIDTH; j++)
            {
                Console.Write(j + "  ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public BaseEntity getUnitAtPos(int x, int y)
        {
            if (!positionWithinBoard(x, y))
            {
                return null;
            }

            var unit = grid[y, x];

            if (unit != null && (unit.XPos != x || unit.YPos != y)) throw new Exception("Unit pos did not match requested get pos!");

            return unit;
        }

        public BaseEntity removeEntityAtPos(int x, int y)
        {
            BaseEntity e = null;

            if (positionWithinBoard(x, y))
            {
                e = grid[y, x];
                grid[y, x] = null;
            }

            return e;
        }

        public bool setPos(int x, int y, BaseEntity e)
        {
            if (positionWithinBoard(x, y))
            {
                grid[y, x] = e;

                if (e != null)
                {
                    e.XPos = x;
                    e.YPos = y;
                }

                return true;
            }

            return false;
        }

        public bool movePiece(int x, int y, int x1, int y1)
        {
            bool moved = false;

            if (positionWithinBoard(x, y) && positionWithinBoard(x1, y1))
            {
                BaseEntity e = removeEntityAtPos(x, y);
                
                if (e != null)
                {
                    setPos(x1, y1, e);
                    moved = true;
                    Console.WriteLine("asdasd");
                }
   
            }

            return moved;
        }

        public static bool positionWithinBoard(int x, int y)
        {
            return (x >= 0 && x < WIDTH) && (y >= 0 && y < HEIGHT);
        }

        private void initPawns(bool topBoard = true)
        {
            int yPos = 1;
            char color = BaseEntity.COLOR_FOR_TOP_PLAYER;

            if (!topBoard)
            {
                color = BaseEntity.COLOR_FOR_BOTTOM_PLAYER;
                yPos = 6;
            }

            for (int i = 0; i < WIDTH; i++)
            {
                grid[yPos, i] = new Pawn(i, yPos, color, topBoard, this);
            }
        }

        private void initNonPawns(bool topBoard = true)
        {
            int yPos = 0;
            char color = BaseEntity.COLOR_FOR_TOP_PLAYER;

            if (!topBoard)
            {
                color = BaseEntity.COLOR_FOR_BOTTOM_PLAYER;
                yPos = HEIGHT - 1;
            }

            //ROOKS
            grid[yPos, 0] = new Rook(0, yPos, color, topBoard, this);
            grid[yPos, WIDTH - 1] = new Rook(WIDTH - 1, yPos, color, topBoard, this);

            //KNIGHTS
            grid[yPos, 1] = new Knight(1, yPos, color, topBoard, this);
            grid[yPos, WIDTH - 2] = new Knight(WIDTH - 2, yPos, color, topBoard, this);

            //BISHOPS
            grid[yPos, 2] = new Bishop(2, yPos, color, topBoard, this);
            grid[yPos, WIDTH - 3] = new Bishop(WIDTH - 3, yPos, color, topBoard, this);

            //KING AND QUEEN
            grid[yPos, 4] = new King(4, yPos, color, topBoard, this);

            if (color == BaseEntity.COLOR_FOR_TOP_PLAYER)
            {
                blackKing = (King) grid[yPos, 4];
            }
            else
            {
                whiteKing = (King) grid[yPos, 4];
            }

            grid[yPos, 3] = new Queen(3, yPos, color, topBoard, this);
        }
    }
}
