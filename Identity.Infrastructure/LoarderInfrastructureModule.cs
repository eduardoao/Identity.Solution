using Autofac;
using Identity.Core.Interfaces.Gateways.Repositories;
using Identity.Core.Interfaces.Services;
using Identity.Infrastructure.Data.EntityFramework.Repositories;
using Identity.Infrastructure.Auth;

namespace Identity.Infrastructure
{
    public class LoarderInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
        }
    }
}
