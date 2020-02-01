using System;
using System.Threading.Tasks;
using RentApp.Droid.Helpers;
using RentApp.Helpers;
using Xamarin.Forms;
using Plugin.CurrentActivity;
using Org.Aviran.CookieBar2;

[assembly: Dependency(typeof(Dialogs))]
namespace RentApp.Droid.Helpers
{
    public class Dialogs : IDialogs
    {
        CustomAlertDialogs alert = null;
        public async Task Show(string message)
        {
            alert = new CustomAlertDialogs();
            alert.Show(message, null, "loading", null);
        }

        public async Task Hide()
        {
            alert.Hide();
        }

        public async Task Snackbar(string message,string title, TypeSnackbar typeSnackbar)
        {
            if (typeSnackbar == TypeSnackbar.Success)
            {
                CookieBar.Build(CrossCurrentActivity.Current.Activity)
                    .SetIcon(Resource.Drawable.ic_done)
                .SetTitle(title)
                .SetIconAnimation(Resource.Animator.iconspin)
                .SetBackgroundColor(Resource.Color.backgroundcoockiesuccess)
                .SetTitleColor(Resource.Color.cookiebartitle)
                .SetMessageColor(Resource.Color.cookiebartitle)
                .SetMessage(message)
                .SetEnableAutoDismiss(true)
                .SetSwipeToDismiss(true)
                .Show();
            }
            else
            {
                CookieBar.Build(CrossCurrentActivity.Current.Activity)
                    .SetIcon(Resource.Drawable.ic_error)
                .SetTitle(title)
                .SetIconAnimation(Resource.Animator.iconspin)
                .SetBackgroundColor(Resource.Color.backgroundcoockieerror)
                .SetTitleColor(Resource.Color.cookiebartitle)
                .SetMessageColor(Resource.Color.cookiebartitle)
                .SetMessage(message)
                .SetEnableAutoDismiss(true)
                .SetSwipeToDismiss(true)
                .Show();
            }
        }

        public async Task Toast(string message)
        {
            var toast = Android.Widget.Toast.MakeText(CrossCurrentActivity.Current.Activity, message, Android.Widget.ToastLength.Short);
            toast.Show();
        }
    }
}
