using System;
using System.Collections.Generic;
using System.Linq;
using Acr.UserDialogs;
using Foundation;
using UIKit;

namespace TopMovies.iOS
{

    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
       
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Calabash.Start();
            global::Xamarin.Forms.Forms.Init();
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            //UINavigationBar.Appearance.BackgroundColor = new UIColor(245 / 255f, 246 / 255f, 247 / 255f, 1.0f);
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
