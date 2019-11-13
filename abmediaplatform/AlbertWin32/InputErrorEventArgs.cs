using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Win32
{
    /// <summary>
    /// Input Valdation Error Evnet Handler 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void InputErrorEventHandler(object sender, InputErrorEventArgs e);

    /// <summary>
    /// Input Validation Error EventArgs
    /// </summary>
    public class InputErrorEventArgs :EventArgs
    {
        #region Constructors

        public InputErrorEventArgs(Exception e)
        {
            Exception = e;
        }

        #endregion

        #region Exception Property

        public Exception Exception
        {
            get
            {
                return exception;
            }
            private set
            {
                exception = value;
            }
        }

        private Exception exception;

        #endregion

        #region ThrowException Property

        public bool ThrowException
        {
            get
            {
                return _throwException;
            }
            set
            {
                _throwException = value;
            }
        }

        private bool _throwException;

        #endregion
    }
}
