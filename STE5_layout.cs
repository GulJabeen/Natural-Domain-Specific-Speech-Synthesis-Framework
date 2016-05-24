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
using Android.Graphics;

namespace NDSSSF.Droid
{
    [Activity(Theme = "@android:style/Theme.Holo.Light")]
    public class STE5_Layout : ActivityBase
    {
        EditText inputsearch;

        private ListView nlistview;
      //  List<string> wordStrings;
        List<Word> wordList = new List<Word>();//sahi he? han abhi wahan jao jahan isay lstview me daal rhe ho
        // private ListView slistview;
      
        protected MyAdapter3 MyServiceItemsAdapter;
        public static readonly string Tag = typeof(MainActivity).ToString();
        //public string Path="";
        public int index = -1;
        protected async override void OnCreate(Bundle bundle)
        {

            // string path = "C:/Users/mof1/Documents/Visual Studio 2015/Projects/NDSSF/NDSSF/recordings/test.3gpp";
            System.Diagnostics.Debug.Write("------------------------->OnCreate()");
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.STE5);
            string[] array = { "sun", "moon", "try","sun", "moon", "try" };
            int m = array.Length;

            LinearLayout Dp = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            LinearLayout.LayoutParams li = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
            TableLayout.LayoutParams lp = new TableLayout.LayoutParams(TableLayout.LayoutParams.MatchParent, TableLayout.LayoutParams.WrapContent);
                TableLayout linear = new TableLayout(this);

                //   TableRow row = FindViewById<TableRow>(Resource.Id.row1);
                TableRow.LayoutParams tableRowParams = new TableRow.LayoutParams();
                tableRowParams.SetMargins(1, 1, 1, 1);
                tableRowParams.Weight = 1;

            TableRow tableRow = new TableRow(this);
            tableRow.SetGravity(GravityFlags.Top);
            tableRow.SetBackgroundColor(Color.Black);
           
           

            for (int i = 0; i < m; i++)
            {

                TextView tv = new TextView(this);
                tv.SetBackgroundColor(Color.Gray);
                tv.SetTextColor(Color.Black);
                tv.SetTypeface(null,TypefaceStyle.Bold);
                tv.Gravity = GravityFlags.Center;


                tv.Id = i;
                //int id = tv.FindViewById<Button>(i);

                int n = tv.Id;

             //   tv.SetText(Resource.Id.textView1_tab);
                lp.SetMargins(1, 1, 1, 1);
                tv.Text = array[i];
               
                tv.SetWidth(50);
                tv.SetHeight(50);
                li.RightMargin = 5;
                li.LeftMargin = 5;
                li.TopMargin = 5;
                li.BottomMargin = 5;
                tableRow.AddView(tv, tableRowParams);
                tableRow.SetGravity(GravityFlags.Top);
                tv.SetBackgroundColor(Color.Beige);
                tv.SetSelectAllOnFocus(true);
                tv.RequestFocus();
              
               // tv.SetSelectAllOnFocus(FocusablesFlags.TouchMode);
               

            }
            //tv.SetBackgroundColor("red");
          
            linear.AddView(tableRow, lp);
            Dp.AddView(linear, li);
          //  Dp.SetGravity(GravityFlags.Top);
           // Dp.SetGravity.
          
           
            
            //  l1.AddView(tv);



            Toast.MakeText(this,   "Database is updated", ToastLength.Short).Show();
            nlistview = FindViewById<ListView>(Resource.Id.listViewR);
           
            
            wordList = (await DataRepository.Words.GetAll());
            // wordStrings = new List<string>();

            MyServiceItemsAdapter = new MyAdapter3(this, wordList);
            nlistview.Adapter = MyServiceItemsAdapter;
            nlistview.FastScrollEnabled = true;
            Button btn = FindViewById<Button>(Resource.Id.button1);
            btn.Click += delegate { StartActivity(typeof(STE4_tokens)); };

            Button btn2 = FindViewById<Button>(Resource.Id.button3);
            btn2.Click += delegate { StartActivity(typeof(STE5_custom)); };
            Button btn3 = FindViewById<Button>(Resource.Id.button4);
            btn3.Click += delegate { StartActivity(typeof(tester)); };

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
