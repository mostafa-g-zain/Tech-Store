using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Specification
    {
        public int Id { get; set; }
        public required string SpecKey { get; set; }
        public required string SpecValue { get; set; }
        public int? SortOrder { get; set; }

        //FK
        public int ProductId { get; set; }

        // nav prop
        public Product? Product { get; set; }
    }
}
