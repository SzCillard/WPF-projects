using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Food_Order
{
	/// <summary>
	/// Interaction logic for FoodEditorWindow.xaml
	/// </summary>
	public partial class FoodEditorWindow : Window
	{
		public Food Food { get;}
		public FoodEditorWindow(Food food)
		{
			InitializeComponent();
			this.Food=food.GetDeepCopy();
			this.DataContext =this.Food;
			this.cbox_type.ItemsSource = Enum.GetValues(typeof(FoodType));
		}

	    void Button_Click(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}
	}
}
