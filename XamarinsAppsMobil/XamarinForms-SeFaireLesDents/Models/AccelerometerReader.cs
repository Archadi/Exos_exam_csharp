using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace XamarinForms_SeFaireLesDents.Models
{
    class AccelerometerReader
    {

        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;

        //attributs
        public bool IsSTarded{get; set;}
        public float AccX { get; set; }
        public float AccY { get; set; }
        public float AccZ { get; set; }
        

        public AccelerometerReader()
        {
            // Register for reading changes, be sure to unsubscribe when finished
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            // Process Acceleration X, Y, and Z
            
            this.AccX = e.Reading.Acceleration.X;
            this.AccY = e.Reading.Acceleration.Y;
            this.AccZ = e.Reading.Acceleration.Z;
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                {
                    Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                    Accelerometer.Stop();
                    this.IsSTarded = false;
                }
                else
                {
                    Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
                    Accelerometer.Start(speed);
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