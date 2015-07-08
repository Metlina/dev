using System.IO;
using System.Xml.Serialization;

namespace TestXml.Helpers
{
    public class XmlHelpers
    {
        public static string Serialize<T>(T value)
        {
            if (value == null)
            {
                return null;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, value);
                return textWriter.ToString();
            }
        }

        public static T Deserialize<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringReader textReader = new StringReader(xml))
            {
                return (T)serializer.Deserialize(textReader);
            }
        }
    }
}
