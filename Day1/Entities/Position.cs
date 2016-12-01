using System;

namespace Day1.Entities
{
    public class Position
    {
        public readonly int X;
        public readonly int Y;
        public readonly Point Point;

        public Position(int x, int y, Point point)
        {
            X = x;
            Y = y;
            Point = point;
        }

        public Position GetNewPosition(Instruction instruction)
        {
            throw new NotImplementedException();
        }
    }
}