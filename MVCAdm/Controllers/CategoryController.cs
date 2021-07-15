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
    public class CategoryController : Controller
    {

        private readonly NewsProjectDBContext _context;

        public CategoryController(NewsProjectDBContext context)
        {
            _context = context;
        }

        private void ViewDatas()
        {
            ViewData["IdState"] = new SelectList(_context.States, "IdState", "StateName");

        }
        public ActionResult Index()
        {
            var context = _context.Categories.Include(p => p.IdStateNavigation);
            return View(context.ToList());
        }

       

        public ActionResult Create()
        {
            ViewDatas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("IdCategory,CategoryName,IdState")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewDatas();
            return View(category);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewDatas();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("IdCategory,CategoryName,IdState")] Category category)
        {
            if (id != category.IdCategory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CateogryExists(category.IdCategory))
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
            return View(category);
        }

        private bool CateogryExists(int id)
        {
            return _context.Categories.Any(e => e.IdCategory == id);
        }
    }
}
