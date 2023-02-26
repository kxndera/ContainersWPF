using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ListOfContacts
{
    internal class MainViewModel : BindableObject
    {
        public ObservableCollection<Contact> CollectionOfContacts { get; set; }


        private Contact selectedContact;

        public Contact SelectedContact
        {
            get 
            { return selectedContact; 
            }

            set
            { selectedContact = value;
                OnPropertyChanged();
            }
        }

        private string  smsText;
        public string SmsText
        {
            get 
            { 
                return smsText;
            }
            set 
            { 
                smsText = value;
               OnPropertyChanged();
            }
        }

        private ICommand sendSmsCommand;
        public ICommand SendSmsCommand
        {
            get
            {
                if (sendSmsCommand == null)
                    sendSmsCommand = new Command<object>
                        ( async o =>
                       {
                           try
                           {
                               string phoneNumber = "";
                               if (SelectedContact != null)
                                   phoneNumber = SelectedContact.Phones[0].PhoneNumber;

                               var message = new SmsMessage(SmsText, phoneNumber);
                               await Sms.ComposeAsync(message);
                           }
                           catch (FeatureNotSupportedException ex)
                           {
                               
                           }
                           catch (Exception ex)
                           {
                               
                           }
                       });
                return sendSmsCommand;
            }

        }


        private ICommand phoneCallCommand;

        public ICommand PhoneCallCommand 
        { 
            get 
            {
                if (phoneCallCommand == null) phoneCallCommand = new Command<Contact>(
                    contact =>
                    {
                        try
                        {
                            PhoneDialer.Open(contact.Phones[0].PhoneNumber);
                        }
                        catch (Exception)
                        {

                           
                        }
                    });
            return phoneCallCommand;
                        }
        }
        public MainViewModel()
        {
            try
            {
                //Contacts.PickContactAsync();
                CollectionOfContacts = new ObservableCollection<Contact>();
                var contacts = Contacts.GetAllAsync().Result;
                if (contacts == null)
                  return;
                

                foreach (var item in contacts)
                {
                    CollectionOfContacts.Add(item);
                }
            }
            catch (Exception)
            {

             
            }
        }
    }
}
