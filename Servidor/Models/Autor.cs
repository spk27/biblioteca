using System;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class Autor
    {
        public Autor() { Book = new List<Book>(); }
        public int AutorId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public List<Book> Book { get; set; }
    }
}
