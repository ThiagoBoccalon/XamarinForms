using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Attributes;

namespace MeuTime.Models
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(18)]
        public string Position { get; set; }

        public decimal Attack { get; set; }

        public decimal Defender { get; set; }

        public decimal Score { get; set; }

        public override string ToString()
        {
            return string.Format("Nome: {0} Position: {1} ", Name, Position);
        }
    }
}
