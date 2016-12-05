using System;
using Autofac;
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
            using (var scope = container.BeginLifetimeScope())
            {
                var solve = scope.Resolve<ISolve>();

                Console.WriteLine($"Part One: {solve.PartOne()}");
                Console.WriteLine($"Part Two: {solve.PartTwo()}");
            }
        }
    }
}