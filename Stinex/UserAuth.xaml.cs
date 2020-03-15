using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.LocalNotifications;

namespace Stinex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserAuth : ContentPage
    {
        public UserAuth()
        {
             InitializeComponent();
        }

        void OnEntryEmailTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void OnEntryEmailCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }
        void OnEntryPasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }

        void OnEntryPasswordCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
        }
        async void OnButtonClicked(object sender, EventArgs e)
        {
            BadLogOrPassAnimation(sender);
            await Navigation.PushAsync(new ControlPage("5C:CF:7F:3C:FF:E6"));
        }
        private async void BadLogOrPassAnimation(object sender)
        {
           // CrossLocalNotifications.Current.Show("title", "body", 101, DateTime.Now.AddSeconds(10));
            MyVibration();
            uint timeout = 50;

            await ((Button)sender).TranslateTo(-15, 0, timeout);
            await ((Button)sender).TranslateTo(15, 0, timeout);
            await ((Button)sender).TranslateTo(-10, 0, timeout);
            await ((Button)sender).TranslateTo(10, 0, timeout);
            await ((Button)sender).TranslateTo(-5, 0, timeout);
            await ((Button)sender).TranslateTo(5, 0, timeout);
            ((Button)sender).TranslationX = 0;
            
        }
        private void MyVibration()
        {
            try
            {
                // Use default vibration length
                //Vibration.Vibrate();

                // Or use specified time
                var duration = TimeSpan.FromMilliseconds(300);
                Vibration.Vibrate(duration);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
            
        }
    }
}