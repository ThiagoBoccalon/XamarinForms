using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _seachTerm;

        public string SearchTerm
        {
            get
            {
                return _seachTerm;
            }
            set
            {
                if(SetProperty(ref _seachTerm, value))
                    SearchCommand.ChangeCanExecute();
            }
        }

        public Command SearchCommand
        {
            get;
        }

        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
        }
       
        void ExecuteSearchCommand()
        {
            // quando o botão é executado
        }

        bool CanExecuteSearchCommand()
        {          
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }
    }
}
