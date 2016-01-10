using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WCFSerialization
{
    public class XMLProduct
    {
        private Guid _productID;
        private string _productName;
        private string _producingArea;
        private double _unitPrice;

        public XMLProduct()
        {
            Console.WriteLine("The constructor of XMLProduct has been invocated!");
        }

        public XMLProduct(Guid id, string name, string producingArea, double price)
        {
            this._productID = id;
            this._productName = name;
            this._producingArea = producingArea;
            this._unitPrice = price;
        }

        [XmlAttribute("id")]
        public Guid ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        [XmlElement("name")]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        [XmlElement("producingArea")]
        internal string ProducingArea
        {
            get { return _producingArea; }
            set { _producingArea = value; }
        }

        [XmlElement("price")]
        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
    }
}
