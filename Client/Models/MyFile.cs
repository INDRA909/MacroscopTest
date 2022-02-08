using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Client.Models
{
    public class MyFile : INotifyPropertyChanged
    {      
        private string _checkText="No Checked";
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public string Name { get; set; }
        public string Text { get; set; }
        public string CheckText
        {
            get { return _checkText; }
            set
            {   
                _checkText = value;
                OnPropertyChanged("CheckText");
            }
        }
        
    }
}
