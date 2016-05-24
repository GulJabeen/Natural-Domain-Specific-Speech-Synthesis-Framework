using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Media;
using Android.OS;
using Android.Views;
using Android.Widget;
using NDSSSF.DataRepository.Infrastructure.Entities;
using NDSSSF.Droid.Infrastructure;
using System;

namespace NDSSSF.Droid
{
    [Activity( Theme = "@android:style/Theme.Holo.Light")]
    public class STE3_popup: Activity
    {
        //int count = 1;

       
     

        protected  override void OnCreate(Bundle bundle)
        {

            // string path = "C:/Users/mof1/Documents/Visual Studio 2015/Projects/NDSSF/NDSSF/recordings/test.3gpp";
            System.Diagnostics.Debug.Write("------------------------->OnCreate()");
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.popuplayoutform);
          EditText edit = FindViewById<EditText>(Resource.Id.edittext);

                   Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner2);
                   spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
                   var adapter = ArrayAdapter.CreateFromResource(
                      this, Resource.Array.type_array, Android.Resource.Layout.SimpleSpinnerItem);

                   adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            Spinner spinner2 = FindViewById<Spinner>(Resource.Id.spinner4);
            spinner2.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected2);
            var adapter2 = ArrayAdapter.CreateFromResource(
               this, Resource.Array.type_array2, Android.Resource.Layout.SimpleSpinnerItem);

            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner2.Adapter = adapter2;
            ImageButton back = FindViewById<ImageButton>(Resource.Id.imageButton_back);
            //   back.Click += delegate { StartActivity(typeof(STE3)); };
            back.Click += delegate { StartActivity(typeof(STE3)); };

         
            //  SetContentView(Resource.Layout.STE2);


        }

        protected override void OnStart()
        {
            //   DBRepository dbRepo = new DBRepository();
            //   dbRepo.createDB();
            //   dbRepo.createTable();
            //  dbRepo.insertWord();



            System.Diagnostics.Debug.Write("------------------------->OnRestart()");
            base.OnStart();
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The  word is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Short).Show();
        }
        private void spinner_ItemSelected2(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The  word is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Short).Show();
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

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return true;
        }

       
    }
}
