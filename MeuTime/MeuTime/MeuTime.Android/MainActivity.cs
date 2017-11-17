using Android.App;
using Android.Content.PM;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Microsoft.Practices.Unity;
using Prism.Unity;


namespace MeuTime.Droid
{
    [Activity(Label = "MeuTime", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);            
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircleRenderer.Init();
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
            // Register any platform specific implementations
        }
    }
}

