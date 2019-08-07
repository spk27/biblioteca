using System.Collections.Generic;
using System.Linq;
namespace Biblioteca.Models.ViewModels
{
    public class ViewBook
    {
        public Book Book { get; set; }
        public List<Category> Categories { get; set; }
    }
}
