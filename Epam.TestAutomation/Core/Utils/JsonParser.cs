using Newtonsoft.Json;

namespace Epam.TestAutomation.Core.Utils;

public class JsonParser
{
    public static T DeserializeJsonToObject<T>(string json) where T : class => JsonConvert.DeserializeObject<T>(json);
    public static string SerializeJson(object content) => JsonConvert.SerializeObject(content);

    public static List<T> DeserializeJsonToObjects<T>(string json) where T : class =>
        JsonConvert.DeserializeObject<List<T>>(json);
}