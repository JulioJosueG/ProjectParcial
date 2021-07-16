using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DataAccess
{
    public partial class Article
    {
        [Required]
        public int ArticleId { get; set; }
        [Required]

        public int? IdAuthor { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]

        public string Content { get; set; }
        [Required]

        public DateTime? PublishedAt { get; set; }
        [Required]

        public string ImageAt { get; set; }
        [Required]

        public string CountryCode { get; set; }
        [Required]

        public int? CategoryId { get; set; }
        [Required]

        public int? IdSource { get; set; }
        [Required]

        public int? IdState { get; set; }

        public virtual Category Category { get; set; }
        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Author IdAuthorNavigation { get; set; }
        public virtual Source IdSourceNavigation { get; set; }
        public virtual State IdStateNavigation { get; set; }
    }
}
