using JC.Lib.Exceptions.Models;
using Newtonsoft.Json;

namespace JC.Lib.Exceptions.Converters
{
    public class JsonSerializeExceptionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Exception) || objectType.IsSubclassOf(typeof(Exception));
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            var exception = (Exception)value!;
            var innerExceptionData = new InnerExceptionData
            (
                exception.Message,
                exception.StackTrace,
                exception is CausedException causedException ? causedException.CauseValues : null
            );

            serializer.Serialize(writer, innerExceptionData);
        }
    }
}
