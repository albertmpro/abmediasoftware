﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Albert
{
	/// <summary>
	/// Base Class for working with models MVVM
	/// </summary>
    public abstract class Notify: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
		/// Accures when the Property is changed 
		/// </summary>
		/// <param name="Name"></param>
        protected void OnPropertyChanged(string Name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }

    }
}
