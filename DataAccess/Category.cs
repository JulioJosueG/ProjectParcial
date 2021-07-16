using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DataAccess
{
    public partial class Category
    {
        public Category()
        {
            Articles = new HashSet<Article>();
        }

        [Required]
        public int IdCategory { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public int? IdState { get; set; }

        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
