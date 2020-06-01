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
    [Activity(Label = "ActivityCompassReader")]
    public class ActivityCompassReader : Activity
    {
        private static TextView tvIsStarted, tvCapNordMagnetique;
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_Compass);

            Button button = FindViewById<Button>(Resource.Id.btnHome);
            button.Click += delegate {
                //stop
                ToggleCompass();
                StartActivity(typeof(MainActivity));
            };

            tvIsStarted = FindViewById<TextView>(Resource.Id.tvIsStarted);
            tvCapNordMagnetique = FindViewById<TextView>(Resource.Id.tvCapNordMagnetique);
            //start
            ToggleCompass();
        }

        void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            tvCapNordMagnetique.Text = "Cap nord magnétique : "+ e.Reading.HeadingMagneticNorth.ToString();
        }

        public void ToggleCompass()
        {
            try
            {
                if (Compass.IsMonitoring)
                {
                    Compass.ReadingChanged -= Compass_ReadingChanged;
                    Compass.Stop();
                    tvIsStarted.Text = "Start : No";
                }
                else
                {
                    Compass.ReadingChanged += Compass_ReadingChanged;
                    Compass.Start(speed);
                    tvIsStarted.Text = "Start : Yes";

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                tvCapNordMagnetique.Text = fnsEx.Message;
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                tvCapNordMagnetique.Text = ex.Message;
            }
        }
    }
}