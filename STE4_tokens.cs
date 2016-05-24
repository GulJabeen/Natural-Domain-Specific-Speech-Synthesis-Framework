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
    [Activity( Theme = "@android:style/Theme.Holo.Light")]
    public class STE4_tokens: ActivityBase
    {
        //int count = 1;

      

        protected  override void OnCreate(Bundle bundle)
        {

            // string path = "C:/Users/mof1/Documents/Visual Studio 2015/Projects/NDSSF/NDSSF/recordings/test.3gpp";
            System.Diagnostics.Debug.Write("------------------------->OnCreate()");
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.STE4_tokens);
            //  Context context= new Context(BaseContext);
            int borderWidth = 10;
            int borderHeight = 5;
            int thickness = 2;
            // LinearLayout l1 = FindViewById<LinearLayout>(Resource.Id)
            ImageView selectionBorder = BorderDrawer.generateBorderImageView(this, borderWidth, borderHeight, thickness, Color.White);
            //  string next;
            // Get our button from the layout resource,
            // and attach an event to it
            string[] array = { "sun", "moon", "try", "sun", "moon", "try" };
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
                tv.SetTypeface(null, TypefaceStyle.Bold);
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

            }
            //tv.SetBackgroundColor("red");

            linear.AddView(tableRow, lp);
            Dp.AddView(linear, li);
            ImageButton next_ste5 = FindViewById<ImageButton>(Resource.Id.imageButton_next);


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

       

       
    }
}
