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
        private decimal _score, _scoreTimeOne, _scoreTimeTwo;

        Random rd = new Random();
        
        public Scale()
        {
            
        }
                
        public void Goalkeeper()
        {
            NewPlayers("GOL", "Defender", 2);
            for(int i = 0; i < 2; i++)
            {
                if (rd.Next(2) == 0)
                {
                     _scoreTimeOne += player[i].Defender; time_one.Add(player[i++]);
                     _scoreTimeTwo += player[i].Defender; time_two.Add(player[i]);
                }
                else
                {
                    _scoreTimeTwo += player[i].Defender; time_two.Add(player[i++]);
                    _scoreTimeOne += player[i].Defender; time_one.Add(player[i]);
                }
            }            
            player.Clear();
        }

        public void OthersPlayers(string _position, string _condition, int n)
        {
          //  int n = GetNumbemPosition(_position);
            NewPlayers(_position, _condition, n);
            for(int i = 0; i< n; i++)
            {
                if(_scoreTimeOne < _scoreTimeTwo)
                {
                    switch (_condition)
                    {
                        case "Defender":
                        {
                                _scoreTimeOne += player[i].Defender; time_one.Add(player[i++]);
                                _scoreTimeTwo += player[i].Defender; time_two.Add(player[i]);
                                break;
                        }
                        case "Attack":
                        {
                                _scoreTimeOne += player[i].Attack; time_one.Add(player[i++]);
                                _scoreTimeTwo += player[i].Attack; time_two.Add(player[i]);
                                break;
                        }
                        default:
                        {
                                _scoreTimeOne += player[i].Defender + player[i].Attack; time_one.Add(player[i++]);
                                _scoreTimeTwo += player[i].Defender + player[i].Attack; time_two.Add(player[i++]);
                                break;                          
                        }
                    }                    
                }
                else
                {
                    switch (_condition)
                    {
                        case "Defender":
                        {
                                _scoreTimeTwo += player[i].Defender; time_two.Add(player[i++]);
                                _scoreTimeOne += player[i].Defender; time_one.Add(player[i]);
                                break;
                        }
                        case "Attack":
                        {
                                _scoreTimeTwo += player[i].Attack; time_two.Add(player[i++]);
                                _scoreTimeOne += player[i].Attack; time_one.Add(player[i]);
                                break;
                        }
                        default:
                        {
                                _scoreTimeTwo += player[i].Defender + player[i].Attack; time_two.Add(player[i++]);
                                _scoreTimeTwo += player[i].Defender + player[i].Attack; time_one.Add(player[i]);
                                break;
                            }
                    }
                }
            }
            player.Clear();
        }

        private void NewPlayers(string position, string criterion, int n)
        {
            using(var data = new AcessDataBase())
            {
                for(int i = 0; i < n; i++)
                {
                    player.Add(data.GetPlayerPosition(position));
                }           
                switch (criterion)
                {
                    case "Defender":
                        {
                            player = player.OrderByDescending(c => c.Defender).ToList();
                            break;
                        }
                    case "Attack":
                        {
                            player = player.OrderByDescending(c => c.Attack).ToList();
                            break;
                        }
                    default:
                        {
                            player = player.OrderByDescending(c => c.Score).ToList();
                            break;
                        }
                }                
            }
        }

       



    }
}
