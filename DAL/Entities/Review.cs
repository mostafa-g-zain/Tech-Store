using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public bool IsApproved { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        //FK
        public int ProductId { get; set; }
        public int UserId { get; set; }

        //Nav prop
        public Product Product { get; set; }
        public ApplicationUser User { get; set; }
    }
}
