using System;
using Xamarin.Forms;
using TestXamarim.Business;

namespace TestXamarim.Views.Converters
{
	public class ActivityTypeToColorConverter : IValueConverter
	{
		#region IValueConverter implementation

		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Color color;

			//blue by default
			string colorHex = "#9DD898";

			if (value is Int32) {
				EnumActivityType activityType = (EnumActivityType)value;

				switch (activityType) {
					case EnumActivityType.Positive:
						//blue
						colorHex = "#9DD898";
						break;
					case EnumActivityType.Neutral:
						//gray
						colorHex = "#B7B7B7";
						break;
					case EnumActivityType.ToImprove:
						//read
						colorHex = "#E39292";
						break;
					default:
						colorHex = "#9DD898";
						break;
				}
			}

			color = Color.FromHex (colorHex);
			return color;
		}
		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException ();
		}

		#endregion
		
	}
}

