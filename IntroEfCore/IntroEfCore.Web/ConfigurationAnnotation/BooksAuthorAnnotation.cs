using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroEfCore.Web.ConfigurationAnnotation
{
    [Table("abc_Books")]
    public class Book
    {
        [Key]
        [Column("Id")]
        public int BookId { get; set; }
        [Column("Title")]
        [MaxLength(150)]
        public string Title { get; set; }
        [Column("PublishedDate")]
        [Required]
        public DateTime PublishedDate { get; set; }
        [ForeignKey("Author")]
        public int AuthorKey { get; set; }
        public Author Author { get; set; }
    }
    [Table("Authors")]
    public class Author
    {
        [Key]
        public int AuthorKey { get; set; }
        [Column("FirstName")]
        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Column("LastName")]
        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string LastName { get; set; }
        [NotMapped]
        public string Name => FirstName + " " + LastName;

    }
}
