using Microsoft.Extensions.DependencyInjection;
using ShopTARge22.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ShopTARge22.RealEstateTest.Macros;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.ApplicationServices.Services;
using Microsoft.Extensions.Hosting;
using ShopTARge22.RealEstateTest.Mock;

namespace ShopTARge22.RealEstateTest
{
	public abstract class TestBase
	{
		protected IServiceProvider serviceProvider { get; set; }

		protected TestBase()
		{
			var services = new ServiceCollection();
			SetupServices(services);
			serviceProvider = services.BuildServiceProvider();
		}

		public void Dispose()
		{

		}

		protected T Svc<T>()
		{
			return serviceProvider.GetService<T>();
		}

		protected T Macro<T>() where T : IMacros
		{
			return serviceProvider.GetService<T>();
		}

		public virtual void SetupServices(IServiceCollection services)
		{
			services.AddScoped<IRealEstatesServices, RealEstatesServices>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<IHostEnvironment, MockIHostEnvironment>();

            services.AddDbContext<ShopTARge22Context>(x =>
			{
				x.UseInMemoryDatabase("TEST");
				x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
			});

			RegisterMacros(services);
		}

		private void RegisterMacros(IServiceCollection services)
		{
			var macroBaseType = typeof(IMacros);

			var macros = macroBaseType.Assembly.GetTypes().Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface
			&& !x.IsAbstract);

			foreach (var macro in macros)
			{
				services.AddSingleton(macro);
			}
		}
	}
}

