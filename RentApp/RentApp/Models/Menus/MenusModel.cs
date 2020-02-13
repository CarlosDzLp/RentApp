using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace RentApp.Models.Menus
{
    public class MenusModel : INotifyPropertyChanged
    {
        #region NotifyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(field, value)) { return false; }

            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
        private Color _colorBox;
        public Color ColorBox
        {
            get { return _colorBox; }
            set { SetProperty(ref _colorBox, value); }
        }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string NavigationPath { get; set; }
        public int Id { get; set; }
    }
}
