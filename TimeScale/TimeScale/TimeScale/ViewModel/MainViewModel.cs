
using Xamarin.Forms;

namespace TimeScale.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public Command PlayerCommand
        {
            get;
        }

        public Command Scale
        {
            get;
        }

        public MainViewModel()
        {
            PlayerCommand = new Command(ExecutePlayerCommand);
            // Scale = new Command(ExecuteTimeScaleCommand, CanExecuteScaleCommand);
        }

        async void ExecutePlayerCommand()
        {
            await PushAsync<PlayerViewModel>();
        }


    }
}
