using ForumSpeakerDetails.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ForumSpeakerDetails.ViewModel
{
    public class SpeakersViewModel : INotifyPropertyChanged
    {
        //Property Change Event Handeler for INotify Property Changed 
        public event PropertyChangedEventHandler PropertyChanged;

        //On Property Changed Event to trigger the Property Change
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        //Get Speakers Command
        public Command GetSpeakersCommand { get; set; }

        //Observarable Collaection of Speakers
        public ObservableCollection<Speaker> Speakers { get; set; }

        //Constructor 
        public SpeakersViewModel()
        {
            Speakers = new ObservableCollection<Speaker>();
            GetSpeakersCommand = new Command(async () => await GetSpeakers(),
                () => !IsBusy);

        }


        private bool _busy;
        public bool IsBusy
        {
            get { return _busy; }
            set
            {
                _busy = value;
                OnPropertyChanged();
                GetSpeakersCommand.ChangeCanExecute();
            }
        }

        //Get Speakers from the Web Service 
        private async Task GetSpeakers()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                using (var client = new HttpClient())
                {
                    //grab json from server
                    var json = await client.GetStringAsync("http://demo1444148.mockable.io/netforumjan");

                    //Deserialize json
                    var items = JsonConvert.DeserializeObject<List<Speaker>>(json);

                    //Load speakers into list
                    Speakers.Clear();
                    foreach (var item in items)
                        Speakers.Add(item);
                }
            }
            catch (Exception ex)
            {
                if (Application.Current?.MainPage == null)
                    throw ex;

                await Application.Current.MainPage.DisplayAlert("Error !", ex.Message, "OK");

            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
