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
    [Activity(Label = "ActivityGyroscopeReader")]
    public class ActivityGyroscopeReader : Activity
    {
        private static TextView tvIsStarted, tvVecX, tvVecY, tvVecZ;
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_gyroscope);

            Button button = FindViewById<Button>(Resource.Id.btnHome);
            button.Click += delegate {
                // stop
                ToggleGyroscope();
                StartActivity(typeof(MainActivity));
            };

            //coordonnées Y X Z de l'Vecelerometrereader
            tvIsStarted = FindViewById<TextView>(Resource.Id.tvIsStarted);
            tvVecX = FindViewById<TextView>(Resource.Id.tvVecX);
            tvVecY = FindViewById<TextView>(Resource.Id.tvVecY);
            tvVecZ = FindViewById<TextView>(Resource.Id.tvVecZ);

            // start
            ToggleGyroscope();
        }

        void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            tvVecX.Text = "Vecteur X : " + e.Reading.AngularVelocity.X.ToString();
            tvVecY.Text = "Vecteur Y : " + e.Reading.AngularVelocity.Y.ToString();
            tvVecZ.Text = "Vecteur Z : " + e.Reading.AngularVelocity.Z.ToString();
        }

        public void ToggleGyroscope()
        {
            try
            {
                if (Gyroscope.IsMonitoring)
                {
                    Gyroscope.ReadingChanged -= Gyroscope_ReadingChanged;
                    Gyroscope.Stop();
                    tvIsStarted.Text = "Start : No";
                }
                else
                {
                    Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
                    Gyroscope.Start(speed);
                    tvIsStarted.Text = "Start : Yes";
                }
                    
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                tvVecX.Text = fnsEx.Message;
            }
            catch (Exception ex)
            {
                // Other error has occurred.
                tvVecX.Text = ex.Message;
            }
        }
    }
}