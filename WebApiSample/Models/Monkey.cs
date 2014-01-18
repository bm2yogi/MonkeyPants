using System.Xml.Serialization;

namespace WebApiSample.Models
{
    public class Monkey
    {
        [XmlAttribute]
        public int Id { get; set; }

        public string Name { get; set; }

        public Banana Banana { get; set; }
    }

    public class Banana
    {
        [XmlAttribute]
        public string Color { get; set; }

        [XmlAttribute]
        public decimal Weight { get; set; }

        [XmlAttribute]
        public decimal Calories { get; set; }
    }
}