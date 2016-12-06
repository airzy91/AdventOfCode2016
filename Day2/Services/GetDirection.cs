using System;
using Day2.Entities;

namespace Day2.Services
{
    public class GetDirection : IGetDirection
    {
        public Direction Get(char character)
        {
            switch (character)
            {
                case 'U':
                    return Direction.Up;
                case 'D':
                    return Direction.Down;
                case 'L':
                    return Direction.Left;
                case 'R':
                    return Direction.Right;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}