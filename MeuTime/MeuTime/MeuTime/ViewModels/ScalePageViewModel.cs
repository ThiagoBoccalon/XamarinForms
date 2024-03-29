﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using MeuTime.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MeuTime.ViewModels
{
	public class ScalePageViewModel : BindableBase
	{
        private decimal _scoreTimeOne, _scoreTimeTwo;
        List<Player> player = new List<Player>();
        public List<Player> TimeOne { get; set; } = new List<Player>();
        public List<Player> TimeTwo { get; set; } = new List<Player>();        
        Scale scale = new Scale();
        

        public string ScoreTimeOne
        {
            get { return Scale._scoreTimeOne.ToString(); }
        }

        public string ScoreTimeTwo
        {
            get { return Scale._scoreTimeTwo.ToString(); }
        }


        public ScalePageViewModel()
        {            
            TimeOne.Clear(); Scale.time_one.Clear();
            TimeTwo.Clear(); Scale.time_two.Clear();

            scale.Goalkeeper();                        
            scale.OthersPlayers("ZAG",4);            
            scale.OthersPlayers("LE", 2);
            scale.OthersPlayers("LD", 2);
            scale.OthersPlayers("VOL", 2);
            scale.OthersPlayers("MC", 2);
            scale.OthersPlayers("ATA", 2);
            
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
                case "ZAG": return "zagueiro.png";
                case "LE": return "lateral_dir.png";
                case "LD": return "lateral_dir.png";
                case "VOL": return "volante.png";
                case "MC": return "meia_criador.png";                
                default: return "atacante.png";
            }
        }
    }
}
