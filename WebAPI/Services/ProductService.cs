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
        private readonly List<Product> products = new()
        {
            new Product { Id = 1, Nazwa = "Laptop", Cena = 3500, DataWaznosci = new DateOnly(2020, 05, 06), },
            new Product { Id = 2, Nazwa = "Mysz", Cena = 300, DataWaznosci = new DateOnly(2022, 04, 03), },
            new Product { Id = 3, Nazwa = "Monitor", Cena = 600, DataWaznosci = new DateOnly(2023, 11, 22), }
        };
        public IEnumerable<Product> GetAll() => products;
        public Product GetById(int id)
        {
            var product = products.FirstOrDefault(p =>  p.Id == id);
            return product; 
        }
    }
}
