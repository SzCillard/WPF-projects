using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Food_Order
{
	public enum FoodType
	{
		Appetizer,
		MainCourse,
		Dessert,
		Drink,
	}

	public class Food
	{
		public FoodType Type { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }

		public Food()
		{
			Name = string.Empty;
		}

		public Food(string name, FoodType type, int price)
		{
			Name = name;
			Type = type;
			Price = price;
		}

		public Food GetDeepCopy()
		{
			return new Food(Name, Type, Price);
		}

		public void Update(Food food)
		{
			this.Name = food.Name;
			this.Type = food.Type;
			this.Price = food.Price;
		}
	}
}
