using Xamarin.Forms;

namespace EscalaTime.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Command PlayerCommand
        {
            get;
        }

        public MainViewModel()
        {
            PlayerCommand = new Command(ExecutePlayerCommand);
        }

        async void ExecutePlayerCommand()
        {
            await PushAsync<PlayerViewModel>();
        }
    }
}
