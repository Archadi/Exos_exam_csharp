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

namespace XamarinForms_SeFaireLesDents
{
    [Activity(Label = "ActivityInfoApp")]
    public class ActivityInfoApp : Activity
    {
        private static EditText etAppName, etPckName, etVersion, etBuild;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_app_info);

            Button button = FindViewById<Button>(Resource.Id.btnHome);
            button.Click += delegate {
                StartActivity(typeof(MainActivity));
            };

            var appName = Xamarin.Essentials.AppInfo.Name;
            var packageName = Xamarin.Essentials.AppInfo.PackageName;
            var version = Xamarin.Essentials.AppInfo.VersionString;
            var build = Xamarin.Essentials.AppInfo.BuildString;

            Xamarin.Essentials.AppTheme appTheme = Xamarin.Essentials.AppInfo.RequestedTheme;
            
            
            etAppName = FindViewById<EditText>(Resource.Id.etAppName);
            etAppName.Text = appName;

            etPckName = FindViewById<EditText>(Resource.Id.etPckName);
            etPckName.Text = packageName;

            etVersion = FindViewById<EditText>(Resource.Id.etVersion);
            etVersion.Text = version;

            etBuild = FindViewById<EditText>(Resource.Id.etBuild);
            etBuild.Text = build;
        }
    }
}