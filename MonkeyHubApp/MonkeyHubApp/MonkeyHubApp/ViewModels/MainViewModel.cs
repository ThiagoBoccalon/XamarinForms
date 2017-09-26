﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {        
        private string _seachTerm;        

        public string SearchTerm
        {
            get
            {
                return _seachTerm;
            }
            set
            {
                if (SetProperty(ref _seachTerm, value))
                    SearchCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<string> Resultados { get; }

        public Command SearchCommand
        {
            get;
        }

        public Command ClearCommand
        {
            get;
        }


        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
            ClearCommand = new Command(ExecuteClearCommand, CanExecuteClearCommand);
            Resultados = new ObservableCollection<string>();
        }
       
        async void ExecuteSearchCommand()
        {
            //await Task.Delay(1000);

            // await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou por '{SearchTerm}'.", "OK");
            bool resposta = await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou po '{SearchTerm}'?", "Sim", "Não");
            if (resposta)
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "Obrigado", "Ok");
            else
            {
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "Pesquise Novamente!", "OK");
                Resultados.Add(SearchTerm);         
            }
        }

        bool CanExecuteSearchCommand()
        {          
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }

        void ExecuteClearCommand()
        {           
           Resultados.Clear();
        }

        bool CanExecuteClearCommand()
        {
            return true; 
        }
    }
}
