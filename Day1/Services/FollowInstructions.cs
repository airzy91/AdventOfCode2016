using System.Collections.Generic;
using Day1.Entities;

namespace Day1.Services
{
    public class FollowInstructions : IFollowInstructions
    {
        private readonly IFollowInstruction _followInstruction;

        public FollowInstructions(IFollowInstruction followInstruction)
        {
            _followInstruction = followInstruction;
        }

        public Position Follow(Position startPosition, List<Instruction> instructions)
        {
            var currentPosition = startPosition;
            instructions.ForEach(instruction =>
            {
                currentPosition = _followInstruction.Follow(currentPosition, instruction);
            });

            return currentPosition;
        }
    }
}