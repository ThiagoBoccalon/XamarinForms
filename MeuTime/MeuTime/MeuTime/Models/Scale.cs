using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeuTime.Models
{    
    public class Scale
    {
        public List<Player> player = new List<Player>();
        public static List<Player> time_one = new List<Player>();
        public static List<Player> time_two = new List<Player>();
        private decimal _score, _scoreTimeOne, _scoreTimeTwo;

        Random rd = new Random();
        
        public Scale()
        {
            
        }
                
        public void Goleiro(string _position, int n)
        {
            using(var data = new AcessDataBase())
            {
                for (int i = 0; i < n; i++)
                    player.Add(data.GetPlayerPosition(_position));
                player = player.OrderByDescending(c => c.Defender).ToList();

                for(int i = 0; i < n; i++)
                {
                    if (rd.Next(2) == 0)
                    {
                        _scoreTimeOne += player[i].Defender; time_one.Add(player[i++]);
                        _scoreTimeTwo += player[i].Defender; time_two.Add(player[i]);
                    }
                    else
                    {
                        _scoreTimeTwo += player[i].Defender; time_two.Add(player[i++]);
                        _scoreTimeOne += player[i].Defender; time_two.Add(player[i]);
                    }
                }
            }
            player.Clear();
        }

         
    }
}
