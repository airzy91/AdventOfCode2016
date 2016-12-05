using System.Collections.Generic;
using System.Linq;
using Day1.Entities;

namespace Day1.Services
{
    public class Solve : ISolve
    {
        private readonly IGetInput _getInput;
        private readonly IGetInstructions _getInstructions;
        private readonly IFollowInstructions _followInstructions;

        public Solve(IGetInput getInput, IGetInstructions getInstructions, IFollowInstructions followInstructions)
        {
            _getInput = getInput;
            _getInstructions = getInstructions;
            _followInstructions = followInstructions;
        }

        public int PartOne()
        {
            var endPosition = GetEndPosition();

            return endPosition.Coordinate.GetDistanceFromZero();
        }

        public int PartTwo()
        {
            var endPosition = GetEndPosition();

            return endPosition.PreviousCoordinates.GroupBy(coordinate => coordinate)
                .FirstOrDefault(group => group.Count() > 1)
                ?.Key.GetDistanceFromZero() ?? endPosition.Coordinate.GetDistanceFromZero();
        }

        private Position GetEndPosition()
        {
            var input = _getInput.Get();
            var instructions = _getInstructions.Get(input);
            var startPosition = new Position(new Coordinate(0, 0), Point.North, new List<Coordinate>());
            return _followInstructions.Follow(startPosition, instructions);
        }
    }
}