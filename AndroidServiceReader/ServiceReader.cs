using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidServiceReader.Activities;
using System;

namespace AndroidServiceReader
{
    [Activity(MainLauncher = true, Label = "@string/app_name", Theme = "@android:style/Theme.NoTitleBar")]
    public class ServiceReader : TabActivity
    {
        TabHost.TabSpec _spec;   // Reusable TabSpec for each tab

		public static DateTime DateDisplay {get; set;}
		private TextView dateDisplay;
		private Button pickDate;
		private DateTime date;
		const int DATE_DIALOG_ID = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

			Spinner spinner = FindViewById<Spinner> (Resource.Id.spinner);
			
			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource (
				this, Resource.Array.region_array, Android.Resource.Layout.SimpleSpinnerItem);
			
			adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;



			// Capture our View elements
			dateDisplay = FindViewById<TextView> (Resource.Id.dateDisplay);
			pickDate = FindViewById<Button> (Resource.Id.pickDate);
			
			// Add a click listener to the button
			pickDate.Click += (o, e) => ShowDialog (DATE_DIALOG_ID);
			
			// Get the current datetime
			date = DateTime.Today;
			
			// Display the current date
			UpdateDisplay ();


			// Adds tabs
            AddNewTab("Jord", "Jord", Resource.Drawable.ic_tab_dirt, new Intent(this, typeof(LandslideActivity)));
            AddNewTab("Is", "Is", Resource.Drawable.ic_tab_is, new Intent(this, typeof(IceActivity)));
            AddNewTab("Snø", "Snø", Resource.Drawable.ic_tab_sno, new Intent(this, typeof(AvalancheActivity)));
            AddNewTab("Vann", "Vann", Resource.Drawable.ic_tab_vann, new Intent(this, typeof(FloodActivity)));
        }

		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			
			string toast = string.Format ("The region is {0}", spinner.GetItemAtPosition (e.Position));
			Toast.MakeText (this, toast, ToastLength.Long).Show ();
		}



		// Updates the time we display in the TextView
		private void UpdateDisplay ()
		{
			DateDisplay = date;
			dateDisplay.Text = date.ToString ("d");
		}

		private void OnDateSet  (object sender, DatePickerDialog.DateSetEventArgs e)
		{
			this.date = e.Date;
			UpdateDisplay ();
		}

		protected override Dialog OnCreateDialog (int id)
		{
			if (id == DATE_DIALOG_ID)
			{
				return new DatePickerDialog (this, OnDateSet, date.Year, date.Month - 1, date.Day);
			}

			return null;
		}

        private void AddNewTab(string tabSpecName, string tabSpecIndicator, int drawableResource, Intent intent)
        {
            //Create an Intent to Launc an Acitvity for the tab (to be reused)
            intent.AddFlags(ActivityFlags.NewTask);

            //Initialize a TabSpec for each tab and add it to the TabHost
            _spec = TabHost.NewTabSpec(tabSpecName);
            _spec.SetIndicator(tabSpecIndicator, Resources.GetDrawable(drawableResource));
            _spec.SetContent(intent);
			TabHost.AddTab(_spec);
        }
    }
}