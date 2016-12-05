using System;

namespace Day1.Entities
{
    public static class PointExtensions
    {
        public static Point Turn(this Point point, Direction direction)
        {
            return direction == Direction.Left ? point.TurnLeft() : point.TurnRight();
        }

        public static Point TurnLeft(this Point point)
        {
            switch (point)
            {
                case Point.North:
                    return Point.West;
                case Point.East:
                    return Point.North;
                case Point.South:
                    return Point.East;
                case Point.West:
                    return Point.South;
                default:
                    throw new ArgumentOutOfRangeException(nameof(point), point, null);
            }
        }

        public static Point TurnRight(this Point point)
        {
            switch (point)
            {
                case Point.North:
                    return Point.East;
                case Point.East:
                    return Point.South;
                case Point.South:
                    return Point.West;
                case Point.West:
                    return Point.North;
                default:
                    throw new ArgumentOutOfRangeException(nameof(point), point, null);
            }
        }
    }
}