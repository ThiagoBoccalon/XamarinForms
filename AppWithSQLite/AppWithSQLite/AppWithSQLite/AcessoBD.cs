using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using SQLite.Net;


namespace AppWithSQLite
{
    class AcessoBD : IDisposable
    {
        private SQLite.Net.SQLiteConnection _conexaoSQLite;

        public AcessoBD()
        {
            var config = DependencyService.Get<IConfig>();
            _conexaoSQLite = new SQLiteConnection(config.Platforma, System.IO.Path.Combine(config.DiretorioSQLite, "bancodados.db3"));

            _conexaoSQLite.CreateTable<Clientes>();
        }

        public void InserirCliente(Clientes clientes)
        {
            _conexaoSQLite.Insert(clientes);
        }

        public void DeletarCliente(Clientes clientes)
        {
            _conexaoSQLite.Delete(clientes);
        }

        public Clientes GetClientes(int codigo)
        {
            return _conexaoSQLite.Table<Clientes>().FirstOrDefault(c => c.Id == codigo);
        }

        public List<Clientes> GetClientes()
        {
            return _conexaoSQLite.Table<Clientes>().OrderBy(c => c.Nome).ToList();
        }

        public void Dispose()
        {
            _conexaoSQLite.Dispose();
        }
    }
}
