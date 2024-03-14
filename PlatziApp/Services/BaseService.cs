using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziApp.Services
{
    public abstract class BaseService<T> where T : class
    {
        protected readonly string _baseUrl;

        protected HttpClient _httpClient;
        public BaseService()
        {
        
            _baseUrl = "https://api.escuelajs.co/api/v1/";
        }

        public  abstract Task Create(T obj);
        public  abstract Task< IEnumerable<T> > GetAll();
        public  abstract Task<T?> Get(int id);
        public  abstract Task Delete(int id);
        public  abstract Task Update(T obj);


    }
}
