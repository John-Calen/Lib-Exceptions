using System.Collections.ObjectModel;

namespace JC.Lib.Exceptions
{
    public partial class CausedException
    {
        public abstract class ABuilder<T_Builder, T_Exception>: ICausedExceptionData
            where T_Builder: ABuilder<T_Builder, T_Exception>
            where T_Exception: CausedException
        {
            public string? Message { get; private set; }
            private IDictionary<string, object?> BuildingCauseValues { get; set; } = new Dictionary<string, object?>();
            public IReadOnlyDictionary<string, object?> CauseValues => new ReadOnlyDictionary<string, object?>(BuildingCauseValues);
            public Exception? InnerException { get; private set; }
            
            
      
            
            
            
            public T_Builder SetMessage(string value)
            {
                Message = value;
                return (T_Builder) this;
            }

            public T_Builder SetInnerException(Exception? value)
            {
                InnerException = value;
                return (T_Builder) this;
            }

            public T_Builder AddCauseValue(string key, object? value)
            {
                BuildingCauseValues.Add(key, value);
                return (T_Builder) this;
            }

            public abstract T_Exception Build();
        }
    }
}
