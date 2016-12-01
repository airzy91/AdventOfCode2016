using Day1.Entities;

namespace Day1.Services
{
    public interface IGetInstruction
    {
        Instruction Get(string instruction);
    }
}