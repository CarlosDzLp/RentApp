using Android.Support.V7.App;
using Android.Widget;
using Plugin.CurrentActivity;
using System.IO;

namespace RentApp.Droid.Helpers
{
    public class CustomAlertDialogs
    {
        AlertDialog Adialog = null;
        public void Show(string message = null, string colorMesage = null, string image = null, string backgroundColor = null)
        {
            AlertDialog.Builder dialog = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity);
            var inflater = Android.App.Application.Context.GetSystemService(Android.Content.Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            Android.Views.View view = inflater.Inflate(Resource.Layout.CustomDialog, null);
            var colorBackground = (!string.IsNullOrWhiteSpace(backgroundColor)) ? Android.Graphics.Color.ParseColor(backgroundColor) : Android.Graphics.Color.White;
            view.SetBackgroundColor(colorBackground);
            var textMessage = view.FindViewById<TextView>(Resource.Id.text_dialog);
            if (textMessage != null)
            {
                var colorText = (!string.IsNullOrWhiteSpace(colorMesage)) ? Android.Graphics.Color.ParseColor(colorMesage) : Android.Graphics.Color.Black;
                textMessage.Text = (!string.IsNullOrWhiteSpace(message)) ? message : string.Empty;
                textMessage.SetTextColor(colorText);
            }
            //var imageView = view.FindViewById<GifImageView>(Resource.Id.gifImageView);
            //if (imageView != null)
            //{
            //    Stream input = CrossCurrentActivity.Current.Activity.Resources.OpenRawResource(Resource.Drawable.loading);
            //    byte[] bytes = ConvertByteArray(input);
            //    imageView.SetBytes(bytes);
            //    imageView.StartAnimation();
            //}
            dialog.SetView(view);
            dialog.SetCancelable(false);
            Adialog = dialog.Create();
            Adialog.Show();
        }
        public void Hide()
        {
            Adialog.Dismiss();
        }
        private byte[] ConvertByteArray(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }
    }
}
