using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Common.IoC
{
    public class ConventionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}