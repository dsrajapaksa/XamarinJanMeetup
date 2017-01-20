using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumSpeakerDetails.Model;

using Xamarin.Forms;
using Plugin.TextToSpeech;

namespace ForumSpeakerDetails.View
{
    public partial class SpeakerDetails : ContentPage
    {
        Speaker speaker;
        public SpeakerDetails(Speaker speaker)
        {
            InitializeComponent();

            this.speaker = speaker;
            BindingContext = this.speaker;
            ButtonSpeak.Clicked += ButtonSpeak_Clicked;
            ButtonWebsite.Clicked += ButtonWebsite_Clicked;
        }

        private void ButtonSpeak_Clicked(object sender, EventArgs e)
        {
            CrossTextToSpeech.Current.Speak(this.speaker.Description);

        }

        private void ButtonWebsite_Clicked(object sender, EventArgs e)
        {
            if (speaker.Website.StartsWith("http"))
                Device.OpenUri(new Uri(speaker.Website));
        }

    }
}
