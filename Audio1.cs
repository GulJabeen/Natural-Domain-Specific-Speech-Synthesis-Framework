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
    [Activity(Theme = "@android:style/Theme.Holo.Light")]
    public class Audio1 : ActivityBase
    {
        EditText inputsearch;

        private ListView nlistview;
      //  List<string> wordStrings;
        List<Word> wordList = new List<Word>();//sahi he? han abhi wahan jao jahan isay lstview me daal rhe ho
        // private ListView slistview;
       // ArrayAdapter<String> wordAdapter;
        public MediaRecorder _recorder;
        public MediaPlayer _player;
        public Button _start;
        public Button _stop;
        protected MyAdapter MyServiceItemsAdapter;
        public static readonly string Tag = typeof(MainActivity).ToString();
        //public string Path="";
        public int index = -1;
        protected async override void OnCreate(Bundle bundle)
        {

            // string path = "C:/Users/mof1/Documents/Visual Studio 2015/Projects/NDSSF/NDSSF/recordings/test.3gpp";
            System.Diagnostics.Debug.Write("------------------------->OnCreate()");
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AudioDictionary1);
            Toast.MakeText(this,   "Database is updated", ToastLength.Short).Show();
            nlistview = FindViewById<ListView>(Resource.Id.listView1);
            wordList = (await DataRepository.Words.GetAll());
            // wordStrings = new List<string>();

            MyServiceItemsAdapter = new MyAdapter(this, wordList);
            nlistview.Adapter = MyServiceItemsAdapter;
            nlistview.FastScrollEnabled = true;
            inputsearch = FindViewById<EditText>(Resource.Id.inputSearch);
            inputsearch.TextChanged += nsearch_textchanged;
             

            ImageButton buttonimage3 = FindViewById<ImageButton>(Resource.Id.myButton3);
            ImageButton btn = FindViewById<ImageButton>(Resource.Id.deletebutton1);
           
          


            buttonimage3.Click += delegate
            {
                StartActivity(typeof(Audio2));
            };
        }


     
           void nsearch_textchanged(object sender, Android.Text.TextChangedEventArgs e) {
            List<Word> nlist = (from n in wordList
                                where n.Text.StartsWith(inputsearch.Text)
                                select n).ToList<Word>();

            MyServiceItemsAdapter = new MyAdapter(this, nlist);
            nlistview.Adapter = MyServiceItemsAdapter;



            


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

       public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            switch (item.ItemId)
            {
                case Resource.Id.actionNew:
                    {
                        StartActivity(typeof(MainActivity));

                        // place holder for creating new poi
                        return true;

                    }


               

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
     
    }
}
