using EF_Study.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EF_Study.DataAccess.FluentConfig;

public class FluentBookDetailConfig : IEntityTypeConfiguration<FluentBookDetail>
{
    public void Configure(EntityTypeBuilder<FluentBookDetail> modelBuilder) //this is another way to set the db
    {
        //follow this order =>

        //name of table
        modelBuilder.ToTable("Fluent_BookDetails");

        //name of columns
        modelBuilder.Property(b => b.NumberOfChapters).HasColumnName("Chapters");

        //primary key
        modelBuilder.HasKey(b => b.BookDetail_Id);

        //required or not
        modelBuilder.Property(b => b.NumberOfChapters).IsRequired();


        //relations
        modelBuilder.HasOne(b => b.Book).WithOne(b => b.BookDetail).HasForeignKey<FluentBookDetail>(b => b.Book_Id);
    }
}
