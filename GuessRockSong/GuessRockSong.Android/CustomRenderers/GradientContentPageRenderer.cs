using System;
using GuessRockSong.Droid.Controls;
using GuessRockSong.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;

[assembly: ExportRenderer(typeof(GradientContentPage), typeof(GradientContentPageRenderer))]

namespace GuessRockSong.Droid.Controls
{
    public class GradientContentPageRenderer : PageRenderer
    {
        public GradientContentPageRenderer(Context context) : base(context)
        {
        }

        private Color StartColor { get; set; }
        private Color EndColor { get; set; }

        protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        {
            var gradient = new Android.Graphics.LinearGradient(0, 0, 0, Height,
                this.StartColor.ToAndroid(),
                this.EndColor.ToAndroid(),
                Android.Graphics.Shader.TileMode.Mirror);
            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            //MainActivity.ToolBar?.SetNavigationIcon(Resource.Drawable.arrow);

            base.OnElementChanged(e);

            //var context = (MainActivity)Xamarin.Forms.Forms.Context;
            //var toolbar = context.FindViewById<Android.Support.V7.Widget.Toolbar>(Droid.Resource.Id.toolbar);

            //toolbar.NavigationIcon = Android.Support.V4.Content.ContextCompat.GetDrawable(context, Resource.Drawable.arrow);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var stack = e.NewElement as GradientContentPage;
                this.StartColor = stack.StartColor;
                this.EndColor = stack.EndColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }
    }
}