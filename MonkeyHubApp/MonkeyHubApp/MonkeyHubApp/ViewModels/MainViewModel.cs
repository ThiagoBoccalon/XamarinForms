using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MonkeyHubApp.Models;
using System;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        /*
        private const string BaseUrl = "https://monkey-hub-api.azurewebsites.net/api/";

        public async Task<List<Tag>> GetTagsAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}Tags").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Tag>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

    */
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

        public MainViewModel()
        {
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
