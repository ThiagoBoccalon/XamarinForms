using System;
using SQLite.Net.Attributes;

namespace AppWithSQLite
{
    public class Clientes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public override string ToString()
        {
            return string.Format("Nome: {0} e-mail: {1}", Nome, Email);
        }
    }
}
