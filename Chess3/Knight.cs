
namespace Chess3
{
    class Knight : BaseEntity
    {
        public static readonly string NAME = "N";
        public Knight(int xPos, int yPos, char color, bool directionDown, Board board) : base(xPos, yPos, color, directionDown, board) { }

        public override bool isLegalMove(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}
