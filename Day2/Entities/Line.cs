using System.Collections.Generic;

namespace Day2.Entities
{
    public class Line
    {
        public readonly List<Direction> Directions;

        public Line(List<Direction> directions)
        {
            Directions = directions;
        }
    }
}