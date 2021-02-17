using System;


namespace Chess3
{
    class Queen : BaseEntity
    {
        public Queen(int xPos, int yPos, char color, string name, bool directionDown, Board board) : base(xPos, yPos, color, name, directionDown, board) { }

        public override bool isLegalMove(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
