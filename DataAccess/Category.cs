using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }

        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public int? IdState { get; set; }

        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
