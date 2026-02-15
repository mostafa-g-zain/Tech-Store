using System;
using System.Collections.Generic;
using System.Text;

using DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class CartItemConfig : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(ci => ci.Id);

        builder.Property(ci => ci.Quantity)
            .IsRequired();

        builder.Property(ci => ci.UnitPrice)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(ci => ci.Quantity)
            .IsRequired()
            .HasAnnotation("MinValue", 1);

        builder.Property(ci => ci.AddedAt)
            .IsRequired();

        builder.HasIndex(ci => new { ci.ProductId, ci.CartId })
            .IsUnique();

        // M-1 with Product
        builder.HasOne(ci => ci.Product)
            .WithMany()                     // No nav prop in the product (the other side), thu it's uni-directional.
            .HasForeignKey(ci => ci.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // M-1 with Cart
        builder.HasOne(ci => ci.Cart)
            .WithMany(ci => ci.CartItems)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
