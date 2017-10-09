using SQLite.Net.Interop;

namespace EscalaTime.Models
{
    public interface IConfig
    {
        string DiretorioEscalaTime { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
