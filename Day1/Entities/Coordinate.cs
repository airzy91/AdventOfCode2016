namespace Day1.Entities
{
    public class Coordinate
    {
        public readonly int X;
        public readonly int Y;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj?.GetType() != typeof(Coordinate))
            {
                return false;
            }
            var coordinate = (Coordinate) obj;
            return coordinate.X == X && coordinate.Y == Y;
        }

        public override int GetHashCode()
        {
            return new {X, Y}.GetHashCode();
        }
    }
}