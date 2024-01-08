using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Basic.DataAccess.EFCore.UnitOfWork;
using WPF_Basic.Domain.Interfaces;
using WPF_Basic.ViewModels;

namespace WPF_Basic.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly IUnitOfWork _unitOfWork;
        LoginViewModel loginVM;
        // Create a binding object for the visibility property
        //Binding visibilityBinding = new Binding();
       // public bool IsViewVisible { get; set; }
        public LoginView(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
            loginVM = new LoginViewModel(_unitOfWork);
            DataContext = loginVM;
            InitializeComponent();
            //txtErrorMessage.SetBinding(TextBlock.TextProperty, new Binding("ErrorMessage"));

            // IsViewVisible = loginVM.IsViewVisible;
            // Create a binding object for the visibility property
            // Binding visibilityBinding = new Binding();
            ////visibilityBinding = new Binding();
            //visibilityBinding.Source = this; // Set the source to the window itself
            //visibilityBinding.Path = new PropertyPath("IsViewVisible"); // Set the path to the IsViewVisible property
            //visibilityBinding.Mode = BindingMode.TwoWay; // Set the mode to two-way
            //visibilityBinding.Converter = Resources["BooleanToVisibilityConverter"] as IValueConverter; // Set the converter to the BooleanToVisibilityConverter resource

            //// Set the binding for the visibility property of the window
            //this.SetBinding(Window.VisibilityProperty, visibilityBinding);

            ////// MessageBox.Show(this.Name);
            ////// this.CommandBindings.Add(new CommandBinding( loginVM.LoginView_IsvisibleChanged));
            ////this.IsVisibleChanged += LoginView_IsVisibleChanged;

        }

        private void LoginView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("LoginView_IsVisibleChanged : " + e.NewValue);
        }

        public LoginView()
        {
            this.DataContext = new LoginViewModel();

            //txtErrorMessage.SetBinding(TextBlock.TextProperty, new Binding("ErrorMessage"));
            //loginVM = (LoginViewModel)this.DataContext;
            //visibilityBinding = new Binding();
            //visibilityBinding.Source = this; // Set the source to the window itself
            //visibilityBinding.Path = new PropertyPath("IsViewVisible"); // Set the path to the IsViewVisible property
            //visibilityBinding.Mode = BindingMode.TwoWay; // Set the mode to two-way
            //visibilityBinding.Converter = Resources["BooleanToVisibilityConverter"] as IValueConverter; // Set the converter to the BooleanToVisibilityConverter resource
           
            //// Set the binding for the visibility property of the window
            //this.SetBinding(Window.VisibilityProperty, visibilityBinding);
            InitializeComponent();

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("btnLogin_click_LoginView");
        }

        private void WLoginView_IsvisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("WLoginView_IsvisibleChanged");
        }
    }
}
