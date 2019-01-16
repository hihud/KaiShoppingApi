using Kai.Core.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kai.Service.ProductService
{
    public interface IProductService
    {
        List<ProductModel> GetAllProduct();
        void AddProduct(ProductDto product);
    }
}
