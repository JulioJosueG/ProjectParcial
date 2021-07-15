using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Source
    {
        public Source()
        {
            Articles = new HashSet<Article>();
        }

        public int IdSource { get; set; }
        public string SourceName { get; set; }
        public int? IdState { get; set; }

        public virtual State IdStateNavigation { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
