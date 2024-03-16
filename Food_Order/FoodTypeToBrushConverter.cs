using Food_Order;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Food_Order
{
	public class FoodTypeToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			FoodType food = (FoodType)value;
			Brush brush = Brushes.White;
			switch (food)
			{
				case FoodType.Appetizer:
					brush = Brushes.LightSalmon;
					break;
				case FoodType.MainCourse:
					brush = Brushes.LightSteelBlue;
					break;
				case FoodType.Dessert:
					brush = Brushes.LightBlue;
					break;
				case FoodType.Drink:
					brush = Brushes.LightSeaGreen;
					break;
				default:
					brush = Brushes.White;
					break;
			}
			return brush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
