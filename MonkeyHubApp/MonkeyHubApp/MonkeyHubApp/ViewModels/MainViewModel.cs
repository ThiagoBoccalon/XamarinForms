using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel
    {
        public string Descricao { get; set; }
        
        public MainViewModel()
        {
            Descricao = "Olá mundo, feliz 2017!!!";
        }
    }
}
