using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(MeuTime.Droid.Config))]
namespace MeuTime.Droid
{
    class Config : IConfig
    {
        #region IConfig implementation

        private string _diretoriosSQLite;

        private SQLite.Net.Interop.ISQLitePlatform _plataforma;

        public string DiretorioSQLite
        {
            get
            {
                if (string.IsNullOrEmpty(_diretoriosSQLite))
                {
                    _diretoriosSQLite = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _diretoriosSQLite;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }
                return _plataforma;
            }
        }

        #endregion

        public Config()
        {

        }
    }
}