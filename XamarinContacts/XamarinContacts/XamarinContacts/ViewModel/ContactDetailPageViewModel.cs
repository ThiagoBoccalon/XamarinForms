using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinContacts.Model;

namespace XamarinContacts.ViewModel
{
    public class ContactDetailPageViewModel
    {
        public Command SaveContactCommand { get; set; }

        public Contact CurrentContact { get; set; }

        public INavigation Navigation { get; set; }

        public ContactDetailPageViewModel(INavigation navigation, Contact contact = null)
        {
            Navigation = navigation;
            if (contact == null)
            {
                CurrentContact = new Contact();
            }
            else
            {
                CurrentContact = contact;
            }
            
            
            SaveContactCommand = new Command(async () => await SaveContactCommandExecute());
        }

        public async Task SaveContactCommandExecute()
        {
            await App.Database.SaveItemAsync(CurrentContact);
            await Navigation.PopToRootAsync();
        }
    }
}
