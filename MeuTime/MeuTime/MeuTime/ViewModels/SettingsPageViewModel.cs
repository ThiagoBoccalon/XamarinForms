using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MeuTime.ViewModels
{
	public class SettingsPageViewModel : BindableBase
    {
        bool _isOwned;
        private INavigationService _navigationService;
        public DelegateCommand ResetCommand { get; private set; }
        

        public SettingsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ResetCommand = new DelegateCommand(ExecuteResetCommand);
        
        }

        public bool IsOwned
        {
            get
            {
                return _isOwned;
            }
            set
            {
                _isOwned = value;
            }
        } 


        private void ExecuteResetCommand()
        {
            //bool answer = await App.Current.MainPage.DisplayAlert("Meu Time", "Deseja mesmo excluir todos os jogadores?", "Sim", "Não");

            if (_isOwned)
            {
                using (var data = new AcessDataBase())
                {
                    data.DropTable();
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Meu Time", "Os jogadores não foram excluídos","OK");
            }

        }
    }
}
