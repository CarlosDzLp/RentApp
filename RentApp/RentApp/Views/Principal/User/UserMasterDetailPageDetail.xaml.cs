using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsToolkit;
using RentApp.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentApp.Views.Principal.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserMasterDetailPageDetail : TabbedPage
    {
        public UserMasterDetailPageDetail()
        {
            InitializeComponent();
        }
    }
}
