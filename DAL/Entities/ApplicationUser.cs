using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? FullName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        // Nav prop
        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();
    }
}
