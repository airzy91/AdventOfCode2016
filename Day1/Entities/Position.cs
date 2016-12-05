using System;
using System.Security.Permissions;

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
            var newPoint = Point.Turn(instruction.Direction);
            var x = X;
            var y = Y;
            switch (newPoint)
            {
                case Point.North:
                    x += instruction.Distance;
                    break;
                case Point.East:
                    y += instruction.Distance;
                    break;
                case Point.South:
                    x -= instruction.Distance;
                    break;
                case Point.West:
                    y -= instruction.Distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new Position(x, y, newPoint);
        }

        public int Distance() => Math.Abs(X) + Math.Abs(Y);
    }
}