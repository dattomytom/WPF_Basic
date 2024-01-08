using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WPF_Basic.DataAccess.EFCore;
using WPF_Basic.DataAccess.EFCore.UnitOfWork;
using WPF_Basic.Domain.Interfaces;
using WPF_Basic.View;
using WPF_Basic.ViewModels;
using WPF_Basic.Views;

namespace WPF_Basic
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfiguretionServices(services);
            serviceProvider = services.BuildServiceProvider();

        }
        private void ConfiguretionServices(ServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {

                options.UseSqlServer(ConfigurationManager.ConnectionStrings["strConnect"].ConnectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<LoginView>();
            services.AddScoped<MainView>();


        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var loginview = serviceProvider.GetService<LoginView>();
            loginview?.Show();
            loginview.IsVisibleChanged += (s, ev) =>
            {
                if (loginview.IsVisible == false && loginview.IsLoaded)
                {
                    var mainview = serviceProvider.GetService<MainView>();
                    mainview?.Show();
                    loginview.Close();
                }
            };
        }
    }

}
