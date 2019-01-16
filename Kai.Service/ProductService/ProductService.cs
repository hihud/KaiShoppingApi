using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Kai.Core.Product;
using Microsoft.Extensions.Configuration;
using Neo4j.Driver.V1;
using Neo4jClient;
using Neo4jClient.Cypher;
using Newtonsoft.Json;

namespace Kai.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly GraphClient _client;

        public ProductService(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
            _client = new GraphClient(new Uri(_config["DatabaseServer"]),_config["DatabaseUser"], _config["DatabasePassword"]);
            _client.Connect();
        }

        public List<ProductModel> GetAllProduct()
        {
            var results = _client.Cypher
            .Match("(n: Product)")
            .Return(n => n.As<ProductDto>())
            .Results;
            return _mapper.Map<List<ProductModel>>(results);
        }

        public void AddProduct(ProductDto product)
        {
            if(product !=null)
            {
                _client.Cypher
            .Create("(n:Product {product})")
            .WithParams(new { product })
            .ExecuteWithoutResults();
            }
        }
    }
}
