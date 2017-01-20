using ForumSpeakerDetails.Model;
using ForumSpeakerDetails.View;
using ForumSpeakerDetails.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ForumSpeakerDetails
{
    public partial class MainPage : ContentPage
    {
        SpeakersViewModel vm;
        public MainPage()
        {
            InitializeComponent();

            vm = new SpeakersViewModel();
            BindingContext = vm;
        }

        private async void ListViewSpeakers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var speaker = e.SelectedItem as Speaker;
            if (speaker == null)
                return;

            await Navigation.PushModalAsync(new SpeakerDetails(speaker));

            ListViewSpeakers.SelectedItem = null;
        }
    }
}
