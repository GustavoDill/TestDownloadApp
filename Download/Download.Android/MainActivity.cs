
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace Download.Droid
{
    [Activity(Label = "Download Archive", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        PermissionHandler permissionHandler;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            permissionHandler = new PermissionHandler(this, new string[] { Manifest.Permission.WriteExternalStorage, Manifest.Permission.Internet });
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) => permissionHandler.RequestPermissionResult(requestCode, permissions, grantResults);
    }
}