using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kai.Core.Product
{
    public class ProductDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("collection")]
        public string Collection { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("provider")]    
        public string Provider { get; set; }
        [JsonProperty("material")]
        public string Material { get; set; }



    }
}
