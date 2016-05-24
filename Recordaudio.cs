using System;
using System.IO;
using Android.Media;

namespace NDSSSF.Droid
{
    class Recordaudio
    {
        protected MediaRecorder recorder = null;
        //static string filePath = "/sdcard/Music/testAudio.mp3";
       // static string filePath = "/data/data/Example_WorkingWithAudio.Example_WorkingWithAudio/files/testAudio.mp4";
        
        public void RecordAudio(String filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                if (recorder == null)
                {
                    recorder = new MediaRecorder(); // Initial state.
                }
                else {
                    recorder.Reset();
                    recorder.SetAudioSource(AudioSource.Mic);
                    recorder.SetOutputFormat(OutputFormat.ThreeGpp);
                    recorder.SetAudioEncoder(AudioEncoder.AmrNb);
                    // Initialized state.
                    recorder.SetOutputFile(filePath);
                    // DataSourceConfigured state.
                    recorder.Prepare(); // Prepared state
                    recorder.Start(); // Recording state.
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }

        }
        public void StopRecorder()
        {
            
                recorder.Stop();
               
        }

    }
}