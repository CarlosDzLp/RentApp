using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using RentApp.Helpers;
using Xamarin.Forms;

namespace RentApp.ViewModels.Base
{
    public class BindableViewBase : INotifyPropertyChanged
    {
        #region Properties
        private string title;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        #endregion

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

        IDialogs dial = null;
        IBottomSheet bottom = null;

        #region Constructor
        public BindableViewBase()
        {
            dial = DependencyService.Get<IDialogs>();
            bottom = DependencyService.Get<IBottomSheet>();
            GoBackCommand = new Command(GoBackCommandExecuted);
        }

        protected virtual void GoBackCommandExecuted()
        {
            
        }
        #endregion

        #region Command
        public ICommand GoBackCommand { get; set; }
        #endregion

        #region Dialogs
        public void Snack(string message,string title,TypeSnackbar typeSnack)
        {
            dial.Snackbar(message, title, typeSnack);
        }
        public void Toast(string message)
        {
            dial.Toast(message);
        }
        public void Hide()
        {
            dial.Hide();
        }
        public void Show(string message)
        {
            dial.Show(message);
        }
        public async Task<string> BottomSheet()
        {
            var result = await bottom.Bottom();
            return result;
        }
        #endregion
    }
}
