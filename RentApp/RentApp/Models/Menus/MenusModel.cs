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
        #endregion
        public Color ColorBox{ get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string NavigationPath { get; set; }
        public int Id { get; set; }
    }
}
