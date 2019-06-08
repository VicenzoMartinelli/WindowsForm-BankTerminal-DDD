using System;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Terminal.Data;
using Terminal.Data.Repository;
using Terminal.Data.UoW;
using Terminal.Domain.Interfaces;
using Terminal.Service.Interfaces;
using Terminal.Service.Services;

namespace Terminal.IoC
{
  public class SimpleInjectorBootStrapper
  {
    private static Container container;

    public static void Initialize()
    {
      container = new Container();

      container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

      container.Register<TerminalContext>(() => new TerminalContext(), Lifestyle.Scoped);
      container.Register<IRepositoryConta, RepositoryConta>(Lifestyle.Scoped);
      container.Register<IRepositoryLancamento, RepositoryLancamento>(Lifestyle.Scoped);
      container.Register<IRepositoryCorrentista, RepositoryCorrentista>(Lifestyle.Scoped);
      container.Register<IServiceAdmin, ServiceAdmin>(Lifestyle.Scoped);
      container.Register<IServiceOperacoes, ServiceOperacoes>(Lifestyle.Scoped);
      container.Register<IUnitOfWork, EFUnitOfWork>(Lifestyle.Scoped);
    }

    public static Container GetContainer() => container;
  }
}
