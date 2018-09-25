using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android;

namespace XamarinMapas.Droid
{
    [Activity(Label = "XamarinMapas", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessCoarseLocation }, 1);
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessFineLocation }, 1);
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessMockLocation }, 1);

            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessLocationExtraCommands }, 1);
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessNetworkState }, 1);

            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.AccessWifiState }, 1);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //#### Necessário para trabalhar com o Xamarin.Essentials no Android #####
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            LoadApplication(new App());
        }


        //#### Necessário para trabalhar com o Xamarin.Essentials no Android #####
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, 
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}