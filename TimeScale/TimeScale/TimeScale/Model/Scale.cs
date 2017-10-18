using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeScale;

namespace TimeScale.Model
{
    public class Scale
    {
        List<Player> player = new List<Player>();
        public static List<Player> time_A = new List<Player>();
        public static List<Player> time_B = new List<Player>();
        Random rd = new Random();

        public void ScaleDefender(string position, int n)
        {           
            using(var data = new AcessDB())
            {
                for (int i = 0; i < n; i++)
                    player.Add(data.GetPlayerPosition(position));                
                player = player.OrderByDescending(c => c.Defensive).ToList();
                                
                for(int i = 0; i < n; i++)
                {                    
                    if (rd.Next(2) == 0)
                    {
                        time_A.Add(player[i++]);
                        time_B.Add(player[i]);
                    }
                    else
                    {
                        time_B.Add(player[i++]);
                        time_A.Add(player[i]);
                    }
                }
            }

            player.Clear();
        }
    }
}
