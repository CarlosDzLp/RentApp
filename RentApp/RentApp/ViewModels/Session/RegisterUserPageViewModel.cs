using System.Windows.Input;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class RegisterUserPageViewModel : BindableViewBase
    {
        #region Properties
        private string Email { get; set; }
        #endregion
        #region Constructor
        public RegisterUserPageViewModel( )
        {
            LocationCommad = new Command(LocationCommadExecuted);
        }
        #endregion

        #region Command
        public ICommand LocationCommad { get; set; }
        #endregion

        #region CommandExecuted
        private void LocationCommadExecuted()
        {

        }
        #endregion
    }
}
