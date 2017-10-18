using TimeScale.Model;

namespace TimeScale.ViewModel
{
    class ScaleViewModel : BaseViewModel
    {
        Scale scale = new Scale();

        public ScaleViewModel()
        {
            scale.ScaleGoal();

        }
    }
}
