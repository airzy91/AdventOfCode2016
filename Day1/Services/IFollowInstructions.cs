using System.Collections.Generic;
using Day1.Entities;

namespace Day1.Services
{
    public interface IFollowInstructions
    {
        Position Follow(Position startPosition, List<Instruction> instructions);
    }
}