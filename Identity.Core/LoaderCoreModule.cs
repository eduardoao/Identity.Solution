using Autofac;
using Identity.Api.Core.Interfaces.UseCases;
using Identity.Api.Core.UseCases;

namespace Identity.Api.Core
{
  public class LoaderCoreModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
      builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
    }
  }
}
