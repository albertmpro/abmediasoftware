using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Albert
{
    public class VMList<T> : ObservableCollection<T>
    {
        public void ForEach(Action<T> _method)
        {
            foreach(var i in this)
            {
                _method.Invoke(i);
            }
        }
    }
}
