using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QueuedService.Contract
{
    [DataContract]
    public class OrderItem
    {
        private Guid _productID;
        private string _productName;
        private decimal _unitPrice;
        private int _quantity;

        public OrderItem() { }

        public OrderItem(Guid productID, string productName, decimal unitPrice, int quantity)
        {
            this._productID = productID;
            this._productName = productName;
            this._unitPrice = unitPrice;
            this._quantity = quantity;
        }

        [DataMember]
        public Guid ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        [DataMember]
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        [DataMember]
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
    }
}
