using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
using TellerApp.Models.Pages;

namespace TellerApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, IWindow
	{
		Dictionary<string, IPage> _pages = new Dictionary<string, IPage>();

		public MainWindow()
		{
			InitializeComponent();

			_pages.Add("main", new MainPage("main", this));
			_pages.Add("login", new LogInPage("login", this));

			ChangePage("login");
		}

		public Dictionary<string, IPage> GetPages => _pages;

		public void ChangePage(string pageName)
		{
			if (!_pages.ContainsKey(pageName))
				throw new ArgumentException($"{pageName} is not a valid page!");

			ContentFrame.Content = _pages[pageName];
			this.Width = _pages[pageName].DesiredWidth;
			this.Height = _pages[pageName].DesiredHeight;
		}

		void IWindow.RequestChange(string page)
		{
			ChangePage(page);
		}
	}
}
