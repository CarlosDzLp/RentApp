using System;
using Xamarin.Forms;
using RentApp.Droid.Helpers;
using RentApp.Helpers;
using System.Threading.Tasks;

[assembly:Dependency(typeof(PathString))]
namespace RentApp.Droid.Helpers
{
    public class PathString : IPath
    {
        public string FilePath()
        {
            try
            {
                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                return System.IO.Path.Combine(path, "rentapp.db3");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
