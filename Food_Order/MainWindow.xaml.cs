using Food_Order;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Food_Order
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		MainWindowViewModel vm;

		public MainWindow()
		{
			InitializeComponent();
			if (this.DataContext == null)
				this.DataContext = new MainWindowViewModel();
			this.vm = this.DataContext as MainWindowViewModel;
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			foreach (var item in Enum.GetValues(typeof(FoodType)))
			{
				this.cbox_foodTypes.Items.Add(item.ToString());
			}
			this.cbox_foodTypes.SelectedIndex = 0;
			InvalidateVisual();
		}

		private void lbox_foods_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			Food food = vm.SelectedFood;
			if (food != null)
			{
				FoodEditorWindow foodWindow = new FoodEditorWindow(food);
				if (foodWindow.ShowDialog() == true)
				{
					food.Update(foodWindow.Food);
					vm.UpdateDisplayedFoods();
				}
			}
		}

		private void Add_Button_Click(object sender, RoutedEventArgs e)
		{
			vm.AddSelectedToOrder();
		}

		private void Remove_Button_Click(object sender, RoutedEventArgs e)
		{
			vm.RemoveFromOrder();
		}

		private void RemoveAll_Button_Click(object sender, RoutedEventArgs e)
		{
			vm.RemoveAllFromOrder();
        }
    }
}
