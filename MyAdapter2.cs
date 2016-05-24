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

    public class MyAdapter2 : NDSSSFBaseAdapter<Sentence> 
    {

      // STE1 s=new STE1();
        public List<Sentence> nItems;
        private Activity nContext = null;
       // Word worditem;
        Sentence sentenceitem;
        //   Word w = new Word();
        public MyAdapter2(Activity context, List<Sentence> items) : base()
        {
            this.nItems = items;
            this.nContext = context;

        }
        public override int Count
        {
            get { return nItems.Count; }
        }

        public override Sentence this[int position]
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
                view = LayoutInflater.From(nContext).Inflate(Resource.Layout.CustomRow2, null, false);
                holder = new ServiceViewHolder();
                holder.Text = view.FindViewById<TextView>(Resource.Id.stext);
               
               holder.EditButton = view.FindViewById<ImageButton>(Resource.Id.Editbutton2);
                holder.DeleteButton = view.FindViewById<ImageButton>(Resource.Id.deletebutton2);
               

                holder.PlayButton = view.FindViewById<ImageButton>(Resource.Id.playbutton2);
                view.Tag = holder;
            }
            else
            {
                holder = view.Tag as ServiceViewHolder;
            }
            sentenceitem = nItems[position];
            var item = nItems[position];

            holder.Text.Text = "   " + sentenceitem.Text;
          
            holder.DeleteButton.Click += async(object sender, EventArgs e) =>
                {
                    if (position >= 0)
                    {
                        //s.DataRepository.Sentences.Delete(item);
                        await DataRepository.Sentences.Delete(item);
                        nItems.RemoveAt(position);
                        NotifyDataSetChanged();
                    }

                };
          

            //   holder.DeleteButton.Click += remove_word;
            holder.EditButton.Click += (object sender, EventArgs e) =>
            {
                holder.Text.SetText(item.Text, TextView.BufferType.Normal);
               
                holder.EditButton.Focusable = false;
                holder.EditButton.FocusableInTouchMode = false;
                holder.EditButton.Clickable = true;
                var sentence = new Intent(this.nContext, typeof(STE3_edit));
                string alpha = item.Id.ToString();

                sentence.PutExtra("Id", alpha);
                nContext.StartActivity(sentence);
                //   s.DataRepository.Words.Update(sentence);
                // a.StartActivity(word);
                // StartActivity(typeof(Audio1));
                //Todo - implement edit Service
            };
            holder.PlayButton.Click += (object sender, EventArgs e) =>
            {
                string a = item.Audio;//getting  path from database
                MediaPlayer _player = new MediaPlayer();
                _player.SetDataSource(a);//paassng a path to play

                _player.Prepare();
                _player.Start();
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
           
            public ImageButton EditButton { get; set; }
            public ImageButton DeleteButton { get; set; }
            public ImageButton PlayButton { get; set; }
        }

    }


}

