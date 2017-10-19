using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeScale.ViewModel
{
    class HomeSliderViewModel : BaseViewModel
    {
        private decimal _mySlider;

        public decimal MySlider
        {
            get
            {
                return _mySlider;
            }
            set
            {
                if(_mySlider != value)
                {
                    _mySlider = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
