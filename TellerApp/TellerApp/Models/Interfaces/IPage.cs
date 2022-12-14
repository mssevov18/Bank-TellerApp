using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellerApp.Models.Interfaces
{
	public interface IPage : IClearable
	{
		public string Name { get; set; }
		public IWindow Owner { get; set; }

		public double DesiredWidth { get; }
		public double DesiredHeight { get; }
	}
}
