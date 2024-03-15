using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniEditor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ObservableCollection<Person> people;
		public MainWindow()
		{
			InitializeComponent();
			people = new ObservableCollection<Person>() 
			{ 
				new Person("Jani",11, "nem"),
				new Person("Jana",33,"igen")
			};
			lbox.ItemsSource = people;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if(lbox.SelectedItem!=null && lbox.SelectedItem is Person p)
			{
				if(p.HaveGlasses=="igen")
				{
					p.HaveGlasses = "nem";
				}
				else 
				{
					p.HaveGlasses = "igen";
				}
			}
            
        }

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			people.Add(new Person() { Name="", Age=0, HaveGlasses=""});
		}
	}
	public class Person : INotifyPropertyChanged
	{
		private string name;
		private int age;
		private string haveGlasses;
        public Person()
        {
			
        }
        public Person(string name, int age, string haveGlasses)
		{
			this.name = name;
			this.age = age;
			this.haveGlasses = haveGlasses;
		}

		public string Name
		{
			get => name;
			set { name = value; OnPropertyChanged(); }
		}
		public int Age { get => age; set { age = value; OnPropertyChanged(); } }

		public string HaveGlasses { get => haveGlasses; set { haveGlasses = value; OnPropertyChanged(); } }

		public event PropertyChangedEventHandler? PropertyChanged;
		
		void OnPropertyChanged([CallerMemberName] string propertyName="")
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if(handler!=null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}