using System.Collections.Generic;

namespace Day1.Entities
{
    public class Position
    {
        public readonly Coordinate Coordinate;
        public readonly Point Point;
        public readonly List<Coordinate> PreviousCoordinates;

        public Position(Coordinate coordinate, Point point, List<Coordinate> previousCoordinates)
        {
            Coordinate = coordinate;
            Point = point;
            PreviousCoordinates = previousCoordinates;
        }

        public Position GetNewPosition(Instruction instruction)
        {
            var newPoint = Point.Turn(instruction.Direction);
            var newCoordinate = Coordinate.GetNewCoordinate(newPoint, instruction.Distance);
            var previousCoordinates = new List<Coordinate>(PreviousCoordinates)
            {
                Coordinate,
            };
            previousCoordinates.AddRange(Coordinate.GetCoordinatesBetween(newPoint, instruction.Distance));

            return new Position(newCoordinate, newPoint, previousCoordinates);
        }
    }
}