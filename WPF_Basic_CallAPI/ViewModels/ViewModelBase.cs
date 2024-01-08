using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Basic_CallAPI.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
