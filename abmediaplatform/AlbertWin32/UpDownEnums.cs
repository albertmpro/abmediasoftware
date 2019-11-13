using System;
using System.Collections.Generic;
using System.Text;

namespace Albert.Win32
{
    public enum AutoSelectBehavior
    {
        Never,
        OnFocus
    }


    [Flags]
    public enum AllowedSpecialValues
    {
        None = 0,
        NaN = 1,
        PositiveInfinity = 2,
        NegativeInfinity = 4,
        AnyInfinity = PositiveInfinity | NegativeInfinity,
        Any = NaN | AnyInfinity
    }
}
