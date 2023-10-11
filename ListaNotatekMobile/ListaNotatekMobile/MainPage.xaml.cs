using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListaNotatekMobile
{
    public partial class MainPage : ContentPage
    {


        private ObservableCollection<string> simpleTextCollection;
        public ObservableCollection<string> SimpleTextCollection
        {
            get { return simpleTextCollection; }
            set
            {
                simpleTextCollection = value;
                OnPropertyChanged(nameof(SimpleTextCollection));
            }
        }


        private ICommand addNoteCommand;
        public ICommand AddNoteCommand
        {
            get
            {
                if (addNoteCommand == null)
                    addNoteCommand = new Command<object>(
                        o =>
                        {
                            SimpleTextCollection.Add(EntryNewNote.Text);
                        }
                        );
                return addNoteCommand;
            }
        }
        public MainPage()
        {
            SimpleTextCollection = new ObservableCollection<string>();
            SimpleTextCollection.Add("Zakupy: chleb, masło, ser");
            SimpleTextCollection.Add("Do zrobienia: obiad, umyć podłogę");
            SimpleTextCollection.Add("Weekend: kino, spacer z psem, piwo");
            InitializeComponent();
        }

        private void ButtonAddNote_Clicked(object sender, EventArgs e)
        {

        }
    }
}
