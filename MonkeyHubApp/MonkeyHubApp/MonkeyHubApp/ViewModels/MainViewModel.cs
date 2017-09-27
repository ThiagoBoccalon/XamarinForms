using System.Collections.ObjectModel;
using Xamarin.Forms;
using MonkeyHubApp.Services;


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
        
        public Command CleanCommand
        {
            get;
        }
        
        public Command AboutCommand
        {
            get;
        }

        private IMonkeyHubApiService _monkeyHubApiService;

        public MainViewModel()
        {
            // _monkeyHubApiService = monkeyHUbApiService;
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
            CleanCommand = new Command(ExecuteCleanCommand, CanExecuteCleanCommand);
            AboutCommand = new Command(ExecuteAboutCommand);
            Resultados = new ObservableCollection<string>();
        }

        async void ExecuteAboutCommand()
        {
            await PushAsync<AboutViewModel>();
        }

        async void ExecuteSearchCommand()
        {           
            bool resposta = await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou po '{SearchTerm}'?", "Sim", "Não");

            if (resposta)
            {
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "Obrigado", "Ok");
                
                /*var tagsRetornadasDoServico = await GetTagsAsync();
                Resultados.Clear();

                if (tagsRetornadasDoServico != null)
                {
                    foreach (var tag in tagsRetornadasDoServico)
                        Resultados.Add(tag);
                }
                */
            }
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

        void ExecuteCleanCommand()
        {           
            Resultados.Clear();
        }

        bool CanExecuteCleanCommand()
        {
            return true;
        }
    }
}
