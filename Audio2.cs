using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Media;
//using Android.OS;
using Android.Views;
using Android.Widget;
using NDSSSF.DataRepository.Infrastructure.Entities;
using NDSSSF.Droid.Infrastructure;
using Android.OS;
using Java.IO;
using System;
using Android.Graphics;


namespace NDSSSF.Droid
{
    [Activity(Theme = "@android:style/Theme.Holo.Light")]

    public class Audio2 : ActivityBase
    {
        //int count = 1;


        public MediaRecorder _recorder=new MediaRecorder();
        public MediaPlayer _player;
        public ImageButton _start;
        public ImageButton _stop;
        File dir = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads), "//audioFile.mp3");
        //     public string path = "C:/Users/mof1/Source/Repos/Natural Domain Specific Speech Synthesis Framework/NDSSSF.Mobile/NDSSSF.Droid/Recordings/";
        // public string Path="";

        protected override void OnCreate(Bundle bundle)
        {

            // string path = "C:/Users/mof1/Documents/Visual Studio 2015/Projects/NDSSF/NDSSF/recordings/test.3gpp";
            System.Diagnostics.Debug.Write("------------------------->OnCreate()");
            base.OnCreate(bundle);
            
            // Set our view from the "main" layout resource
          
                                 SetContentView(Resource.Layout.AD2);
                                 EditText word_text1 = FindViewById<EditText>(Resource.Id.user_ID);
            word_text1.Click += delegate { Toast.MakeText(this,"Only Enter Alphabets", ToastLength.Short).Show(); };
            EditText word_text2 = FindViewById<EditText>(Resource.Id.password);
            word_text2.Click += delegate { Toast.MakeText(this, "Only Enter Alphabets", ToastLength.Short).Show(); };

            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
               this, Resource.Array.type_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
        

        //   spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, example);


        ImageButton Save = FindViewById<ImageButton>(Resource.Id.imageButton3);
         //   TextView setcolor = FindViewById<TextView>(Resource.Id.wordtype);

                                       Save.Click += async delegate
                                       {
                                           Word word = new Word();
                                           switch (spinner.SelectedItemPosition)
                                           {
                                               case 0:
                                                   word.Type = Types.Noun;
                                                  // setcolor.SetTextColor(color:#FF0000);
                                                   
                                                   break;
                                               case 1:
                                                   word.Type = Types.Verb;
                                                   break;
                                               case 2:
                                                   word.Type = Types.Adjective;
                                                   break;
                                               case 3:
                                                   word.Type = Types.Pronoun;
                                                   break;
                                               case 4:
                                                   word.Type = Types.Preposition;
                                                   break;
                                               case 5:
                                                   word.Type = Types.Adverb;
                                                   break;
                                             default:

                                                   break;
                                           }
                                           

                                           //Adding here
                                          
                                           word.Text = word_text1.Text;
                                           //    word.Type = Types.Noun;
                                           word.Tone = word_text2.Text;
                                           word.Audio = dir.AbsoluteFile.ToString();

                                           await DataRepository.Words.Add(word);
                                           Toast.MakeText(this, word.Text.ToString() + " Saved!", ToastLength.Short).Show();
                                             StartActivity(typeof(Audio1));
                                         //  StartActivity(typeof(STE5_Layout));
                                           // nitems.Add((await DataRepository.Words.GetAll()).FirstOrDefault()?.Text);


                                           // w.Type = example;

                                       };




                    String path = dir.Path;
           _start = FindViewById<ImageButton>(Resource.Id.imageButton1);
            _stop = FindViewById<ImageButton>(Resource.Id.imageButton2);
            _start.Click += delegate { //audio recording

                                         
    

                                          _stop.Enabled = !_stop.Enabled;
                                              _start.Enabled = !_start.Enabled;



                                           _recorder.SetAudioSource (AudioSource.Mic);
                          _recorder.SetOutputFormat (OutputFormat.ThreeGpp);
                          _recorder.SetAudioEncoder (AudioEncoder.AmrNb);
                                                _recorder.SetAudioChannels(1);
                                               // _recorder.setAudioSamplingRate(8000);
                                             
                                                _recorder.SetOutputFile(dir.Path);
                                                _recorder.Prepare ();
                                 _recorder.Start ();
                          } ;
                  
                                             _stop.Click += delegate {
                                                 _stop.Enabled = !_stop.Enabled;

                                                  _recorder.Stop();
                                               _recorder.Reset();

                                              _player.SetDataSource(dir.Path);
                                                
                                             _player.Prepare();
                                              _player.Start();
                                              };




            
                
            }
      
private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
{
    Spinner spinner = (Spinner)sender;

    string toast = string.Format("The  word is {0}", spinner.GetItemAtPosition(e.Position));
    Toast.MakeText(this, toast, ToastLength.Short).Show();
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


            _recorder = new MediaRecorder();
            _player = new MediaPlayer();

            _player.Completion += (sender, e) => {
                _player.Reset();
                _start.Enabled = !_start.Enabled;
            };

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

            _player.Release();
            _recorder.Release();
            _player.Dispose();
            _recorder.Dispose();
            _player = null;
            _recorder = null;
        }


      
    }

}
