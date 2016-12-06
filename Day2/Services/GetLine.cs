using System.Linq;
using Day2.Entities;

namespace Day2.Services
{
    public class GetLine : IGetLine
    {
        private readonly IGetDirection _getDirection;

        public GetLine(IGetDirection getDirection)
        {
            _getDirection = getDirection;
        }

        public Line Get(string input)
        {
            return new Line(input.Select(c => _getDirection.Get(c)).ToList());
        }
    }
}