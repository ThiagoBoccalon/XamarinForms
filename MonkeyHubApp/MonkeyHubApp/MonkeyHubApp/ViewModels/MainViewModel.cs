using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _descricao;

        public string Descricao
        {
            get
            {
                return _descricao;
            }
            set
            {
                SetProperty(ref _descricao, value);
            }
        }
        
        public MainViewModel()
        {
            Descricao = "Olá mundo, feliz 2017!!!";

            Task.Delay(2000).ContinueWith(async t =>
            {
                for (int i = 2018; i <= 2030; i++)
                {
                    await Task.Delay(1000);
                    Descricao = $"Olá mundo, feliz {i}";
                }
            });
        }
    }
}
