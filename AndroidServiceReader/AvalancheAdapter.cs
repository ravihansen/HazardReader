using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using HazardReaderCore.Entities.HazardRegistration;
using UrlImageViewHelper;
using System.Drawing;

namespace AndroidServiceReader
{
    public class AvalancheAdapter : BaseAdapter<Registration>
    {
        private readonly List<Registration> _items;
        private readonly Activity _context;

        public AvalancheAdapter(Activity context, List<Registration> items)
            : base()
        {
            _context = context;
            _items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        /// <summary>
        /// Implements row view re-use to save memory when displaying many rows
        /// </summary>
        /// <param name="position"></param>
        /// <param name="convertView"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];
            View view = convertView; // re-use an existing view, if one is supplied
            if (view == null) // otherwise create a new one
            {
                view = _context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
            }

            // set view properties to reflect data to the given row
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.RegistrationName;
			view.FindViewById<ImageView>(Android.Resource.Id.Icon).SetImageResource(Resource.Drawable.Icon);
            
            // return the view, populated with data for display
            return view;
        }



        public override int Count
        {
            get { return _items.Count; }
        }

        public override Registration this[int position]
        {
            get { return _items[position]; }
        }


    }
}