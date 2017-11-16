using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using MeuTime.Models;
using System.Collections.ObjectModel;

namespace MeuTime.ViewModels
{
	public class ScalePageViewModel : BindableBase
	{
        List<Player> player = new List<Player>();
        public List<Player> TimeOne { get; set; } = new List<Player>();
        public List<Player> TimeTwo { get; set; } = new List<Player>();
        

        Scale scale = new Scale();
                
        public ScalePageViewModel()
        {            
            TimeOne.Clear(); Scale.time_one.Clear();
            TimeTwo.Clear(); Scale.time_two.Clear();

            scale.Goalkeeper();                        
            scale.OthersPlayers("ZAG","Defender",4);            
            scale.OthersPlayers("LE", "DefenderAttack", 2);
            scale.OthersPlayers("LD", "DefenderAttack", 2);
            scale.OthersPlayers("VOL", "Defender", 2);
            scale.OthersPlayers("MC", "Attack", 2);
            scale.OthersPlayers("ATA", "Attack", 2);
            
            for (int i = 0; i < Scale.time_one.Count; i++)
            {
                TimeOne.Add(new Player
                {                    
                    Name = Scale.time_one[i].Name,
                    Position = Scale.time_one[i].Position,
                    Image = MyImagePlayer(Scale.time_one[i].Position)
                });
            }
            for(int i = 0; i < Scale.time_two.Count; i++)
            {
                TimeTwo.Add(new Player
                {                    
                    Name = Scale.time_two[i].Name,
                    Position = Scale.time_two[i].Position,
                    Image = MyImagePlayer(Scale.time_two[i].Position)
                });
            }    
        }

        public string MyImagePlayer(string _image)
        {
            switch (_image)
            {
                case "GOL": return "goleiro.png";
                default: return "volante.png";
            }
        }
    }
}
