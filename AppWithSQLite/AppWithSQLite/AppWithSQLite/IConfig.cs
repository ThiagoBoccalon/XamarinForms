using System;
using SQLite.Net.Interop;

namespace AppWithSQLite
{
    public interface IConfig
    {
        string DiretorioSQLite { get; }
        ISQLitePlatform Platforma { get; }
    }
}
