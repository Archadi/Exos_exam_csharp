
using Xamarin.Essentials;
using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace XamarinForms_SeFaireLesDents
{
    [Activity(Label = "ActivityAccelerometerReader")]
    public class ActivityAccelerometerReader : Activity
    {
        private static TextView tvIsStarted, tvAccX, tvAccY, tvAccZ, tvcountShock;
        // Set speed delay for monitoring changes.
        SensorSpeed speed = SensorSpeed.UI;
        //variation importante lors du 
        //premier appelle de la fonction Accelerometer_ReadingChanged
        //donc choc non compté
        int countShock;
        float oldX, oldY, oldZ;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layout_accelerometer);

            Button button = FindViewById<Button>(Resource.Id.btnHome);
            button.Click += delegate {
                //Accelorometre stop
                ToggleAccelerometer();
                StartActivity(typeof(MainActivity));
            };

            //coordonnées Y X Z de l'accelerometrereader
            tvIsStarted = FindViewById<TextView>(Resource.Id.tvIsStarted);
            tvAccX = FindViewById<TextView>(Resource.Id.tvAccX);
            tvAccY = FindViewById<TextView>(Resource.Id.tvAccY);
            tvAccZ = FindViewById<TextView>(Resource.Id.tvAccZ);
            tvcountShock = FindViewById<TextView>(Resource.Id.tvcountShock);

            //Accelorometre start
            ToggleAccelerometer();


        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            float vrtX, vrtY, vrtZ;
            double seul = 2.15;
            

            // Process Acceleration X, Y, and z
            tvAccX.Text = "AccX : " + e.Reading.Acceleration.X.ToString();
            tvAccY.Text = "AccY : " + e.Reading.Acceleration.Y.ToString();
            tvAccZ.Text = "AccZ : " + e.Reading.Acceleration.Z.ToString();
           
            
            

            vrtX = e.Reading.Acceleration.X - oldX;
            vrtY = e.Reading.Acceleration.Y - oldY;
            vrtZ = e.Reading.Acceleration.Z - oldZ;

            oldX = e.Reading.Acceleration.X;
            oldY = e.Reading.Acceleration.Y;
            oldZ = e.Reading.Acceleration.Z;

            if (Math.Abs(vrtX) >= seul || Math.Abs(vrtY) >= seul || Math.Abs(vrtZ) >= seul)
                countShock++;

            if (countShock > 3)
                countShock = 0;

            tvcountShock.Text = "Count shock : " + countShock.ToString();

        }


        void ToggleAccelerometer()
        {
            if (Accelerometer.IsMonitoring)
            {
                Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
                Accelerometer.Stop();
                tvIsStarted.Text = "Start : No";
            }
            else
            {
                Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
                Accelerometer.Start(speed);
                tvIsStarted.Text = "Start : Yes";

            }
        }

    }
}