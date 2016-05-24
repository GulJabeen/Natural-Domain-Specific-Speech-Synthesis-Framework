using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Media;
using Android.OS;
using Android.Content;
using Android.Views;
using Android.Widget;
using NDSSSF.DataRepository.Infrastructure.Entities;
using NDSSSF.Droid.Infrastructure;
using System;
using NDSSSF.SQLiteDataRepository;
//using SQLitePCL;


namespace NDSSSF.Droid
{

    public class MyAdapter3 : NDSSSFBaseAdapter<Word>
    {


        public List<Word> nItems;
        private Activity nContext = null;
        Word worditem;
        //   Word w = new Word();
        public MyAdapter3(Activity context, List<Word> items) : base()
        {
            this.nItems = items;
            this.nContext = context;

        }
        public override int Count
        {
            get { return nItems.Count; }
        }

        public override Word this[int position]
        {
            get
            {
                throw new NotImplementedException();
            }
        }



        public override long GetItemId(int position)
        {
            return position;
        }
        /*    public override string this[int position]
            {
                get
                {
                    return nItems[position];
                }

            }*/
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            ServiceViewHolder holder = null;

            var view = convertView;

            if (view == null)

            {
                view = LayoutInflater.From(nContext).Inflate(Resource.Layout.CustomRow3, null, false);
                holder = new ServiceViewHolder();
                holder.Text = view.FindViewById<TextView>(Resource.Id.wordtext);
                holder.Type = view.FindViewById<TextView>(Resource.Id.wordtype);
                holder.Tone = view.FindViewById<TextView>(Resource.Id.wordtone1);
               holder.EditButton = view.FindViewById<ImageButton>(Resource.Id.Editbutton1);
                holder.DeleteButton = view.FindViewById<ImageButton>(Resource.Id.deletebutton1);
               

                holder.PlayButton = view.FindViewById<ImageButton>(Resource.Id.playbutton1);
                view.Tag = holder;
            }
            else
            {
                holder = view.Tag as ServiceViewHolder;
            }
            worditem = nItems[position];
            var item = nItems[position];

            holder.Text.Text = "   " + worditem.Text;
            holder.Type.Text = "   " + "(" + (worditem.Type).ToString() + ".)";
            holder.Tone.Text = "    " + "[" + worditem.Tone + " Tone"+"]";
            holder.DeleteButton.Click += (object sender, EventArgs e) =>
                {

                     DataRepository.Words.Delete(item);
                    //  await DataRepository.Words.Delete(item);
                    nItems.RemoveAt(position);
                    NotifyDataSetChanged();
                    Toast.MakeText(this.nContext, item.Text.ToString()+"     "+"Deleted", ToastLength.Short).Show();
                };
          

            //   holder.DeleteButton.Click += remove_word;
            holder.EditButton.Click += (object sender, EventArgs e) =>
            {
                holder.Text.SetText("   " + item.Text, TextView.BufferType.Normal);
                holder.Type.SetText(("   " + "(" + item.Type).ToString() + ".)", TextView.BufferType.Normal);
                holder.Tone.SetText("    " + "[" + item.Tone + " Tone" + "]", TextView.BufferType.Normal);
                holder.EditButton.Focusable = false;
                holder.EditButton.FocusableInTouchMode = false;
                holder.EditButton.Clickable = true;
                var word = new Intent(this.nContext, typeof(Audio3));
                string alpha = item.Id.ToString();
                word.PutExtra("Id", alpha);
                
               // a.DataRepository.Words.Update(worditem);
              nContext.StartActivity(word);
                //Todo - implement edit Service
            };
            holder.PlayButton.Click += (object sender, EventArgs e) =>
            {
                string a = item.Audio;//getting  path from database
                MediaPlayer _player = new MediaPlayer();
                _player.SetDataSource(a);//paassng a path to play

                _player.Prepare();
                _player.Start();
                //Todo - implement edit Service
            };
            // }


            return view;

        }

       

        /*    void remove_word(object sender, EventArgs e)
             {

                 var t = (Bu)sender;
                 nItems.RemoveAt(t);
                 NotifyDataSetChanged();





             }*/




        public class ServiceViewHolder : Java.Lang.Object
        {
            public TextView Text { get; set; }
            public TextView Type { get; set; }
            public TextView Tone { get; set; }
            public ImageButton EditButton { get; set; }
            public ImageButton DeleteButton { get; set; }
            public ImageButton PlayButton { get; set; }
        }

    }


}

