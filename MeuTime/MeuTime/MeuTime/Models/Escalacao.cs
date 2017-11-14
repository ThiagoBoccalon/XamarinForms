using System;
using System.Collections.Generic;
using System.Text;

namespace MeuTime.Models
{    
    public class Escalacao
    {
        public List<Player> player = new List<Player>();
        
        public void Goleiro(string _position, int n)
        {
            using(var data = new AcessDataBase())
            {
                for (int i = 0; i < n; i++)
                    player.Add(data.GetPlayerPosition(_position));
            }            
        }
    }
}
