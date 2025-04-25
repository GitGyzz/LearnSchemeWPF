using Banana.Data;
using Banana.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Banana.Services;
using Banana.Views;
using Microsoft.AspNetCore.Identity;
using Login = Banana.Services.Login;

namespace Banana
{
    class ServiceLocator
    {   
        private IServiceProvider _provider { get; }

        private static ServiceLocator _current;
            
        public static ServiceLocator Current
        {
            get
            {
                if (_current is not null) return _current;

                if (Application.Current.TryFindResource(nameof(ServiceLocator)) is not null)
                {
                    return _current=(ServiceLocator)Application.Current.TryFindResource(nameof(ServiceLocator));
                }

                throw new Exception("noway");
            }
        }
        
        public MainWindowViewModel MainWindowViewModel =>_provider.GetRequiredService<MainWindowViewModel>();

        public LoginViewModel LoginViewModel => _provider.GetRequiredService<LoginViewModel>();
        
        public RegisterViewModel RegisterViewModel => _provider.GetRequiredService<RegisterViewModel>();

        public ServiceLocator() 
        {
            _provider = CreateProvider();
        }

        public IServiceProvider CreateProvider()
        {
            var services=new ServiceCollection();

            services.AddDbContext<AppDbContext>(options=> 
                options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=BNNMSSQL;Integrated Security=True"));

            services.AddIdentityCore<IdentityUser>(options =>
            {

            }).AddEntityFrameworkStores<AppDbContext>()
            .AddUserManager<UserManager<IdentityUser>>();
            
            services.AddSingleton<ILogin,Login>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<INavigation, Navigation>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<RegisterViewModel>();
            
            return services.BuildServiceProvider();
        }
    }
}
