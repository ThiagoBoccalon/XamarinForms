using Xamarin.Forms;
using MonkeyHubApp.ViewModels;
using MonkeyHubApp.Services;


namespace MonkeyHubApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }       
    }
}
