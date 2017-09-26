using System.Collections.Generic;
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

        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);

            List<string> X = new List<string>();
            var listaDeItensNovos = new[] { "Thiago ", "Bucalon" };
            X.AddRange(listaDeItensNovos);

            // implement AddRange no método de ObservableCollection
            foreach (var itemNovo in listaDeItensNovos)
                Resultados.Add(itemNovo);

        }
       
        async void ExecuteSearchCommand()
        {
            await Task.Delay(1000);
            // await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou por '{SearchTerm}'.", "OK");
            bool resposta = await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou po '{SearchTerm}'?", "Sim", "Não");
            if (resposta)            
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "Obrigado", "Ok");
            else
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "Pesquise Novamente!", "OK");
        }

        bool CanExecuteSearchCommand()
        {          
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }
    }
}
