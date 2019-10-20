using Autofac;
using Identity.Api.Core.Interfaces.Gateways.Repositories;
using Identity.Api.Core.Interfaces.Services;
using Identity.Api.Infrastructure.Auth;
using Identity.Api.Infrastructure.Data.EntityFramework.Repositories;
namespace Identity.Api.Infrastructure
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
