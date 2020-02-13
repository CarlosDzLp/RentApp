using System;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Plugin.CurrentActivity;
using RentApp.Controls;
using RentApp.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ImageGifs), typeof(ImageGifsRenderer))]
namespace RentApp.Droid.Controls
{
    public class ImageGifsRenderer : ViewRenderer<Image, Felipecsl.GifImageViewLibrary.GifImageView>,IDisposable
    {
        //GifImageView
        public ImageGifsRenderer(Context context) : base(context)
        {
        }
        ImageGifs img;
        Felipecsl.GifImageViewLibrary.GifImageView gif;
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            img = e.NewElement as ImageGifs;
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;

            gif = new Felipecsl.GifImageViewLibrary.GifImageView(Forms.Context);
            if (!string.IsNullOrWhiteSpace(img.Img))
            {
                int resID = Resources.GetIdentifier(img.Img, "drawable", this.Context.PackageName);
                if (resID > 0)
                {
                    Stream input = CrossCurrentActivity.Current.Activity.Resources.OpenRawResource(resID);
                    byte[] bytes = ConvertByteArray(input);
                    gif.StopAnimation();
                    gif.SetBytes(bytes);
                    gif.StartAnimation();
                }
            }
            SetNativeControl(gif);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            try
            {
                if (e.PropertyName == ImageGifs.ImgProperty.PropertyName)
                {
                    int resID = Resources.GetIdentifier(img.Img, "drawable", this.Context.PackageName);
                    if(resID > 0)
                    {
                        Stream input = CrossCurrentActivity.Current.Activity.Resources.OpenRawResource(resID);
                        byte[] bytes = ConvertByteArray(input);
                        gif.StopAnimation();
                        gif.SetBytes(bytes);
                        gif.StartAnimation();
                    }   
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to load gif: " + ex.Message);
            }
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
