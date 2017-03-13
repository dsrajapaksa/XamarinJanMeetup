using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ForumSpeakerDetails
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ForumSpeakerDetails.MainPage();
        }
//On Start Method
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
