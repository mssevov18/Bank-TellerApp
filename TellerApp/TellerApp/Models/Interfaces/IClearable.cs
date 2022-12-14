using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TellerApp.Models.Interfaces
{
	public interface IClearable
	{
		/// <summary>
		/// Forces all inputs to empty values
		/// </summary>
		public void Clear();
	}
}
