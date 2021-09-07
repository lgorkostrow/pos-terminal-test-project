using Newtonsoft.Json;

namespace PosTerminal.Core.Converters
{
    public interface IConverter
    {
        public T Deserialize<T>(string text);
        public string Serialize<T>(T model);
    }

    public class JsonConverter : IConverter
    {
        public T Deserialize<T>(string text)
        {
            return JsonConvert.DeserializeObject<T>(text);
        }

        public string Serialize<T>(T model)
        {
            return JsonConvert.SerializeObject(model, Formatting.Indented);
        }
    }
}