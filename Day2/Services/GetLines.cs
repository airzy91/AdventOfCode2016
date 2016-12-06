using System.Collections.Generic;
using System.Linq;
using Day2.Entities;

namespace Day2.Services
{
    public class GetLines : IGetLines
    {
        private readonly IGetLine _getLine;

        public GetLines(IGetLine getLine)
        {
            _getLine = getLine;
        }

        public List<Line> Get(List<string> inputs)
        {
            return inputs.Select(input => _getLine.Get(input)).ToList();
        }
    }
}