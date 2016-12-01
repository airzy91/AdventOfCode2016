using System.Collections.Generic;
using System.Linq;
using Day1.Entities;

namespace Day1.Services
{
    public class GetInstructions : IGetInstructions
    {
        private readonly IGetInstruction _getInstruction;

        public GetInstructions(IGetInstruction getInstruction)
        {
            _getInstruction = getInstruction;
        }
        public List<Instruction> Get(string input)
        {
            return input.Split(',')
                .Select(instruction => _getInstruction.Get(instruction.Trim()))
                .ToList();
        }
    }
}