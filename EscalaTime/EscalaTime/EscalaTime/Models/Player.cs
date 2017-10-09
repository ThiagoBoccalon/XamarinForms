using System;
using SQLite.Net.Attributes;

namespace EscalaTime.Models
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        public string Posicao
        {
            get;
            set;
        }

        public float Ataque
        {
            get;
            set;
        }

        public float Defesa
        {
            get;
            set;
        }
    }
}
