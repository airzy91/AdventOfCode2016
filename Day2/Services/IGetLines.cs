using System.Collections.Generic;
using Day2.Entities;

namespace Day2.Services
{
    public interface IGetLines
    {
        List<Line> Get(List<string> inputs);
    }
}