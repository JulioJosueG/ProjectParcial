using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MVCAdm.Controllers
{
    

    public class AuthorController : Controller
    {

        private readonly NewsProjectDBContext _context;


        private void ViewDatas()
        {
            ViewData["IdCountry"] = new SelectList(_context.Countries, "Code", "CountryName");
            ViewData["IdState"] = new SelectList(_context.States, "IdState", "StateName");


        }

        public AuthorController(NewsProjectDBContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var context = _context.Authors.Include(p => p.IdCountryNavigation).Include(p=> p.IdStateNavigation);
            return View(context.ToList()) ;
        }

       
        public ActionResult Create()
        {
            ViewDatas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("IdAuthor,Name,LastName,IdCountry,IdState")] Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewDatas();
            return View(author);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _context.Authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            ViewDatas();
            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("IdAuthor,Name,LastName,IdCountry,IdState")] Author author)
        {
            if (id != author.IdAuthor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(author);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.IdAuthor))
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
            return View(author);
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.IdAuthor == id);
        }
    }
}
