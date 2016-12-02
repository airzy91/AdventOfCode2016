using System;
using Autofac;
using Day1.Entities;
using Day1.IoC;
using Day1.Services;

namespace Day1
{
    public class Program
    {
        public static void Main(params string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ConventionModule>();
            var container = builder.Build();
            const string input = "R2, L5, L4, L5, R4, R1, L4, R5, R3, R1, L1, L1, R4, L4, L1, R4, L4, R4, L3, R5, R4, R1, R3, L1, L1, R1, L2, R5, L4, L3, R1, L2, L2, R192, L3, R5, R48, R5, L2, R76, R4, R2, R1, L1, L5, L1, R185, L5, L1, R5, L4, R1, R3, L4, L3, R1, L5, R4, L4, R4, R5, L3, L1, L2, L4, L3, L4, R2, R2, L3, L5, R2, R5, L1, R1, L3, L5, L3, R4, L4, R3, L1, R5, L3, R2, R4, R2, L1, R3, L1, L3, L5, R4, R5, R2, R2, L5, L3, L1, L1, L5, L2, L3, R3, R3, L3, L4, L5, R2, L1, R1, R3, R4, L2, R1, L1, R3, R3, L4, L2, R5, R5, L1, R4, L5, L5, R1, L5, R4, R2, L1, L4, R1, L1, L1, L5, R3, R4, L2, R1, R2, R1, R1, R3, L5, R1, R4";
            using (var scope = container.BeginLifetimeScope())
            {
                var position = new Position(0, 0, Point.North);
                var getInstructions = scope.Resolve<IGetInstructions>();
                var instructions = getInstructions.Get(input);
                instructions.ForEach(instruction =>
                {
                    position = position.GetNewPosition(instruction);
                });

                Console.WriteLine(position.Distance());
            }
            Console.ReadKey();
        }
    }
}