using System;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class Book
    {
        public Book() { BookCategory = new List<BookCategory>(); }
        public int BookId { get; set; }
        public string Nombre { get; set; }
        public string Isbn { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public List<BookCategory> BookCategory { get; set; }
    }
}
