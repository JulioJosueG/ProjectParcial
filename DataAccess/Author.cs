using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DataAccess
{
    public partial class Author
    {
        public Author()
        {
            Articles = new HashSet<Article>();
        }
        [Required]

        public int IdAuthor { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string IdCountry { get; set; }
        [Required]
        public int? IdState { get; set; }

        public virtual Country IdCountryNavigation { get; set; }
        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
