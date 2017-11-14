using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeuTime
{
    public interface IConfig
    {
        string DiretorioSQLite { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
