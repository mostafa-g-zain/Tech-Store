using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
