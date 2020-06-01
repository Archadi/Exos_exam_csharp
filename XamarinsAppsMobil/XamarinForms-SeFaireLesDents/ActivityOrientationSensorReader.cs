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
    [Activity(Label = "ActivityOrientationSensorReader")]
    
    public class ActivityOrientationSensorReader : Activity
    {
        private static TextView tvIsStarted, tvCapteurOrientationX, tvCapteurOrientationY, tvCapteurOrientationZ;
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_orientation_sensor);

            Button button = FindViewById<Button>(Resource.Id.btnHome);
            button.Click += delegate {
                //stop
                ToggleOrientationSensor();
                StartActivity(typeof(MainActivity));
            };

            //coordonnées Y X Z de l'CapteurOrientationelerometrereader
            tvIsStarted = FindViewById<TextView>(Resource.Id.tvIsStarted);
            tvCapteurOrientationX = FindViewById<TextView>(Resource.Id.tvCapteurOrientationX);
            tvCapteurOrientationY = FindViewById<TextView>(Resource.Id.tvCapteurOrientationY);
            tvCapteurOrientationZ = FindViewById<TextView>(Resource.Id.tvCapteurOrientationZ);

            //start
            ToggleOrientationSensor();
        }

        void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            var data = e.Reading;
            tvCapteurOrientationX.Text = "Orientation X : " + e.Reading.Orientation.X.ToString();
            tvCapteurOrientationY.Text = "Orientation Y : " + e.Reading.Orientation.X.ToString();
            tvCapteurOrientationZ.Text = "Orientation Z : " + e.Reading.Orientation.X.ToString();
        }

        public void ToggleOrientationSensor()
        {
            try
            {
                if (OrientationSensor.IsMonitoring)
                {
                    OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
                    OrientationSensor.Stop();
                    tvIsStarted.Text = "Start : No";
                }
                else
                {
                    OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
                    OrientationSensor.Start(speed);
                    tvIsStarted.Text = "Start : Yes";
                }
                    
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                tvCapteurOrientationX.Text = fnsEx.Message;
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                tvCapteurOrientationX.Text = ex.Message;
            }
        }
    }
}