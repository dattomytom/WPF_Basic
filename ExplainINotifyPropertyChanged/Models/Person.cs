using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplainINotifyPropertyChanged.Models
{
    public class Person:INotifyPropertyChanged
    {
        private string _firstName;
        public string FirstName
        {
            get
            { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(FullName));
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(FullName));
            }
        }
        private string _fullName;
        public string FullName
        {
            get
            {
                return _firstName +" "+ _lastName;
            }
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        public Person()
        {
            //_firstName = "Dat";
            //_lastName = "Nguyen Duc";
             
        }
        public Person(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
