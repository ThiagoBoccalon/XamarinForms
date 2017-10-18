using SQLite.Net.Attributes;
using System.Collections.Generic;

namespace TimeScale.Model
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public string Position { get; set; }

        public float Offensive { get; set; }

        public float Defensive { get; set; }        
        

        public override string ToString()
        {
            
            return string.Format("Nome: {0} \n Position:{1} \n Offensive {2}", Name,Position,Offensive);
        }
    }
}
