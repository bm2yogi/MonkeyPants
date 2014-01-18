using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WebApiSample.Models;

namespace WebApiSample.MediaTypeFormatters
{
    public class MonkeyMediaTypeFormatter : BufferedMediaTypeFormatter
    {
        private readonly Type[] _knownTypes = { typeof(Monkey) };
        private readonly MediaTypeHeaderValue _mediaType = new MediaTypeHeaderValue("application/vnd.bm2yogi+xml");
        private readonly XmlWriterSettings _xmlWriterSettings;
        private readonly XmlSerializerNamespaces _serializerNamespaces;

        public MonkeyMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(_mediaType);
            SupportedEncodings.Add(Encoding.UTF8);

            _xmlWriterSettings = new XmlWriterSettings { OmitXmlDeclaration = true };

            _serializerNamespaces = new XmlSerializerNamespaces();
            _serializerNamespaces.Add("dap", "http://dap.bm2yogi.com/schemas");
        }

        public override bool CanReadType(Type type)
        {
            return _knownTypes.Contains(type);
        }

        public override bool CanWriteType(Type type)
        {
            return _knownTypes.Contains(type);
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = XmlWriter.Create(writeStream, _xmlWriterSettings))
            {
                new XmlSerializer(type).Serialize(writer, value, _serializerNamespaces);
            }
        }
    }
}