using Android.Content;
using Android.Views;
using CareConnection.Core.Controls;
using CareConnection.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(ExtendedEntryRenderer))]
namespace CareConnection.Droid.Renderer
{
    class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.rounded_entry);
                Control.SetPadding(15, 0, 0, 0);
                Control.Gravity = GravityFlags.CenterVertical;
            }
        }
    }
}