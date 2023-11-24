namespace JC.Lib.Exceptions
{
    public partial class CausedException
    {
        public interface ICausedExceptionData
        {
            string? Message { get; }
            IReadOnlyDictionary<string, object?> CauseValues { get; }
            Exception? InnerException { get; }
        }
    }
}
