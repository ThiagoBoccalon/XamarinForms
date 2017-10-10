using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TimeScale.Model;
using TimeScale.ViewModel;

namespace TimeScale
{
   // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        public PlayerPage()
        {
            InitializeComponent();
            BindingContext = new PlayerViewModel();
        }

        private void CircleButton_Clicked(object sender, EventArgs e)
        {
            var player = new Player
            {
              //  Name = this.NamePlayer.Text,
            };

            using (var data = new AcessDB())
            {
                data.InsertPlayer(player);
            }
        }
    }
}