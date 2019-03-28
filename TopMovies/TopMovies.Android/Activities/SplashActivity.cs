using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Media;


namespace TopMovies.Droid
{
    [Activity(Label = "Top Movies", Icon = "@mipmap/ic_launcher", Theme = "@style/SplashTheme",
              MainLauncher = true)]
    public class SplashActivity:AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var intent = new Intent(Application.Context, typeof(MainActivity));
            StartActivity(intent);
            Finish();

        }
    }
}
