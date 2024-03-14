using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeApp.Dtos
{
    public class CategoriesData
    {
        public bool Error { get; set; }
        public List<String> Categories { get; set; }
        public long TimeStamp { get; set; }
        public List<CategoryAlias> CategoryAliases { get; set; }
    }
    public class CategoryAlias
    {
        public string Alias { get; set; }
        public string Resolved { get; set; }
    }
}
