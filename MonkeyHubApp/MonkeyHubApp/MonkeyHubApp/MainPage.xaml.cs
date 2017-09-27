using Xamarin.Forms;
using MonkeyHubApp.ViewModels;


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
