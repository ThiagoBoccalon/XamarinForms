using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TimeScale.Model;

namespace TimeScale.ViewModel
{
    public class PlayerViewModel : BaseViewModel
    {
        private string _position;                
        private string myname;

        public string MyName
        {
            get
            {
                return myname;
            }
            set
            {
                if (myname != value)
                {
                    myname = value;
                    OnPropertyChanged(myname);
                }
            }
        }

        private decimal _sliderAttack;
        public decimal SliderAttack
        {
            get
            {
                return _sliderAttack;
            }
            set
            {
                if(_sliderAttack != value)
                {
                    _sliderAttack = value;
                    RaisePropertyChanged();
                }
            }
        }
           
        public Command GoleiroCommand
        {
            get;
        }

        public Command LateralEsqCommand
        {
            get;
        }

        public Command ZagueiroCommand
        {
            get;
        }

        public Command LateralDirCommand
        {
            get;
        }

        public Command VolanteCommand
        {
            get;
        }

        public Command MeioCommand
        {
            get;
        }

        public Command AtaqueCommand
        {
            get;
        }

        public Command SaveCommand
        {
            get;
        }

        public Command PositionCommand
        {
            get;
        }

      

        public PlayerViewModel()
        {            
            PositionCommand = new Command(ExecutePositionCommand);
            GoleiroCommand = new Command(ExecuteGoleiroCommand);
            LateralEsqCommand = new Command(ExecuteLateralEsqCommand);
            ZagueiroCommand = new Command(ExecuteZagueiroCommand);
            LateralDirCommand = new Command(ExecuteLateralDirCommand);
            VolanteCommand = new Command(ExecuteVolanteCommand);
            MeioCommand = new Command(ExecuteMeioCommand);
            AtaqueCommand = new Command(ExecuteAtaqueCommand);
            SaveCommand = new Command(ExecuteSaveCommand);            
        }

        async void ExecutePositionCommand()
        {
           // _position.Add("goleiro");
        }

        async void ExecuteGoleiroCommand()
        {
            _position = _position + "GOL";
        }

        async void ExecuteLateralEsqCommand()
        {
            _position = _position + "LE";
        }

        async void ExecuteZagueiroCommand()
        {
            _position = _position + "ZAG";
        }

        async void ExecuteLateralDirCommand()
        {
            _position = _position + "LD";
        }

        async void ExecuteVolanteCommand()
        {            
           _position = _position + "VOL";         
        }

        async void ExecuteMeioCommand()
        {
            _position = _position + "MC";
        }

        async void ExecuteAtaqueCommand()
        {
            _position = _position + "ATA";
        }

        async void ExecuteSaveCommand()
        {
            Random random = new Random();

            var player = new Player
            {
                Name = myname.ToString(),
                Position = _position,
                Attack = random.Next(1,10),
                Defender = random.Next(1,10),
            };

            using (var data = new AcessDB())
            {
                data.InsertPlayer(player);
            }

            // save no BD antes
            _position = "";
          
            await PopAsync<PlayerViewModel>();
        }


    }
}
