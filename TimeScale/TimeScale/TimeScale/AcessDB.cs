using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TimeScale.Model;

namespace TimeScale
{
    public class AcessDB : IDisposable
    {
        private SQLite.Net.SQLiteConnection _conexaoSQLite;
        List<int> IdSelect = new List<int>();

        public AcessDB()
        {
            var config = DependencyService.Get<IConfig>();
            _conexaoSQLite = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioSQLite, "bancodados.db3"));

            _conexaoSQLite.CreateTable<Player>();
        }

        public void InsertPlayer(Player player)
        {
            _conexaoSQLite.Insert(player);
        }

        public void DeletePlayer(Player player)
        {
            _conexaoSQLite.Delete(player);
        }

        public Player GetPlayers(int code)
        {
            return _conexaoSQLite.Table<Player>().FirstOrDefault(c => c.Id == code);
        }

        
        public Player GetPlayerPosition(string position)
        {
            foreach(Player myPlayer in _conexaoSQLite.Table<Player>())
            {
                if (myPlayer.Position.Contains(position) && !IdSelect.Contains(myPlayer.Id))
                {
                    IdSelect.Add(myPlayer.Id);
                    return myPlayer;
                }
            }

            return null;            
        }
        
        public List<Player> GetPlayers()
        {
            return _conexaoSQLite.Table<Player>().OrderBy(c => c.Name).ToList();
        }

        public void Dispose()
        {
            _conexaoSQLite.Dispose();
        }
    }
}
