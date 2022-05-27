using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfApp1
{
    public class table
    {
        public IEnumerable<Product> products
        {
            get
            {
                XMLFIle xml = new XMLFIle("light_obce.xml");
                return Products.GetProducts(xml.ReadXML());
            }
        }

    }
    public static class Products
    {
        public static IList<Product> Products_list;

        public static IList<Product> GetProducts(IEnumerable<XElement> products)
        {
            List<Product> products1 = new();
            foreach (XElement prod in products.ToList())
            {
                Product product = new();
                foreach (var prod_element in prod.DescendantNodes())
                    product.GetProduct(prod_element);
                products1.Add(product);
            }
            Products_list = products1;
            return products1; 
        }
    }
}
