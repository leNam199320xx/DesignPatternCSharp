using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Structural
{
    internal class FacedeDesignPattern
    {
        public class Order
        {
            public void PlaceOrder()
            {
                Console.WriteLine("Bat dau dat hang");
                Product product = new Product();
                product.GetProductDetails();
                Payment payment = new Payment();
                payment.MakePayment();
                Invoice invoice = new Invoice();
                invoice.Sendinvoice();
                Console.WriteLine("Dat hang thanh cong");
            }
        }
        public class Product
        {
            public void GetProductDetails()
            {
                Console.WriteLine("Chi tiet san pham");
            }
        }

        public class Payment
        {
            public void MakePayment()
            {
                Console.WriteLine("Thanh toan thanh cong !");
            }
        }

        public class Invoice
        {
            public void Sendinvoice()
            {
                Console.WriteLine("Gui hoa don thanh cong !");
            }
        }

    }
}
