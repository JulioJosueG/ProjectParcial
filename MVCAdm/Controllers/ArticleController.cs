using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess;

namespace MVCAdm.Controllers
{
    public class ArticleController : Controller
    {
        private readonly NewsProjectDBContext _context;


        private void ViewDatas()
        {
            ViewData["IdAuthor"] = new SelectList(_context.Authors, "IdAuthor", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "IdCategory", "CategoryName");
            ViewData["CountryCode"] = new SelectList(_context.Countries, "Code", "CountryName");
            ViewData["IdSource"] = new SelectList(_context.Sources, "IdSource", "SourceName");
            ViewData["IdState"] = new SelectList(_context.States, "IdState", "StateName");

        }

        public ArticleController(NewsProjectDBContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var context = _context.Articles.Include(p => p.Category).Include(p => p.IdAuthorNavigation).Include(p => p.IdSourceNavigation).
                Include(p => p.CountryCodeNavigation).Include(p => p.IdStateNavigation);
            return View( context.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Article =  _context.Articles
                .Include(p => p.Category)
                .Include(p => p.IdAuthorNavigation)
                .Include(p => p.CountryCodeNavigation)
                .Include(p => p.IdSourceNavigation)
                .FirstOrDefault(m => m.ArticleId == id);
            if (Article == null)
            {
                return NotFound();
            }

            return View(Article);
        }

        public ActionResult Create()
        {
            ViewDatas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create([Bind("ArticleId,Nombre,idAuthor,Title,content,PublishedAt,imageAt,CountryCode,CategoryId,IdSource,idState")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                  _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewDatas();
            return View(article);
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var article =  _context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewDatas();
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ArticleId,Nombre,idAuthor,Title,content,PublishedAt,imageAt,CountryCode,CategoryId,IdSource,idState")] Article article)
        {
            if (id != article.ArticleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.ArticleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewDatas();
            return View(article);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _context.Articles
                .Include(p => p.Category)
                .Include(p => p.IdAuthorNavigation)
                .Include(p => p.CountryCodeNavigation)
                .Include(p => p.IdSourceNavigation)
                .FirstOrDefault(m => m.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var article =  _context.Articles.Find(id);
            _context.Articles.Remove(article);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
