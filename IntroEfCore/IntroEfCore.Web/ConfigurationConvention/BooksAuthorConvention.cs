using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroEfCore.Web.ConfigurationExamples
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
}
