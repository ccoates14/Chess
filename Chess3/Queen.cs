
using System;
namespace Chess3
{
    class Queen : BaseEntity
    {
        public static readonly string NAME = "Q";

        public Queen(int xPos, int yPos, char color, bool directionDown, Board board) : base(xPos, yPos, color, directionDown, board, NAME) { }

        public override bool isLegalMove(int x, int y)
        {
            //the movement is of a queen is basically the momevement of the rook and bishop combined
            var bishop = new Bishop(XPos, YPos, color, directionDown, board);
            var rook = new Rook(XPos, YPos, color, directionDown, board);
            var legal = bishop.isLegalMove(x, y) || rook.isLegalMove(x, y);
            
            //if it is legal for either rook or bishop it should be fine
            return legal;
        }
    }
}
