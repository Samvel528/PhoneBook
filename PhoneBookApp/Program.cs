using Microsoft.Extensions.DependencyInjection;
using PhoneBookApp.Repositories;
using PhoneBookApp.Services;
using PhoneBookApp.Validators;
using PhoneBookApp.Views;

namespace PhoneBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IContactValidator, ContactValidator>();
            services.AddSingleton<IView, ConsoleView>();
            services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
            services.AddSingleton<IService, PhoneBookService>();

            var provider = services.BuildServiceProvider();
            var _service = provider.GetService<IService>();

            _service.Start();
        }
    }
}
