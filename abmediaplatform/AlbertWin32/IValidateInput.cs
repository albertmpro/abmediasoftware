using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Win32
{
    public interface IValidateInput
    {
        event InputErrorEventHandler InputValidationError;
        bool CommitInput();
    }
}
