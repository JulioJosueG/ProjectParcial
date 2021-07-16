using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DataAccess
{
    public partial class Country
    {
        public Country()
        {
            Articles = new HashSet<Article>();
            Authors = new HashSet<Author>();
        }

        [Required]
        public string Code { get; set; }
        [Required]
        public string CountryName { get; set; }
        [Required]
        public int? IdState { get; set; }

        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
