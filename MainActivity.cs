using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;
using NDSSSF.DataRepository.Infrastructure.Entities;
using NDSSSF.Droid.Infrastructure;

namespace NDSSSF.Droid
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : ActivityBase
    {
        //int count = 1;

       
        //public string Path="";

        protected override void OnCreate(Bundle bundle)
        {

            // string path = "C:/Users/mof1/Documents/Visual Studio 2015/Projects/NDSSF/NDSSF/recordings/test.3gpp";
            System.Diagnostics.Debug.Write("------------------------->OnCreate()");
            base.OnCreate(bundle);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            ImageButton button = FindViewById<ImageButton>(Resource.Id.button1);// Audio Dictionary Button
            ImageButton button2 = FindViewById<ImageButton>(Resource.Id.button2);//stebutton
            ImageButton button3 = FindViewById<ImageButton>(Resource.Id.button3);//quit
            button.Click += delegate
                         {

                             StartActivity(typeof(Audio1));
                         };


             button2.Click += delegate
                                   {
                                          StartActivity(typeof(STE1));
                                                                                          };




                    button3.Click += delegate {

                        //    System.Environment.Exit(0);
                        StartActivity(typeof(STE5_Layout));

                    };

                                                                                     

           // button.SetOnClickListener(this);
           

            }
    
        protected override void OnStart()
        {
           


            System.Diagnostics.Debug.Write("------------------------->OnRestart()");
            base.OnStart();
        }
        protected override void OnRestart()
        {
            System.Diagnostics.Debug.Write("------------------------->OnRestart()");
            base.OnRestart();
        }
        protected override void OnResume()
        {
            System.Diagnostics.Debug.Write("------------------------->OnResume()");
            base.OnResume();
        }
        protected override void OnStop()
        {
            System.Diagnostics.Debug.Write("------------------------->OnStop()");
            base.OnStop();
        }
        protected override void OnPause()
        {
            System.Diagnostics.Debug.Write("------------------------->OnPause()");
            base.OnPause();
        }

      
       
    }
}
