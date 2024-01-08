using System;
using System.Configuration;
using System.Data;
using System.Windows;
using WPF_Basic_CallAPI.Views;

namespace WPF_Basic_CallAPI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() { }
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            var mainview = new Universities();
            mainview?.Show();
 
        }
    }

}
