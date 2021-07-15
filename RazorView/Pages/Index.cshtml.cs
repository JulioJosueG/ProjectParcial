using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace RazorView.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NewsProjectDBContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IList<Article> Articles { get; set; }

        public IndexModel(
            NewsProjectDBContext context,
            ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public int[] arreglo = { 1, 2, 3, 4 };
        

        public async Task  OnGetAsync(string SearchString= null)
        {
          
            if (string.IsNullOrEmpty(SearchString))
            {
                Articles = await _context.Articles.Include(p => p.CountryCodeNavigation).Include(p => p.IdAuthorNavigation).
                    Include(p => p.IdSourceNavigation).Include(p => p.IdStateNavigation).ToListAsync();
            }
            else
            {
                Articles = await _context.Articles.Include(p => p.CountryCodeNavigation).Include(p => p.IdAuthorNavigation).
                    Include(p => p.IdSourceNavigation).Include(p => p.IdStateNavigation).Where(p => p.Title.Contains(SearchString)).ToListAsync()
                    ;
            }

        }

      

        public IActionResult OnGetArticles()
        {
           
            return new OkObjectResult(_context.Articles.Include(p => p.IdSourceNavigation).Include(p => p.IdAuthorNavigation).
                Include(p => p.IdStateNavigation).Include(p => p.CountryCodeNavigation));

        }

        

    }
}
