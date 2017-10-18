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
        List<Player> time_A = new List<Player>();
        List<Player> time_B = new List<Player>();

        public void ScaleGoal()
        {
            using(var data = new AcessDB())
            {
                for(int i=0;i<2;i++)
                    player.Add(data.GetPlayerPosition("GOL"));
                Random rd = new Random();
                rd.Next(0, 1);

            }
        }
    }
}
