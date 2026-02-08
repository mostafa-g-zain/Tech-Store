using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public required string ImageUrl { get; set; }

        public int SortOrder { get; set; }

        // FK
        public int ProductId { get; set; }

        //Nav prop
        public required Product Product { get; set; }
    }
}
