using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
namespace Albert.Win32.Controls
{
	/// <summary>
	/// Basic Window for doing MVVM applicatoins 
	/// </summary>
	public class ViewShell : Window, IAddCommand
	{
		/// <summary>
		/// Add Command Quickly 
		/// </summary>
		/// <param name="_command">ICommand</param>
		/// <param name="_method">Event Lamba</param>
		public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
		{
			//Add Command 
			CommandBindings.Add(new CommandBinding(_command, _method));
		}

		
		
	}
}
