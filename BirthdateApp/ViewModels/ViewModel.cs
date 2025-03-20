using System;
using System.ComponentModel;
using System.Windows;
using BirthdateApp.Models;

namespace BirthdateApp.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private DateTime _birthDate = DateTime.Today;
        private Model _user = new Model();

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                _user.BirthDate = value;
                OnChange(nameof(BirthDate));
                OnChange(nameof(Age));
                OnChange(nameof(WesternZodiac));
                OnChange(nameof(ChineseZodiac));
                ValidateAge();
            }
        }

        public int Age => _user.Age;
        public string WesternZodiac => _user.WesternZodiac;
        public string ChineseZodiac => _user.ChineseZodiac;

        private void ValidateAge()
        {
            if (Age < 0 || Age > 135)
            {
                MessageBox.Show("Invalid date!", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (BirthDate.Day == DateTime.Today.Day && BirthDate.Month == DateTime.Today.Month)
            {
                MessageBox.Show("Happy Birthday!", "nice message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void OnChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
