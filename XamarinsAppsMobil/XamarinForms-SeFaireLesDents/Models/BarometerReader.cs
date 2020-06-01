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

namespace XamarinForms_SeFaireLesDents.Models
{
    class BarometerReader
    {
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        public bool IsSTarded { get; set; }
        public double PressureHectopascals { get; set; }
        public BarometerReader()
        {
            // Register for reading changes.
            Barometer.ReadingChanged += Barometer_ReadingChanged;
        }

        void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            // Process Pressure
            this.PressureHectopascals = e.Reading.PressureInHectopascals;
        }

        public void ToggleBarometer()
        {
            try
            {
                if (Barometer.IsMonitoring){ 
                    Barometer.ReadingChanged -= Barometer_ReadingChanged;
                    Barometer.Stop();
                    this.IsSTarded = false;
                }
                else
                {
                    Barometer.ReadingChanged += Barometer_ReadingChanged;
                    Barometer.Start(speed);
                    this.IsSTarded = true;
                }
                    
            }
            catch (FeatureNotSupportedException fnsEx)
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