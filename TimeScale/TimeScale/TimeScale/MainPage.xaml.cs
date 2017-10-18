using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TimeScale.ViewModel;
using TimeScale.Model;

namespace TimeScale
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation?.PushAsync(new ScalePage());
        }
    }
}
