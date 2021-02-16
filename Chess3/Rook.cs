using System;


namespace Chess3
{
    class Rook : BaseEntity
    {
        public Rook(int xPos, int yPos, char color, string name, bool directionDown, Board board) : base(xPos, yPos, color, name, directionDown, board) { }

    }
}
