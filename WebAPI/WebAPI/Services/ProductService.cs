using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using WebAPI.Models;

namespace Services
{
    public class ProductService : GetDataInterface<Product>
    {
        private readonly List<Product> products;

        public ProductService(List<Product> products)
        {
            this.products = products;
        }
        public IEnumerable<Product> GetAll() => products;

        public Product GetById(int id)
        {
            var product = products.FirstOrDefault(p =>  p.Id == id);
            return product; 
        }

        public void Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if(product != null)
            {
                products.Remove(product);
            }
        }
    }
}
