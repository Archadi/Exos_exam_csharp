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
    [Activity(Label = "ActivityMagnetometerReader")]
    public class ActivityMagnetometerReader : Activity
    {
        private static TextView tvIsStarted, tvOrientationMagnetiqueX, tvOrientationMagnetiqueY, tvOrientationMagnetiqueZ;
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_magnetometer);

            Button button = FindViewById<Button>(Resource.Id.btnHome);
            button.Click += delegate {
                // stop
                ToggleMagnetometer();
                StartActivity(typeof(MainActivity));
            };

            //coordonnées Y X Z de l'OrientationMagnetiqueelerometrereader
            tvIsStarted = FindViewById<TextView>(Resource.Id.tvIsStarted);
            tvOrientationMagnetiqueX = FindViewById<TextView>(Resource.Id.tvOrientationMagnetiqueX);
            tvOrientationMagnetiqueY = FindViewById<TextView>(Resource.Id.tvOrientationMagnetiqueY);
            tvOrientationMagnetiqueZ = FindViewById<TextView>(Resource.Id.tvOrientationMagnetiqueZ);

            // start
            ToggleMagnetometer();
        }

        void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            tvOrientationMagnetiqueX.Text = "Orientation Magnétique X" + e.Reading.MagneticField.X.ToString();
            tvOrientationMagnetiqueY.Text = "Orientation Magnétique Y" + e.Reading.MagneticField.Y.ToString();
            tvOrientationMagnetiqueZ.Text = "Orientation Magnétique Z" + e.Reading.MagneticField.Z.ToString();
        }


        public void ToggleMagnetometer()
        {
            try
            {
                if (Magnetometer.IsMonitoring)
                {
                    Magnetometer.ReadingChanged -= Magnetometer_ReadingChanged;
                    Magnetometer.Stop();
                    tvIsStarted.Text = "Start : No";
                }
                else
                {
                    Magnetometer.ReadingChanged += Magnetometer_ReadingChanged;
                    Magnetometer.Start(speed);
                    tvIsStarted.Text = "Start : Yes";
                }

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                tvOrientationMagnetiqueX.Text = fnsEx.Message;
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                tvOrientationMagnetiqueX.Text = ex.Message;
            }
        }
    }
}