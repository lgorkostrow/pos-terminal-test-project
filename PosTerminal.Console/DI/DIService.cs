using Autofac;
using PosTerminal.Console.Services;
using PosTerminal.Core.Converters;
using PosTerminal.Core.Services;

namespace PosTerminal.Console.DI
{
    public class DIService
    {
        private static readonly DIService _instance = new DIService();
        public static DIService Current => _instance;
        
        public IContainer Container { get; }

        private ContainerBuilder _builder;
        
        public DIService()
        {
            _builder = new ContainerBuilder();
            Container = ConfigureContainer(_builder);
        }
        
        private IContainer ConfigureContainer(ContainerBuilder builder)
        {
            // Register services
            builder.RegisterType<ApplicationSettingsService>().As<IApplicationSettingsService>();
            builder.RegisterType<JsonConverter>().As<IConverter>();
            builder.RegisterType<Validator>().As<IValidator>();
            builder.RegisterType<CoinChangeService>().As<ICoinChangeService>();

            return builder.Build();
        }
    }
}