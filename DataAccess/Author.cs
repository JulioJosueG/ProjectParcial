using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Author
    {
        public Author()
        {
            Articles = new HashSet<Article>();
        }

        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdCountry { get; set; }
        public int? IdState { get; set; }

        public virtual Country IdCountryNavigation { get; set; }
        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
