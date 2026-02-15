using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities;

public class Cart
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // FK
    public int UserId { get; set; }


    // Nav Props
    public ApplicationUser User { get; set; } = null!;
    public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
}
