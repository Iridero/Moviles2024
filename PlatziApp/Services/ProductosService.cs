using Newtonsoft.Json;
using PlatziApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlatziApp.Services
{
    internal class ProductosService : BaseService<Product>
    {
        private readonly string _url;
        public ProductosService()
        {
            _url = $"{_baseUrl}products";
            _httpClient = new HttpClient();
        }

        public override Task Create(Product obj)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task<Product?> Get(int id)
        {
            /*var url = $"{_url}/{id}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            
            var json = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(json);
            */
            var url = $"{_url}/{id}";
            HttpRequestMessage httpRequest = 
                new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage httpResponse = 
                await _httpClient.SendAsync(httpRequest);
            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(content);
                product.Etag = httpResponse.Headers.ETag.ToString();
                return product;
            }
            return null;
        }

        public override Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task Update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
