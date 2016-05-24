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
    [Activity( Theme = "@android:style/Theme.Holo.Light")]
    public class tester : ActivityBase
    {
        //int count = 1;

      
        private List<string> sitems;
        private ListView slistview;
        List<Sentence> sList = new List<Sentence>();
         public int index = -1;
        public MediaRecorder _recorder;
        public MediaPlayer _player;
        public Button _start;
        public Button _stop;
        protected MyAdapter5 MyServiceItemsAdapter;
        //public string Path="";

        protected async override void OnCreate(Bundle bundle)
        {

            // string path = "C:/Users/mof1/Documents/Visual Studio 2015/Projects/NDSSF/NDSSF/recordings/test.3gpp";
            System.Diagnostics.Debug.Write("------------------------->OnCreate()");
            base.OnCreate(bundle);




            SetContentView(Resource.Layout.Tester);
            slistview = FindViewById<ListView>(Resource.Id.listView4);

            sList = (await DataRepository.Sentences.GetAll());
            // wordStrings = new List<string>();

            MyServiceItemsAdapter = new MyAdapter5(this, sList);
            slistview.Adapter = MyServiceItemsAdapter;
            slistview.FastScrollEnabled = true;
          

            ImageButton ste = FindViewById<ImageButton>(Resource.Id.myButton4);
            ste.Click += delegate
            {
              //  StartActivity(typeof(STE3));

                        

                    };

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
