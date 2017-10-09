using System;

using EscalaTime.Models;


namespace EscalaTime.Droid
{
    class Config : IConfig
    {

        #region IConfig implementation

        private string _diretorioEscalaTime;
        public string DiretorioEscalaTime
        {
            get
            {
                if(string.IsNullOrEmpty(_diretorioEscalaTime))
                {
                    _diretorioEscalaTime = System.Environment.SpecialFolder.Personal;
                }
                return _diretorioEscalaTime;
            }
        }

        private SQLite.Net.Interop.ISQLitePlatform _plataforma;

        public SQLite.Net.Interop.ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLiteApiAndroid();
                }
            }
            return _plataforma;
        }

        #endregion

        public Config()
        {

        }


    }
}