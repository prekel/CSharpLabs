using System;

namespace CSharpLabs.Lab01.Core
{
    [Flags]
    public enum TaylorSeriesStatus
    {
        None = 0,
        Undefined = 1,
        Success = 2,
        TooManyIterations = 4,
        NotInDomain = 8
    }
}
