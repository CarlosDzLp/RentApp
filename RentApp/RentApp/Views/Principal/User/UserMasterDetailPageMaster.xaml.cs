using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RentApp.Models.Menus;
using RentApp.ViewModels.Principal.User;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentApp.Views.Principal.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public UserMasterDetailPageMaster()
        {
            InitializeComponent();
        }

        //void CustomListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        //{
            //if(e.SelectedItem != null)
            //{
                //var item = e.SelectedItem as MenusModel;
                //(BindingContext as UserMasterDetailPageMasterViewModel).SelectecMenuUser.Execute(item);
            //}               
            //(sender as ListView).SelectedItem = null;
        //}
    }
}
