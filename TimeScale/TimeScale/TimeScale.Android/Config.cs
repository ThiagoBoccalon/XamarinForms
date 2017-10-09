using System;
using Xamarin.Forms;
using SQLite.Net.Interop;

[assembly: Dependency(typeof(TimeScale.Droid.Config))]
namespace TimeScale.Droid
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