using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidServiceReader.Activities;

namespace AndroidServiceReader
{
    [Activity(MainLauncher = true, Label = "@string/app_name", Theme = "@android:style/Theme.NoTitleBar")]
    public class ServiceReader : TabActivity
    {
        TabHost.TabSpec _spec;   // Reusable TabSpec for each tab

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            AddNewTab("Jord", "Jord", Resource.Drawable.ic_tab_dirt, new Intent(this, typeof(LandslideActivity)));
            AddNewTab("Is", "Is", Resource.Drawable.ic_tab_is, new Intent(this, typeof(IceActivity)));
            AddNewTab("Snø", "Snø", Resource.Drawable.ic_tab_sno, new Intent(this, typeof(AvalancheActivity)));
            AddNewTab("Vann", "Vann", Resource.Drawable.ic_tab_vann, new Intent(this, typeof(FloodActivity)));
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