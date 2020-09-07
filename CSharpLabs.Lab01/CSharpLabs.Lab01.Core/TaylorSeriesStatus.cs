namespace CSharpLabs.Lab01.Core
{
    public enum TaylorSeriesStatus
    {
        None = 0,
        Success = 1,
        TooManyIterations = 2,
        NotInDomain = 4,
        NotSupported = 8
    }
}
