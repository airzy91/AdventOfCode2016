namespace Day1.Entities
{
    public class Instruction
    {
        public readonly Direction Direction;
        public readonly int Distance;

        public Instruction(Direction direction, int distance)
        {
            Direction = direction;
            Distance = distance;
        }
    }
}