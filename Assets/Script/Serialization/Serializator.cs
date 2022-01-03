using System.IO;
using Newtonsoft.Json;

namespace Serialization
{
    public static class Serializator
    {
        public static void SerealizateData(object data, string savePath)
        {
            string serialisedData = JsonConvert.SerializeObject(data);
            File.WriteAllText(savePath, serialisedData);
        }
        public static T Deserializate<T>(string savePath)
        {
            string serialisedData = File.ReadAllText(savePath);
            return JsonConvert.DeserializeObject<T>(serialisedData);

        }
    }
}