using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace FileManagement.ExtensionMethods
{
    public static class XmlExtensions
    {
        public static string ToXml(this object source)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            using (var stringWriter = new StringWriter())
            using (var xmlWriter = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(xmlWriter, source);
                return stringWriter.ToString();
            }
        }
    }
}
