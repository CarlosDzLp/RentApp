using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RentApp.Helpers;
using Xamarin.Forms;

namespace RentApp.ViewModels.Base
{
    public class BindableBase : INotifyPropertyChanged
    {
        #region Properties
        public string Title{ get; set; }
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

        #region Constructor
        public BindableBase()
        {
            dial = DependencyService.Get<IDialogs>();
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
        #endregion
    }
}
