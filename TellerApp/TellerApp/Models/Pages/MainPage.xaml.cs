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
		#region Constructors
		public MainPage() => InitializeComponent();
		public MainPage(string name, IWindow owner)
		{
			_name = name;
			_owner = owner;

			InitializeComponent();
		}
		#endregion

		#region IPage definitions
		string _name = String.Empty;
		string IPage.Name { get => _name; set => _name = value; }

		IWindow? _owner;
		IWindow IPage.Owner
		{
			get
			{
				if (_owner == null)
					throw _nullOwner;
				return _owner;
			}
			set => _owner = value;
		}
		Exception _nullOwner = new NullReferenceException("_owner in LogInPage is null");

		public double DesiredWidth => 800;
		public double DesiredHeight => 500;

		#region IClearable
		public void Clear()
		{

		}
		#endregion
		#endregion

	}
}
