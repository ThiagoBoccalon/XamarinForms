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

        private void Button_OnClicked(object sender, System.EventArgs e)
        {
            Navigation?.PushAsync(new MainPage());
        }
        
        public void ButtonModal_OnClicked(object sender, System.EventArgs e)
        {
            Navigation?.PushModalAsync(new NavigationPage(new MainPage()));
        }

        private void Button_VoltaModal(object sender, System.EventArgs e)
        {

            Navigation?.PopModalAsync();
        }
    }
}
