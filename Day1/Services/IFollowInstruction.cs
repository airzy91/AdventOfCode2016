using Day1.Entities;

namespace Day1.Services
{
    public interface IFollowInstruction
    {
        Position Follow(Position currentPosition, Instruction instruction);
    }
}