using System.IO;
using Newtonsoft.Json;

namespace Serialization
{
    public static class Serializator
    {
        public static void Serealizate(object data, string path)
        {
            string serialisedData = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, serialisedData);
        }
        public static T Deserializate<T>(string path)
        {
            if (!File.Exists(path))
            {
                return default;
            }
            string serialisedData = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(serialisedData);

        }
    }
}