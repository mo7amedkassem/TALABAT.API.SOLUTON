using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TALABAT.CORE.Entities;

namespace TALABAT.REPOSITORY.Data.Configuration
{
    internal class ProductConfi : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(p => p.Price)
             .HasPrecision(18, 2); // 18 رقم كحد أقصى، مع رقمين عشريين

            builder.Property(p => p.Description)
                      .IsRequired();

            builder.Property(p => p.Price)
                    .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Brand)
                  .WithMany().
                  HasForeignKey(p => p.BrandId);

            builder.HasOne(p => p.Category)
                  .WithMany()
                  .HasForeignKey(p => p.CategoryId);
        }
    }
}
