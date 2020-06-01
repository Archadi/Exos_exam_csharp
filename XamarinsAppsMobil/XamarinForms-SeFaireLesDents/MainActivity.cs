using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Media;

namespace XamarinForms_SeFaireLesDents
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    
    public class MainActivity : AppCompatActivity
    {
        MediaPlayer player;
    protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button btnAppAccelerometer = FindViewById<Button>(Resource.Id.btnAppAccelerometer);
            btnAppAccelerometer.Click += delegate {
                StartActivity(typeof(ActivityAccelerometerReader));
            };

            Button btnAppInfo = FindViewById<Button>(Resource.Id.btnAppInfo);
            btnAppInfo.Click += delegate {
                StartActivity(typeof(ActivityInfoApp));
            };

            Button btnAppBarometer = FindViewById<Button>(Resource.Id.btnAppBarometer);
            btnAppBarometer.Click += delegate {
                StartActivity(typeof(ActivityBarometerReader));
            };

            Button btnAppBoussole = FindViewById<Button>(Resource.Id.btnAppBoussole);
            btnAppBoussole.Click += delegate {
                StartActivity(typeof(ActivityCompassReader));
            };

            Button btnAppSecousse = FindViewById<Button>(Resource.Id.btnAppSecousse);
            btnAppSecousse.Click += delegate {
                StartActivity(typeof(ActivityShakeDetectedReader));
            };

            Button btnAppGyroscope = FindViewById<Button>(Resource.Id.btnAppGyroscope);
            btnAppGyroscope.Click += delegate {
                StartActivity(typeof(ActivityGyroscopeReader));
            };

            Button btnAppMagnetometre = FindViewById<Button>(Resource.Id.btnAppMagnetometre);
            btnAppMagnetometre.Click += delegate {
                StartActivity(typeof(ActivityMagnetometerReader));
            };

            Button btnAppCapteurOrientation = FindViewById<Button>(Resource.Id.btnAppCapteurOrientation);
            btnAppCapteurOrientation.Click += delegate {
                StartActivity(typeof(ActivityOrientationSensorReader));
            };

            //céation du média player
            player = MediaPlayer.Create(this, Resource.Raw.Voice02_08);
            Button btnAppPlayMedia = FindViewById<Button>(Resource.Id.btnAppPlayMedia);
            btnAppPlayMedia.Click += delegate {
                player.Start();
            };
            player.Release();


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}