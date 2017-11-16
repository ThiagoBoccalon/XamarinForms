using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeuTime.Models;

namespace MeuTime.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        int t = 0;

        public DelegateCommand NavigateToPlayerPageCommand { get; private set; }
        public DelegateCommand NavigateToScalePageCommand { get; private set; }
        public DelegateCommand ResetCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "MainPage";
            _navigationService = navigationService;
            NavigateToPlayerPageCommand = new DelegateCommand(ExecuteNavigateToPlayerPage);
            NavigateToScalePageCommand = new DelegateCommand(ExecuteNavigateToScalePage);
            ResetCommand = new DelegateCommand(ExecuteResetCommand);
        }

        private void ExecuteNavigateToPlayerPage()
        {           
            _navigationService.NavigateAsync("PlayerPage");
        }

        private void ExecuteNavigateToScalePage()
        {            
            _navigationService.NavigateAsync("ScalePage");
        }

      
        private void ExecuteResetCommand()
        {
            using(var data = new AcessDataBase())
            {
                data.DropTable();
            }
        }

    }
}
