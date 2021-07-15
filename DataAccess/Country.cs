using System;
using System.Collections.Generic;

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

        public string Code { get; set; }
        public string CountryName { get; set; }
        public int? IdState { get; set; }

        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}
