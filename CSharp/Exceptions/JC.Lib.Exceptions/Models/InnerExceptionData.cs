namespace JC.Lib.Exceptions.Models
{
    public record InnerExceptionData(string Message, string? StackTrace, IReadOnlyDictionary<string, object?>? CauseValues);
}
