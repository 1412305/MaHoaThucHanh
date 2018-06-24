using System.IO;
using System.Xml.Serialization;

namespace DoAnThucHanh.App.Services
{
    public class XmlService
    {
        public XmlService()
        {

        }

        public void WriteToXml<T>(string fileName, object obj)
        {
            using (var streamWriter = new StreamWriter(fileName))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(streamWriter, obj);
            }
        }
    }
}
