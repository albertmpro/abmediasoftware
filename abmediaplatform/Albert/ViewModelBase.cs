using System;
using System.Collections.Generic;
using System.Text;

namespace Albert
{
	/// <summary>
	/// Base class for working with ViewModels 
	/// </summary>
	public abstract class ViewModelBase: Notify 
	{


		/// <summary>
		/// Method to display a Message 
		/// </summary>
		public Action<string> Message;
	}
}
