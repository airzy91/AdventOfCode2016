using Day1.Entities;

namespace Day1.Services
{
    public class FollowInstruction : IFollowInstruction
    {
        public Position Follow(Position currentPosition, Instruction instruction)
        {
            return currentPosition.GetNewPosition(instruction);
        }
    }
}