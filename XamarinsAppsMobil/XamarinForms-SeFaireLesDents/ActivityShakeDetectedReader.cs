using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace XamarinForms_SeFaireLesDents
{
    [Activity(Label = "ActivityShakeDetectedReader")]
    public class ActivityShakeDetectedReader : Activity
    {
        private static TextView tvIsStarted, tvShakeDetectedMsg;
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.Game;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_shake_detected);

            Button button = FindViewById<Button>(Resource.Id.btnHome);
            button.Click += delegate {
                //Barometer stop
                ToggleAccelerometer();
                StartActivity(typeof(MainActivity));
            };

            tvIsStarted = FindViewById<TextView>(Resource.Id.tvIsStarted);
            tvShakeDetectedMsg = FindViewById<TextView>(Resource.Id.tvShakeDetectedMsg);

            //Barometer start
            ToggleAccelerometer();
        }

        void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            // Process shake event
            tvShakeDetectedMsg.Text = "Secousse detecté !";
            // Use default vibration length
            Vibration.Vibrate();

            // Or use specified time
            var duration = TimeSpan.FromSeconds(3);
            Vibration.Vibrate(duration);
            tvShakeDetectedMsg.Text = "";

        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                {
                    Accelerometer.ShakeDetected -= Accelerometer_ShakeDetected;
                    Accelerometer.Stop();
                    tvIsStarted.Text = "Start : No";
                }
                else
                {
                    Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
                    Accelerometer.Start(speed);
                    tvIsStarted.Text = "Start : Yes";
                }
                    
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                tvShakeDetectedMsg.Text = fnsEx.Message;
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                tvShakeDetectedMsg.Text = ex.Message;
            }
        }
    }
}