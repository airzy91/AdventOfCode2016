using System.Collections.Generic;
using Day1.Entities;

namespace Day1.Services
{
    public interface IGetInstructions
    {
        List<Instruction> Get(string input);
    }
}