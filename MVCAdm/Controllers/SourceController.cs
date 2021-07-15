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
    public class SourceController : Controller
    {

        private readonly NewsProjectDBContext _context;

        public SourceController(NewsProjectDBContext context)
        {
            _context = context;
        }
        private void ViewDatas()
        {
            ViewData["IdState"] = new SelectList(_context.States, "IdState", "StateName");

        }
        public ActionResult Index()
        {
            var context = _context.Sources.Include(p => p.IdStateNavigation);
            return View(context.ToList());
        }


        public ActionResult Create()
        {
            ViewDatas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("IdSource,SourceName,IdState")] Source source)
        {
            if (ModelState.IsValid)
            {
                _context.Add(source);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewDatas();
            return View(source);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sources = _context.Sources.Find(id);
            if (sources == null)
            {
                return NotFound();
            }
            ViewDatas();
            return View(sources);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("IdSource,SourceName,IdState")] Source source)
        {
            if (id != source.IdSource)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(source);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SourceExists(source.IdSource))
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
            return View(source);
        }

        private bool SourceExists(int id)
        {
            return _context.Sources.Any(e => e.IdSource == id);
        }
    }
}
