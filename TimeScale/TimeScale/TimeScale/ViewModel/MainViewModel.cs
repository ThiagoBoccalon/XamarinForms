
using Xamarin.Forms;

namespace TimeScale.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        private string _position;


        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (SetProperty(ref _position, value))
                    PositionCommand.ChangeCanExecute();
            }
        }

        public Command PositionCommand
        {
            get;
        }
        

        public MainViewModel()
        {
            PositionCommand = new Command(ExecutePositionCommand);
        }

        async void ExecutePositionCommand()
        {
            
        }
    }
}
