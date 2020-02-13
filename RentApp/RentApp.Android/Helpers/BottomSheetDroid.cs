using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Cocosw.BottomSheetActions;
using Plugin.CurrentActivity;
using RentApp.Helpers;
using Xamarin.Forms;

namespace RentApp.Droid.Helpers
{
    public class BottomSheetDroid : Java.Lang.Object, IDialogInterfaceOnClickListener, IDialogInterfaceOnDismissListener, IBottomSheet
    {
        TaskCompletionSource<string> source;
        public async Task<string> Bottom()
        {
            source = new TaskCompletionSource<string>();
            PopupMenu p = new PopupMenu(CrossCurrentActivity.Current.Activity, null);
            IMenu menu = p.Menu;
            MenuInflater inflater = CrossCurrentActivity.Current.Activity.MenuInflater;
            inflater.Inflate(Resource.Menu.list, menu);
            var sheet = new BottomSheet.Builder(CrossCurrentActivity.Current.Activity);
            for (int i = 0; i < menu.Size(); i++)
            {
                var item = menu.GetItem(i);
                sheet = sheet.Sheet(item.ItemId, item.Icon, item.TitleFormatted);
            }
            sheet.Grid();
            sheet.SetOnDismissListener(this);
            sheet.Listener(this);
            sheet.Build().Show();
            return await source.Task;
        }
        public void OnClick(IDialogInterface dialog, int which)
        {
            switch (which)
            {
                case Resource.Id.galery:
                    source.SetResult("Galeria");
                    break;
                case Resource.Id.camera:
                    source.SetResult("Camara");
                    break;
            }
        }

        public void OnDismiss(IDialogInterface dialog)
        {
            try
            {
                source.SetResult(string.Empty);
            }
            catch(Exception ex)
            {

            }
                             
        }
    }
}
