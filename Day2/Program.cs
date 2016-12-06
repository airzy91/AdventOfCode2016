using Autofac;
using Common.IoC;

namespace Day2
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
            }
        }
    }
}