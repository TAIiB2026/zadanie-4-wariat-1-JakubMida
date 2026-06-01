using Interfaces;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class FormService : FormSubmitInterface<Product>
    {
        private readonly List<Product> products;

        public FormService(List<Product> products)
        {
            this.products = products;
        }

        public void Add(Product product)
        {
            product.Id = products.Max(x => x.Id) + 1;
            products.Add(product);
        }

        public void Update(int id, Product updated)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
                return;

            product.Nazwa = updated.Nazwa;
            product.Cena = updated.Cena;
            product.DataWaznosci = updated.DataWaznosci;
        }
    }
}
