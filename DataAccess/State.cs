using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class State
    {
        public State()
        {
            Articles = new HashSet<Article>();
            Authors = new HashSet<Author>();
            Categories = new HashSet<Category>();
            Countries = new HashSet<Country>();
            Sources = new HashSet<Source>();
        }

        public int IdState { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Source> Sources { get; set; }
    }
}
