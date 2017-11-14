using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MeuTime.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public DelegateCommand NavigateToPlayerPageCommand { get; private set; }
        public DelegateCommand NavigateToScalePageCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "MainPage";
            _navigationService = navigationService;
            NavigateToPlayerPageCommand = new DelegateCommand(NavigateToPlayerPage);
            NavigateToScalePageCommand = new DelegateCommand(NavigateToScalePage);
        }

        private void NavigateToPlayerPage()
        {
            _navigationService.NavigateAsync("PlayerPage");
        }

        private void NavigateToScalePage()
        {
            _navigationService.NavigateAsync("ScalePage");
        }

    }
}
