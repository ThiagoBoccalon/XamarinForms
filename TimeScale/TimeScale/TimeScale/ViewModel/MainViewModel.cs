
using Xamarin.Forms;

namespace TimeScale.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public static int _numberPlayer;

        public int NumberPlayer
        {
            get
            {
                return _numberPlayer;
            }
            set
            {
                if (SetProperty(ref _numberPlayer, value))
                    ScaleCommand.ChangeCanExecute();
            }
        }

        public Command PlayerCommand
        {
            get;
        }

        public Command ScaleCommand
        {
            get;
        }

        public MainViewModel()
        {
            PlayerCommand = new Command(ExecutePlayerCommand);
            ScaleCommand = new Command(ExecuteScaleCommand, CanExecuteScaleCommand);
        }

        async void ExecutePlayerCommand()
        {   
            await PushAsync<PlayerViewModel>();
        }

        async void ExecuteScaleCommand()
        {
            await PopAsync<MainViewModel>();
        }

        bool CanExecuteScaleCommand()
        {
            return true;
        }

    }
}
