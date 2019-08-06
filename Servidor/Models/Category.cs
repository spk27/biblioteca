using System;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class Category
    {
        public Category() { BookCategory = new List<BookCategory>(); }
        public int CategoryId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<BookCategory> BookCategory { get; set; }
    }
}
