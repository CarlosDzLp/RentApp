using System;
using RentApp.iOS.Helpers;
using Xamarin.Forms;
using RentApp.Helpers;
using System.Threading.Tasks;
using System.IO;

[assembly: Dependency(typeof(PathString))]
namespace RentApp.iOS.Helpers
{
    public class PathString : IPath
    {
        public string FilePath()
        {
            try
            {
                string docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

                if (!Directory.Exists(libFolder))
                {
                    Directory.CreateDirectory(libFolder);
                }

                return Path.Combine(libFolder, "rentapp.db3");
            }
            catch (Exception ex)
            {
                return null;
            }
        }   
    }
}
