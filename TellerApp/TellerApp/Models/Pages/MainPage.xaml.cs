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
using TellerApp.Models.Interfaces;

namespace TellerApp.Models.Pages
{
	/// <summary>
	/// Interaction logic for MainPage.xaml
	/// </summary>
	public partial class MainPage : Page, IPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
		public MainPage(string name, IWindow owner)
		{
			_name = name;
			_owner = owner;

			InitializeComponent();
		}

		string _name;
		string IPage.Name { get => _name; set => _name = value; }

		IWindow _owner;
		IWindow IPage.Owner { get => _owner; set => _owner = value; }
		
		private void Change_Click(object sender, RoutedEventArgs e)
		{
			////THIS IS HERE TO TEST DB CONNECTION
			_owner.RequestChange("login");
		}

		public void Clear()
		{

		}

		public double DesiredWidth => 800;
		public double DesiredHeight => 500;
	}
}
