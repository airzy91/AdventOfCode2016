using System;
using Day1.Entities;

namespace Day1.Services
{
    public class GetInstruction : IGetInstruction
    {
        public Instruction Get(string instruction)
        {
            var direction = instruction.Substring(0, 1).Equals("R", StringComparison.CurrentCultureIgnoreCase)
                ? Direction.Right
                : Direction.Left;
            var distance = int.Parse(instruction.Substring(1, instruction.Length - 1));
            return new Instruction(direction, distance);
        }
    }
}