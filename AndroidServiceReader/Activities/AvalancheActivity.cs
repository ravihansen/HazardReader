using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using HazardReaderCore;
using HazardReaderCore.Business;
using HazardReaderCore.Entities.HazardRegistration;

namespace AndroidServiceReader.Activities
{
    [Activity(Label = "Avalanche")]
    public class AvalancheActivity : ListActivity
    {
        private List<Registration> _items;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
					
            HazardRegistrationReaderBL bl = new HazardRegistrationReaderBL();


			var date = ServiceReader.DateDisplay;
			if(date == DateTime.MinValue)
			{
				date = DateTime.Now.AddDays(-1);
			}


            try
            {
                _items = bl.GetHazardRegistrations(HazardRegistration.Avalanche, date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            if (_items != null)
            {
                ListAdapter = new AvalancheAdapter(this, _items);

            }
            else
            {
                // TODO: Add error text
            }

             
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var names = _items.Select(item => item.RegistrationName).ToList();

            var t = names[position];
            Toast.MakeText(this, t, ToastLength.Short).Show();
        }
    }
}