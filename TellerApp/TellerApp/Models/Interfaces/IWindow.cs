using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellerApp.Models.Interfaces
{
	public interface IWindow
	{
		public Dictionary<string, IPage> GetPages { get; }

		public void RequestChange(string page);
	}
}
