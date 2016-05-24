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
    public class Audio3 : ActivityBase
    {
        //int count = 1;
        // Word w = new Word();
        List<Word> wordList = new List<Word>();
        public MediaRecorder _recorder;
        public MediaPlayer _player;
        public Button _start;
        public Button _stop;
        //public string Path="";
        public string id;
        protected async override void OnCreate(Bundle bundle)
        {

            // string path = "C:/Users/mof1/Documents/Visual Studio 2015/Projects/NDSSF/NDSSF/recordings/test.3gpp";
            System.Diagnostics.Debug.Write("------------------------->OnCreate()");
            base.OnCreate(bundle);

            id =
               Intent.GetStringExtra("Id") ?? "Data not available";
            int wordid = int.Parse(id);
            // MyAdapter my = new MyAdapter(this,null);
            wordList = (await DataRepository.Words.GetAll());

            string nlist = (from n in wordList
                            where n.Id == wordid
                            select n.Text).SingleOrDefault();
            string ntype = (from n in wordList
                            where n.Id == wordid
                            select (n.Type).ToString()).SingleOrDefault();
            string nlist2 = (from n in wordList
                            where n.Id == wordid
                            select n.Tone).SingleOrDefault();

          int index1 = (from n in wordList
                             where n.Id == wordid
                             select n.Id).SingleOrDefault();


            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.AD2);
                                 EditText word_text1 = FindViewById<EditText>(Resource.Id.user_ID);
            EditText word_text2 = FindViewById<EditText>(Resource.Id.password);
            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
               this, Resource.Array.type_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            var pos = spinner.SelectedItemPosition;
            string pos2 = pos.ToString();
          //not getting a type
                word_text1.Text = nlist;
                word_text2.Text = nlist2;
                pos2 = ntype;
     


        ImageButton Save = FindViewById<ImageButton>(Resource.Id.imageButton3);

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
                                           await DataRepository.Words.Delete(wordid);
                                           await DataRepository.Words.Add(word);
                                           Toast.MakeText(this, word.Text.ToString() + " Edited", ToastLength.Short).Show();
                                           StartActivity(typeof(Audio1));

                                           // nitems.Add((await DataRepository.Words.GetAll()).FirstOrDefault()?.Text);


                                           // w.Type = example;

                                       };

                    






                
                           /*      _start.Click += delegate { //audio recording
                                      _stop.Enabled = !_stop.Enabled;
                                      _start.Enabled = !_start.Enabled;
                                        //string path = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.RootDirectory.AbsolutePath), "myXMLfile.xml");
                                        // File path = new File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDownloads) + "");
                                        // string path = Environment.ExternalStorageDirectory
                                        //  File myDir = new File(root + "/folder");
                                        // File path = Environment.GetExternalStorageState.equals(Environment.MEDIA_MOUNTED);
                                        string path= "C:/Users/mof1/Source/Repos/Natural Domain Specific Speech Synthesis Framework/NDSSSF.Mobile/NDSSSF.Droid/Recordings";
                                        _recorder.SetAudioSource (AudioSource.Mic);
                  _recorder.SetOutputFormat (OutputFormat.ThreeGpp);
                  _recorder.SetAudioEncoder (AudioEncoder.AmrNb);
                                        _recorder.SetAudioChannels(1);
                                       // _recorder.setAudioSamplingRate(8000);
                                        // _recorder.SetOutputFile (System.Environment.getExternalStorageDirectory()+"pictures");//error
                                        _recorder.SetOutputFile(path);
                                        _recorder.Prepare ();
                         _recorder.Start ();
                  } ;

                                     _stop.Click += delegate {
                                          _stop.Enabled = !_stop.Enabled;

                                          _recorder.Stop();
                                          _recorder.Reset();

                                        _player.SetDataSource(path);
                                          _player.Prepare();
                                          _player.Start();
                                      };*/
                                      
                    
                //      };









                
            }
private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
{
    Spinner spinner = (Spinner)sender;

    string toast = string.Format("The  word is {0}", spinner.GetItemAtPosition(e.Position));
    Toast.MakeText(this, toast, ToastLength.Long).Show();
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
