using JC.Lib.Base.Strings.Extensions;
using JC.Lib.Base.Strings.Models;
using JC.Lib.Exceptions.Converters;
using Newtonsoft.Json;
using System.Text;



namespace JC.Lib.Exceptions
{
    public partial class CausedException : Exception
    {
        public IReadOnlyDictionary<string, object?> CauseValues;






        protected CausedException(ICausedExceptionData data) 
            : base(data.Message, data.InnerException) 
        {
            CauseValues = data.CauseValues;
        }





        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());

            if (InnerException != null)
            {
                var exceptionString = InnerException.ToString();
                exceptionString = exceptionString.TabAllText(3, TabType.SPACE);
                builder.AppendLine($"Inner exception is:\n{{\n{ exceptionString }\n}}");
            }

            builder.AppendLine("Exception data:");
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new JsonSerializeExceptionConverter());

            builder.Append(JsonConvert.SerializeObject(CauseValues, Formatting.Indented, settings));

            return builder.ToString();

        }

        public static CausedException NewUnexpectedSwitchArgument(string name, object? value)
        {
            return new Builder()
                .SetMessage($"Unexpected switch argument value: { name }")
                .AddCauseValue(name, value)
                .Build();
        }
    }
}
