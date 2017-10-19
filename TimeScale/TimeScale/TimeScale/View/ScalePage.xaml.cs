using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TimeScale.ViewModel;

namespace TimeScale
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScalePage : ContentPage
	{
		public ScalePage ()
		{
			InitializeComponent();
            BindingContext = new ScaleViewModel();            
        }


	}
}