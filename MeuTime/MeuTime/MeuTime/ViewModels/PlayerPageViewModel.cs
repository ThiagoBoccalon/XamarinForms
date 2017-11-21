using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using MeuTime.Models;
using Xamarin.Forms;

namespace MeuTime.ViewModels
{
	public class PlayerPageViewModel : BindableBase
	{
        public static int gol_number, zag_number, ld_number, le_number,
                            vol_number, mc_number, ata_number;

        private INavigationService _navigationService;
        public DelegateCommand NavigateToMainPageCommand { get; private set; }

        private string _position;
        private string _nameplayer;
        private bool _setPosition = false;

        public string NamePlayer
        {
            get { return _nameplayer;  }
            set { _nameplayer = value; }
        }

        private decimal _sliderAttack, _sliderDefender, _sliderSpeed;

        public decimal SliderAttack
        {
            get { return _sliderAttack; }
            set { if (_sliderAttack != value) _sliderAttack = value; RaisePropertyChanged(); }
        }

        public decimal SliderDefender
        {
            get { return _sliderDefender; }
            set { if (_sliderDefender != value) _sliderDefender = value; RaisePropertyChanged(); }
        }

        public decimal SliderSpeed
        {
            get { return _sliderSpeed; }
            set { if (_sliderSpeed != value) _sliderSpeed = value; RaisePropertyChanged(); }
        }

        public DelegateCommand GoleiroCommand { get; }
        public DelegateCommand ZagueiroCommand { get; }
        public DelegateCommand LateralEsqCommand { get; }
        public DelegateCommand LateralDirCommand { get; }
        public DelegateCommand VolanteCommand { get; }
        public DelegateCommand MeioCommand { get; }
        public DelegateCommand AtaqueCommand { get; }        
        public Command SavePlayerCommand { get; }

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
            SavePlayerCommand = new Command(ExecuteSavePlayerCommand);
        }

        private void ExecuteGoleiroCommand() { _position += "GOL"; _setPosition = true; gol_number++; }
        private void ExecuteZagueiroCommand() { _position += "ZAG"; _setPosition = true; zag_number++; }
        private void ExecuteLateralEsqCommand() { _position += "LE"; _setPosition = true; le_number++; }
        private void ExecuteLateralDirCommand() { _position += "LD"; _setPosition = true; ld_number++; }
        private void ExecuteVolanteCommand() { _position += "VOL"; _setPosition = true; vol_number++; }
        private void ExecuteMeioCommand() { _position += "MC"; _setPosition = true; mc_number++; }
        private void ExecuteAtaqueCommand() { _position += "ATA"; _setPosition = true; ata_number++; }

        async void ExecuteSavePlayerCommand()
        {
            NewPlayer();
            await _navigationService.GoBackToRootAsync();
        }

        private void NewPlayer()
        {
            decimal alpha = 0;
            if (!_setPosition)
            {
                App.Current.MainPage.DisplayAlert("Meu Time", "Faltou definir a posição do jogador", "OK");
                return;
            }

            var player = new Player
            {

                Name = _nameplayer.ToString(),
                Position = _position.ToString(),
                Attack = _sliderAttack,
                Defender = _sliderDefender,
                Speed = _sliderSpeed,
                Score = _sliderAttack + _sliderSpeed + _sliderSpeed                
            };

            using (var data = new AcessDataBase())
                data.InsertPlayer(player);

            _position = "";
        }
    }
}
