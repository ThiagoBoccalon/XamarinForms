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
        private decimal _score, _scoreTimeA, _scoreTimeB;
        
        Random rd = new Random();


        public void ScaleDefender(string position, int n)
        {           
            using(var data = new AcessDB())
            {
                for (int i = 0; i < n; i++)
                    player.Add(data.GetPlayerPosition(position));                
                player = player.OrderByDescending(c => c.Defender).ToList();
                                
                for(int i = 0; i < n; i++)
                {                    
                    if (rd.Next(2) == 0)
                    {
                        _scoreTimeA =+ player[i].Defender;
                        time_A.Add(player[i++]);
                        _scoreTimeB =+ player[i].Defender;
                        time_B.Add(player[i]);
                    }
                    else
                    {
                        _scoreTimeB = player[i].Defender;
                        time_B.Add(player[i++]);
                        _scoreTimeA = player[i].Defender;
                        time_A.Add(player[i]);
                    }
                }
            }

            player.Clear();
        }

        public void ScaleMidfieldDefender(string position, int n)
        {
            using (var data = new AcessDB())
            {
                for (int i = 0; i < n; i++)
                {
                    player.Add(data.GetPlayerPosition(position));
                    _score = player[i].Attack + player[i].Attack;
                    player[i].Score = _score;
                }

                player = player.OrderByDescending(c => c.Score).ToList();
                
                for (int i = 0; i < n; i++)
                {
                    if (_scoreTimeA < _scoreTimeB)
                    {
                        _scoreTimeA =+ player[i].Score;
                        time_A.Add(player[i++]);
                        _scoreTimeB = +player[i].Score;
                        time_B.Add(player[i]);
                    }
                    else
                    {
                        _scoreTimeB =+ player[i].Score;
                        time_B.Add(player[i++]);
                        _scoreTimeA = +player[i].Score;
                        time_A.Add(player[i]);
                    }
                }
                
            }
            
            player.Clear();
        }

        public void ScaleMidfieldAttack(string position, int n)
        {
            using(var data = new AcessDB())
            {
                for (int i = 0; i < n; i++)
                    player.Add(data.GetPlayerPosition(position));
                player = player.OrderByDescending(c => c.Attack).ToList();
            }

            for (int i = 0; i < n; i++)
            {
                if (rd.Next(2) == 0)
                {
                    _scoreTimeA = +player[i].Attack;
                    time_A.Add(player[i++]);
                    _scoreTimeB = +player[i].Attack;
                    time_B.Add(player[i]);
                }
                else
                {
                    _scoreTimeB = player[i].Attack;
                    time_B.Add(player[i++]);
                    _scoreTimeA = player[i].Attack;
                    time_A.Add(player[i]);
                }
            }

            player.Clear();
        }

        public void ScaleAttack(string position, int n)
        {
            using (var data = new AcessDB())
            {
                for (int i = 0; i < n; i++)
                {
                    player.Add(data.GetPlayerPosition(position));
                    _score = player[i].Attack + player[i].Attack;
                    player[i].Score = _score;
                }

                player = player.OrderByDescending(c => c.Score).ToList();

                for (int i = 0; i < n; i++)
                {
                    if (_scoreTimeA < _scoreTimeB)
                    {
                        _scoreTimeA = +player[i].Score;
                        time_A.Add(player[i++]);
                        _scoreTimeB = +player[i].Score;
                        time_B.Add(player[i]);
                    }
                    else
                    {
                        _scoreTimeB = +player[i].Score;
                        time_B.Add(player[i++]);
                        _scoreTimeA = +player[i].Score;
                        time_A.Add(player[i]);
                    }
                }

            }

            player.Clear();
        }
    }
}
