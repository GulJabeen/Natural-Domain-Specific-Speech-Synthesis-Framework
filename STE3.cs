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
using Java.IO;

namespace NDSSSF.Droid
{
    [Activity( Theme = "@android:style/Theme.Holo.Light")]
    public class STE3: ActivityBase
    {
        //int count = 1;

       
      
        public MediaRecorder _recorder;
        public MediaPlayer _player;
        public ImageButton _start;
        public ImageButton _stop;
        File dir = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads), "//audioFile1.mp3");
        //public string Path="";

        protected  override void OnCreate(Bundle bundle)
        {

            // string path = "C:/Users/mof1/Documents/Visual Studio 2015/Projects/NDSSF/NDSSF/recordings/test.3gpp";
            System.Diagnostics.Debug.Write("------------------------->OnCreate()");
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.STE2);
            EditText word_text2 = FindViewById<EditText>(Resource.Id.sentence_ID);
            word_text2.Click += delegate { Toast.MakeText(this, "Only Enter Alphabets", ToastLength.Short).Show(); };
            ImageButton Save = FindViewById<ImageButton>(Resource.Id.imageButtonsave);

            Save.Click += async delegate
            {
                Sentence s = new Sentence();
                s.Text = word_text2.Text;
                s.Audio = dir.AbsoluteFile.ToString();

                await DataRepository.Sentences.Add(s);
               Toast.MakeText(this, s.Text.ToString() + " Saved!", ToastLength.Short).Show();
               StartActivity(typeof(STE1));



            };

            String path = dir.Path;
            _start = FindViewById<ImageButton>(Resource.Id.imageButton1);
            _stop = FindViewById<ImageButton>(Resource.Id.imageButton2);
            _start.Click += delegate { //audio recording




                _stop.Enabled = !_stop.Enabled;
                _start.Enabled = !_start.Enabled;



                _recorder.SetAudioSource(AudioSource.Mic);
                _recorder.SetOutputFormat(OutputFormat.ThreeGpp);
                _recorder.SetAudioEncoder(AudioEncoder.AmrNb);
                _recorder.SetAudioChannels(1);
                // _recorder.setAudioSamplingRate(8000);

                _recorder.SetOutputFile(dir.Path);
                _recorder.Prepare();
                _recorder.Start();
            };

            _stop.Click += delegate {
                _stop.Enabled = !_stop.Enabled;

                _recorder.Stop();
                _recorder.Reset();

                _player.SetDataSource(dir.Path);

                _player.Prepare();
                _player.Start();
            };


















            ImageButton next = FindViewById<ImageButton>(Resource.Id.imageButton5);
            next.Click += simpleDailogueClick;
           
            //  SetContentView(Resource.Layout.STE2);


        }
      void simpleDailogueClick(object sender, System.EventArgs e)
        {
            AlertDialog.Builder alertDailoge = new AlertDialog.Builder(this);
         //   AlertDialog alertDailoge = builder.Create()
            alertDailoge.SetTitle("Alert title");
           // alertDailoge.SetIcon(Resource.Drawable.alert);
            alertDailoge.SetMessage("this is sample message");
           
            alertDailoge.SetPositiveButton("Add", (s, ev) =>
            {
                StartActivity(typeof(STE3_popup));
                
            });
            alertDailoge.SetNegativeButton("Cancel", (s, ev) =>
            {
                //do something
            });

            alertDailoge.Create().Show();

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
