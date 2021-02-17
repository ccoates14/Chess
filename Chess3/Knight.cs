
namespace Chess3
{
    class Knight : BaseEntity
    {
        public Knight(int xPos, int yPos, char color, string name, bool directionDown, Board board) : base(xPos, yPos, color, name, directionDown, board) { }

        public override bool isLegalMove(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}
