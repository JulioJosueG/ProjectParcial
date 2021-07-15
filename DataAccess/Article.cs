using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class Article
    {
        public int ArticleId { get; set; }
        public int? IdAuthor { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string ImageAt { get; set; }
        public string CountryCode { get; set; }
        public int? CategoryId { get; set; }
        public int? IdSource { get; set; }
        public int? IdState { get; set; }

        public virtual Category Category { get; set; }
        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Author IdAuthorNavigation { get; set; }
        public virtual Source IdSourceNavigation { get; set; }
        public virtual State IdStateNavigation { get; set; }
    }
}
