using TimeScale.Model;

namespace TimeScale.ViewModel
{
    class ScaleViewModel : BaseViewModel
    {
        Scale scale = new Scale();

        public ScaleViewModel()
        {
            
            scale.ScaleDefender("GOL",2);
            scale.ScaleDefender("ZAG", 4);
            scale.ScaleMidfieldDefender("VOL", 2);
        }
    }
}
