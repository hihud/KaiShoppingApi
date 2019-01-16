using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kai.Core.Product
{
    public class ProductInfoDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("productid")]
        public string ProductId { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
