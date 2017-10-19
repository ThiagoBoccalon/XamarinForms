using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TimeScale.ViewModel;

namespace TimeScale.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeSlider : ContentPage
    {
        public HomeSlider()
        {
            InitializeComponent();
            BindingContext = new HomeSliderViewModel();
        }
    }
}