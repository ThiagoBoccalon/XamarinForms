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
        public List<Player> TimeOne = new List<Player>();
        public ObservableCollection<Player> TimeTwo { get; set; }


        public ScalePageViewModel()
        {
            TimeOne.Add()   
        }
	}
}
