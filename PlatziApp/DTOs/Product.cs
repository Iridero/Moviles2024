﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziApp.DTOs
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<string> Images { get; set; }

        public string Etag { get; set; }
    }
}
