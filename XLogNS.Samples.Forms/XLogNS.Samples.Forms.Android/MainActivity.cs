using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLog.Formatters;
using XLog;
using XLog.NET.Targets;
using System.IO;
using XLog.Android.Targets;

namespace XLogNS.Samples.Forms.Droid
{
    [Activity(Label = "XLogNS.Samples.Forms", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            InitLogging();
            LoadApplication(new App());
        }

        private void InitLogging()
        {
            var formatter = new LineFormatter();
            var logConfig = new LogConfig(formatter);
            var target = new SyncFileTarget(Path.Combine(global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "Log.log"));
            var logcatTarget = new LogcatTarget("XLogNS.Sapmles.Forms.Android");

            logConfig.AddTarget(LogLevel.Trace, LogLevel.Fatal, logcatTarget);
            logConfig.AddTarget(LogLevel.Trace, LogLevel.Fatal, target);
            LogManager.Init(logConfig);
        }
    }
}

