using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF_Basic.DataAccess.EFCore;
using WPF_Basic.DataAccess.EFCore.UnitOfWork;
using WPF_Basic.Domain.Interfaces;

namespace WPF_Basic.ViewModels
{
    public class LoginViewModel:ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private string _username;
        public string UserName { 
            get { return _username; }
            set 
            { 
                _username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        private SecureString _password;
        public SecureString Password 
        { 
            get { return _password; }
            set 
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        private bool _isViewVisible;
        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }


        //->commands
        public ICommand LoginCommand { get; }
        public ICommand LoginView_IsvisibleChanged { get; }
  
        public LoginViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            LoginView_IsvisibleChanged = new ViewModelCommand(ExcuteLoginView_IsvisibleChanged, CanLoginView_IsvisibleChanged);
        }
        public LoginViewModel()
        {

        }

        private bool CanLoginView_IsvisibleChanged(object obj)
        {
            return IsViewVisible?true:false;
        }

        private void ExcuteLoginView_IsvisibleChanged(object obj)
        {
            IsViewVisible = false;
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(UserName) || UserName.Length < 3 || 
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = _unitOfWork.Users.AuthenticateUser(new NetworkCredential(UserName,Password));
            if (isValidUser)
            {
                ErrorMessage = string.Empty;
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(UserName), null);
                IsViewVisible = false;
            }
            else
            {
               ErrorMessage = "* Invalid username or password";
            }
        }

    }
}
