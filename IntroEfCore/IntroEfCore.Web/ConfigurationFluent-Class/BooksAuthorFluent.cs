using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroEfCore.Web.ConfigurationFluent_Class
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

    }

    public class BooksConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("tblBooks")
                .HasKey(t => t.BookId);

            builder.Property(t => t.BookId)
                .ValueGeneratedOnAdd()
                .HasDefaultValue("int");

            builder.Property(t => t.Title)
                .HasColumnName("Title")                
                .HasMaxLength(500)
                .IsRequired()
                .IsUnicode();

            builder.Property(t => t.PublishedDate)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("PublishedDate");

            builder.Property(t => t.AuthorId)
                .HasColumnName("AuthorId");

            //navigation
            builder.HasOne(t => t.Author)
                .WithMany()
                .HasForeignKey(t => t.AuthorId);

        }
    }
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author")
                .HasKey(t => t.AuthorId);

            builder.Property(t => t.Name)
                .HasColumnName("Name");

        }
    }
}
