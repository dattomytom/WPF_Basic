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
using WPF_Basic.DataAccess.EFCore;
using WPF_Basic.Domain.Interfaces;

namespace WPF_Basic.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        //ApplicationDbContext appDbContext;
        private readonly IUnitOfWork _unitOfWork;
        public MainView(IUnitOfWork unitOfWork)
        {
            //this.appDbContext = dbContext;
            _unitOfWork = unitOfWork;
            InitializeComponent();
            GetUsers();
        }
        private void GetUsers()
        {
            ///var uses= appDbContext.Users.ToList();
            var users = _unitOfWork.Users.GetAll();
            DgUser.ItemsSource = users;
        }
    }
}
