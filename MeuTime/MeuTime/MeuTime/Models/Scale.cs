using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeuTime.ViewModels;

namespace MeuTime.Models
{    
    public class Scale
    {
        public List<Player> player = new List<Player>();
        public static List<Player> time_one = new List<Player>();
        public static List<Player> time_two = new List<Player>();
        public static decimal _score = 0M;
        public static decimal _scoreTimeOne = 0M;
        public static decimal _scoreTimeTwo = 0M;            

        Random rd = new Random();
        
        public Scale()
        {
            
        }
                
        public void Goalkeeper()
        {
            NewPlayers("GOL", 2);
            for(int i = 0; i < 2; i++)
            {
                if (rd.Next(2) == 0)
                {
                    _scoreTimeOne += player[i].Defender;
                    time_one.Add(player[i++]);
                    _scoreTimeTwo += player[i].Defender;
                    time_two.Add(player[i]);
                }
                else
                {
                    _scoreTimeTwo += player[i].Defender;
                    time_two.Add(player[i++]);
                    _scoreTimeOne += player[i].Defender;
                    time_one.Add(player[i]);
                }
            }            
            player.Clear();
        }

        public void OthersPlayers(string _position, int n)
        {          
            NewPlayers(_position, n);
            for(int i = 0; i< n; i++)
            {
                if(_scoreTimeOne <= _scoreTimeTwo)
                {
                    _scoreTimeOne += player[i].Score;
                    time_one.Add(player[i++]);
                    _scoreTimeTwo += player[i].Score;
                    time_two.Add(player[i]);                                   
                }
                else
                {
                    _scoreTimeTwo += player[i].Defender;
                    time_two.Add(player[i++]);
                    _scoreTimeOne += player[i].Defender;
                    time_one.Add(player[i]);                    
                }
            }
            player.Clear();
        }

        private void NewPlayers(string position, int n)
        {
            using(var data = new AcessDataBase())
            {
                for(int i = 0; i < n; i++)
                {
                    player.Add(data.GetPlayerPosition(position));
                }
                double a = 0.32;
                switch (position)
                {
                    case "GOL":
                        {
                            player = player.OrderByDescending(c => c.Defender + (c.Speed * 0.1M)).ToList();
                            break;
                        }
                    case "ZAG":
                        {
                            player = player.OrderByDescending(c => c.Defender + (c.Speed * 0.25M)).ToList();
                            break;
                        }
                    case "LE":
                        {
                            player = player.OrderByDescending(c => c.Defender + c.Attack + c.Speed).ToList();
                            break;
                        }
                    case "LD":
                        {
                            player = player.OrderByDescending(c => c.Defender + c.Attack + c.Speed).ToList();
                            break;
                        }
                    case "VOL":
                        {
                            player = player.OrderByDescending(c => c.Defender + (c.Attack + c.Speed) * 075M).ToList();
                            break;
                        }
                    case "MC":
                        {
                            player = player.OrderByDescending(c => (c.Defender * 0.25M) + c.Attack + (c.Speed * 0.5M)).ToList();
                            break;
                        }
                    case "ATA":
                        {
                            player = player.OrderByDescending(c => c.Attack + (c.Speed * 0.5M)).ToList();
                            break;
                        }
                    default:
                        {                            
                            break;
                        }
                }                
            }
        }

       



    }
}
