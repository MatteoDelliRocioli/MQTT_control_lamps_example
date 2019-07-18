namespace display_lamps_console
{
    using Newtonsoft.Json;
    using System.IO;
    using System.Text;

    public class Utils
    {
        // https://stackoverflow.com/questions/9337255/serialize-deserialize-a-byte-array-in-json-net
        public static T Deserialize<T>(byte[] data) where T : class
        {
            using (var stream = new MemoryStream(data))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
                return JsonSerializer.Create().Deserialize(reader, typeof(T)) as T;
        }
        // https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
        // https://stackoverflow.com/questions/52650402/serialize-newtonsoft-json-to-byte-array
        public static byte[] Serialize<T>(T obj)
        {
            string strValue = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(strValue);
        }
    }
}
