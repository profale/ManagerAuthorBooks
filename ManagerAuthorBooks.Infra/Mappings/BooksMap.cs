using ManagerAuthorBooks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerAuthorBooks.Infra.Mappings
{
    public class BooksMap : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.ISBN)
               .IsRequired()
               .HasColumnType("varchar(20)");

            builder.Property(p => p.Category)
              .IsRequired()
              .HasColumnType("varchar(40)");

            builder.ToTable("Books");
        }
    }
}
