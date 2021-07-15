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
        

        public List<SelectListItem> OptionsCa{ get; set; }
        public List<SelectListItem> OptionsCo { get; set; }
        public List<SelectListItem> OptionsAu { get; set; }
        public List<SelectListItem> OptionsSo { get; set; }


        public IndexModel(
            NewsProjectDBContext context,
            ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }


        private void Views()
        {
            /* categories =  _context.Categories.Include(p => p.IdStateNavigation).Where(p => p.IdState == 1).ToList();
            countries = _context.Countries.Include(p => p.IdStateNavigation).Where(p => p.IdState == 1).ToList();
            sources = _context.Sources.Include(p => p.IdStateNavigation).Where(p => p.IdState == 1).ToList();
            authors = _context.Authors.Include(p => p.IdStateNavigation).Include(p=> p.IdCountryNavigation).Where(p => p.IdState == 1).ToList();*/
            OptionsCa = _context.Categories.Select(a =>
                                 new SelectListItem
                                 {
                                     Value = a.IdCategory.ToString(),
                                     Text = a.CategoryName
                                 }).ToList();

            OptionsCo = _context.Countries.Select(a =>
                                             new SelectListItem
                                             {
                                                 Value = a.Code.ToString(),
                                                 Text = a.CountryName
                                             }).ToList(); 
            OptionsAu = _context.Authors.Select(a =>
                                             new SelectListItem
                                             {
                                                 Value = a.IdAuthor.ToString(),
                                                 Text = a.Name
                                             }).ToList(); 
            OptionsSo = _context.Sources.Select(a =>
                                             new SelectListItem
                                             {
                                                 Value = a.IdSource.ToString(),
                                                 Text = a.SourceName
                                             }).ToList();
        }

        public async Task  OnGetAsync(string Search , int? idCategoria, int? idContry, int? idAuthor, int? idSource)
        {
            Views();
            
            if (idCategoria != null)
            {
                Articles = await _context.Articles.Include(p => p.CountryCodeNavigation).Include(p => p.IdAuthorNavigation).
                    Include(p => p.IdSourceNavigation).Include(p => p.IdStateNavigation).Where(p => p.CategoryId == idCategoria & p.IdState == 1).ToListAsync();
            }
            else if (idContry != null)
            {
                Articles = await _context.Articles.Include(p => p.CountryCodeNavigation).Include(p => p.IdAuthorNavigation).
                    Include(p => p.IdSourceNavigation).Include(p => p.IdStateNavigation).Where(p => p.CategoryId == idContry & p.IdState == 1).ToListAsync();
            }
            else if (idAuthor != null)
            {
                Articles = await _context.Articles.Include(p => p.CountryCodeNavigation).Include(p => p.IdAuthorNavigation).
                    Include(p => p.IdSourceNavigation).Include(p => p.IdStateNavigation).Where(p => p.CategoryId == idAuthor & p.IdState == 1).ToListAsync();
            }
            else if (idSource != null)
            {
                Articles = await _context.Articles.Include(p => p.CountryCodeNavigation).Include(p => p.IdAuthorNavigation).
                    Include(p => p.IdSourceNavigation).Include(p => p.IdStateNavigation).Where(p => p.CategoryId == idSource & p.IdState == 1).ToListAsync();
            }

            if (string.IsNullOrEmpty(Search))
            {
                Articles = await _context.Articles.Include(p => p.CountryCodeNavigation).Include(p => p.IdAuthorNavigation).
                    Include(p => p.IdSourceNavigation).Include(p => p.IdStateNavigation).Where(p => p.IdState == 1).ToListAsync();
            }
            else
            {
                Articles = await _context.Articles.Include(p => p.CountryCodeNavigation).Include(p => p.IdAuthorNavigation).
                    Include(p => p.IdSourceNavigation).Include(p => p.IdStateNavigation).Where(p => p.Title.Contains(Search) & p.IdState == 1).ToListAsync();

            }

        }


    }
}
