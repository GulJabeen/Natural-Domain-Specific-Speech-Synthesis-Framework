using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace NDSSSF.Droid
{
    class MyListViewAdapter: BaseAdapter<string>
    {
        private List<string> nItems;
        private Context nContext;
        public MyListViewAdapter(Context context,List<string> items)
        {
            nItems = items;
            nContext = context;

        }
        public override int Count
        {
            get { return nItems.Count; }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override string this[int position]
        {
            get
            {
                return nItems[position];
            }

        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if(row==null)

            {
                row = LayoutInflater.From(nContext).Inflate(Resource.Layout.AD2, null, false);


            }
            TextView txtWord = row.FindViewById<TextView>(Resource.Id.textView1);
            txtWord.Text = nItems[position];
            return row;
        }
    }
}