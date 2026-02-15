using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities;

public class CartItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; } // Price snapshot at time of adding
    public DateTime AddedAt { get; set; }
    //FK
    public int CartId { get; set; }
    public int ProductId { get; set; }

    //Nav props
    public Cart Cart { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
