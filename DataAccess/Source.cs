using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DataAccess
{
    public partial class Source
    {
        public Source()
        {
            Articles = new HashSet<Article>();
        }

        [Required]
        public int IdSource { get; set; }
        [Required]
        public string SourceName { get; set; }
        [Required]
        public int? IdState { get; set; }

        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
