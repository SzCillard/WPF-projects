using Food_Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Food_Order
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		public ObservableCollection<Food> AllFoods { get; set; }
		public ObservableCollection<Food> DisplayedFoods { get; set; }
		public ObservableCollection<Food> OrderedFoods { get; set; }
		public Food SelectedFood { get; set; }
		public Food SelectedFoodFromOrder { get; set; }

		int orderTotal;
		public int OrderTotal { get { return this.OrderedFoods.Sum(f => f.Price); } }

		bool filter;


		FoodType selectedFilter;

		public event PropertyChangedEventHandler? PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void AddSelectedToOrder()
		{
			if (SelectedFood != null)
			{
				OrderedFoods.Add(SelectedFood.GetDeepCopy());
				OnPropertyChanged(nameof(OrderTotal));
			}
		}

		public void RemoveFromOrder()
		{
			OrderedFoods.Remove(SelectedFoodFromOrder);
			OnPropertyChanged(nameof(OrderTotal));
			
		}

		public void RemoveAllFromOrder()
		{
			OrderedFoods.Clear();
			OnPropertyChanged(nameof(OrderTotal));
		}
		public FoodType SelectedFilter
		{
			get
			{
				return selectedFilter;
			}
			set
			{
				selectedFilter = value;
				UpdateDisplayedFoods();
			}
		}

		public bool Filter
		{
			get => filter;
			set
			{
				filter = value;
				UpdateDisplayedFoods();
			}
		}

		public void UpdateDisplayedFoods()
		{
			this.DisplayedFoods.Clear();

			Func<Food, bool> filtercondition = p => true;
			if (filter)
				filtercondition = p => p.Type.Equals(this.selectedFilter);

			foreach (var food in this.AllFoods.Where(filtercondition))
				this.DisplayedFoods.Add(food);
		}

		public MainWindowViewModel()
		{
			AllFoods = FillWithData();
			DisplayedFoods = new ObservableCollection<Food>();
			OrderedFoods = new ObservableCollection<Food>();
			Filter = false;
			orderTotal = 0;
		}

		ObservableCollection<Food> FillWithData()
		{
			ObservableCollection<Food> foods = new ObservableCollection<Food>
			{
				new Food("Tavaszi zöldségleves", FoodType.Appetizer, 990),
				new Food("Dreher", FoodType.Drink, 590),
				new Food("Bécsi szelet", FoodType.MainCourse, 2190),
				new Food("Limonádé", FoodType.Drink, 490),
				new Food("Milánói sertés borda", FoodType.MainCourse, 2890),
				new Food("Rákóczi túrós", FoodType.Dessert, 790),
				new Food("Gyömölcssaláta", FoodType.Appetizer, 1190),
				new Food("Palacsinta", FoodType.Dessert, 390)
			};

			return foods;
		}
	}
}
