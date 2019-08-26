﻿using System;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class BookCategory
    {
        public int BookCategoryId { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public Book Book { get; set; }
        public Category Category { get; set; }
    }
}
