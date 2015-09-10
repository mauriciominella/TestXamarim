using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Views;
using TestXamarim.Controls;
using TestXamarim.Droid.Listeners;
using TestXamarim.Droid.Renderers;

[assembly: ExportRenderer (typeof(SwipeListView), typeof(CustomListViewRenderer))]

namespace TestXamarim.Droid.Renderers
{
	public class CustomListViewRenderer : ListViewRenderer
	{
		private readonly CustomGestureListener _listener;
		private readonly GestureDetector _detector;

		public CustomListViewRenderer ()
		{
			_listener = new CustomGestureListener ();
			_detector = new GestureDetector (_listener);

		}


		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);


		}


		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			
			base.OnElementChanged (e);

			if (e.NewElement == null) {
				this.GenericMotion -= HandleGenericMotion;
				this.Touch -= HandleTouch;
			}

			if (e.OldElement == null) {
				this.GenericMotion += HandleGenericMotion;
				this.Touch += HandleTouch;
			}


			//this.SetBackgroundColor (Android.Graphics.Color.AliceBlue);
		}


		void HandleTouch (object sender, Android.Views.View.TouchEventArgs e)
		{
			_detector.OnTouchEvent (e.Event);
		}

		void HandleGenericMotion (object sender, Android.Views.View.GenericMotionEventArgs e)
		{
			_detector.OnTouchEvent (e.Event);
		}
	}
}

