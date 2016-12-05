using System;
using System.Collections.Generic;

namespace Day1.Entities
{
    public static class CoordinateExtensions
    {
        public static Coordinate GetNewCoordinate(this Coordinate coordinate, Point point, int distance)
        {
            var newX = coordinate.X;
            var newY = coordinate.Y;

            switch (point)
            {
                case Point.North:
                    newX += distance;
                    break;
                case Point.East:
                    newY += distance;
                    break;
                case Point.South:
                    newX -= distance;
                    break;
                case Point.West:
                    newY -= distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return new Coordinate(newX, newY);
        }

        public static List<Coordinate> GetCoordinatesBetween(this Coordinate coordinate, Point point, int distance)
        {
            var coordinates = new List<Coordinate>();
            for (var i = 1; i < distance; i++)
            {
                coordinates.Add(coordinate.GetNewCoordinate(point, i));
            }
            return coordinates;
        }

        public static int GetDistanceFromZero(this Coordinate coordinate)
            => Math.Abs(coordinate.X) + Math.Abs(coordinate.Y);
    }
}