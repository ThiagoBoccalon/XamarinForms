using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuTime.ViewModels
{
	public class PlayerPageViewModel : BindableBase
	{
        private INavigationService _navigationService;
        public DelegateCommand NavigateToMainPageCommand { get; private set; }

        private string _position;
        private string _nameplayer;

        public string NamePlayer
        {
            get { return _nameplayer;  }
            set { _nameplayer = value; }
        }

        public DelegateCommand GoleiroCommand { get; }
        public DelegateCommand ZagueiroCommand { get; }
        public DelegateCommand LateralEsqCommand { get; }
        public DelegateCommand LateralDirCommand { get; }
        public DelegateCommand VolanteCommand { get; }
        public DelegateCommand MeioCommand { get; }
        public DelegateCommand AtaqueCommand { get; }
        public DelegateCommand SavePlayerCommand { get; }

        public PlayerPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoleiroCommand = new DelegateCommand(ExecuteGoleiroCommand);
            ZagueiroCommand = new DelegateCommand(ExecuteZagueiroCommand);
            LateralEsqCommand = new DelegateCommand(ExecuteLateralEsqCommand);
            LateralDirCommand = new DelegateCommand(ExecuteLateralDirCommand);
            VolanteCommand = new DelegateCommand(ExecuteVolanteCommand);
            MeioCommand = new DelegateCommand(ExecuteMeioCommand);
            AtaqueCommand = new DelegateCommand(ExecuteAtaqueCommand);
            SavePlayerCommand = new DelegateCommand(ExecuteSavePlayerCommand);
        }

        private void ExecuteGoleiroCommand() { _position += "GOL"; }
        private void ExecuteZagueiroCommand() { _position += "ZAG"; }
        private void ExecuteLateralEsqCommand() { _position += "LE"; }
        private void ExecuteLateralDirCommand() { _position += "LD"; }
        private void ExecuteVolanteCommand() { _position += "VOL"; }
        private void ExecuteMeioCommand() { _position += "MC"; }
        private void ExecuteAtaqueCommand() { _position += "ATA"; }

        private void ExecuteSavePlayerCommand()
        {
            _navigationService.GoBackToRootAsync();
        }

    }
}
