using System;
using System.IO;
using NUnit.Framework;
using Sahara;
using WebApiSample.MediaTypeFormatters;
using WebApiSample.Models;

namespace XmlParsingTests
{
    [TestFixture]
    public class XmlDataContractSerializing
    {
        [Test]
        public void It_should_deserialize_to_xml_with_attributes()
        {
            string xml;
            const string expected = @"<Monkey xmlns:dap=""http://dap.bm2yogi.com/schemas"" Id=""42""><Name>Bonzo</Name><Banana Color=""Yellow"" Weight=""126"" Calories=""100"" /></Monkey>";

            using(var stream = new MemoryStream())
            {
                new MonkeyMediaTypeFormatter().WriteToStream(typeof (Monkey), MonkeyFactory.Create(), stream, null);

                using (var reader = new StreamReader(stream))
                {
                    stream.Position = 0;
                    xml = reader.ReadToEnd();
                }
            }

            xml.ShouldEqual(expected);
        }
    }
}