using ClassLibrary.Models.Data;
using Microsoft.EntityFrameworkCore;
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
	/// Interaction logic for LogInPage.xaml
	/// </summary>
	public partial class LogInPage : Page, IPage
	{
		#region Constructors
		public LogInPage() => InitializeComponent();
		public LogInPage(string name, IWindow owner)
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

		public double DesiredWidth => 250;
		public double DesiredHeight => 300;

		#region IClearable
		public void Clear()
		{
			UsernameTextBox.Clear();
			PasswordTextBox.Clear();
		}
		#endregion

		#endregion

		#region Buttons
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_owner == null)
				throw _nullOwner;

			////THIS IS HERE TO TEST DB CONNECTION
			using (BankDBContext dBContext = new BankDBContext())
			{
				if (UsernameTextBox.Text     != String.Empty &&
					PasswordTextBox.Password != String.Empty &&
					dBContext.BankWorkers
						.Where(bw => bw != null && bw.Username == UsernameTextBox.Text)
						.FirstOrDefault()
						.Password == PasswordTextBox.Password)
				{
					e.Handled = true;
					_owner.RequestChange("main");
				}
			}
		}
		#endregion
	}
}

