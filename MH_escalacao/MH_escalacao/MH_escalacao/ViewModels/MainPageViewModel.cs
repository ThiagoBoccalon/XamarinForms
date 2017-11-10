using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MH_escalacao.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {        
        private readonly INavigationService _navigationService;
        public DelegateCommand NavigateToPlayerCommand { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToPlayerCommand = new DelegateCommand(NavigateToPlayerPage);
        }

        private void NavigateToPlayerPage()
        {
            _navigationService.NavigateAsync("PlayerPage");
        }

        private void Player()
        {
            _navigationService.NavigateAsync("Player");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }


    }
}
