using Kai.Core.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kai.Service.ProductService
{
    public interface IProductService
    {
        List<ProductModel> GetAllProduct();
        ProductModel GetProduct(Guid lusId);
        void AddProduct(ProductDto product);
        ProductModel UpdateProduct(ProductDto product);
    }
}
