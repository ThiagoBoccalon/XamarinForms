﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinContacts.Helpers;
using XamarinContacts.Model;
using XamarinContacts.View;

namespace XamarinContacts.ViewModel
{
    public class ContactsPageViewModel
    {
        public ObservableCollection<Grouping<string, Contact>>  ContactsList   { get; set; }

        public Contact CurrentContact { get; set; }

        public Command AddContactCommand { get; set; }

        public Command ItemTappedCommand { get; }

        public INavigation Navigation { get; set; }

        public ContactsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Task.Run(async () =>
                ContactsList = await App.Database.GetItemsGroupedAsync()).Wait();

            AddContactCommand = new Command(async() => await GoToContactDetailPage());

            ItemTappedCommand = new Command(async () => await GoToContactDetailPage(CurrentContact));
        }

        public async Task GoToContactDetailPage(Contact contact = null)
        {
            if(contact == null)
            {
                await Navigation.PushAsync(new ContactDetailPage());
            }
            else
            {
                await Navigation.PushAsync(new ContactDetailPage(CurrentContact));
            }
            
        }
    }
}
