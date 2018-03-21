using System;
using System.IO;
using Xamarin.Forms;
using XamarinContacts.Services;
using XamarinContacts.Droid.Services;

[assembly: Dependency(typeof(FileHelper))]
namespace XamarinContacts.Droid.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path =
                Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}