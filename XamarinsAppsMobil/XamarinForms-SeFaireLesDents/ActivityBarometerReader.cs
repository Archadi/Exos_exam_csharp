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
    [Activity(Label = "ActivityBarometerReader")]
    public class ActivityBarometerReader : Activity
    {
        private static TextView tvIsStarted, tvPressionHpa;
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_barometer);

            Button button = FindViewById<Button>(Resource.Id.btnHome);
            button.Click += delegate {
                //Barometer stop
                ToggleBarometer();
                StartActivity(typeof(MainActivity));
            };

            tvIsStarted = FindViewById<TextView>(Resource.Id.tvIsStarted);
            tvPressionHpa = FindViewById<TextView>(Resource.Id.tvPressionHpa);

            //Barometer start
            ToggleBarometer();
        }

        void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            // Process Pressure
            tvPressionHpa.Text = "Pression (hPa) : " + e.Reading.PressureInHectopascals.ToString();
        }

        public void ToggleBarometer()
        {
            try
            {
                if (Barometer.IsMonitoring)
                {
                    Barometer.ReadingChanged -= Barometer_ReadingChanged;
                    Barometer.Stop();
                    tvIsStarted.Text = "Start : No";
                }
                else
                {
                    Barometer.ReadingChanged += Barometer_ReadingChanged;
                    Barometer.Start(speed);
                    tvIsStarted.Text = "Start : Yes";
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                tvPressionHpa.Text = fnsEx.Message;
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                tvPressionHpa.Text = ex.Message;
            }
        }
    }
}