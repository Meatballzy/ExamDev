using ExamDev.Infra;
using ExamDev.Infra.Data;
using ExamDev.Infra.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace ExamDev.WebUi.Controllers
{
    public class AuthenController : Controller
    {
        private readonly AppDbContext _context;
        public AuthenController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Authen> AllAuthen = _context.Authens;
            return View(AllAuthen);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Authen data)
        {
            if (ModelState.IsValid)
            {
                _context.Add(data);
                _context.SaveChanges();
                TempData["AlertMessage"] = "Authen Create Success!";
                return RedirectToAction("Index");
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var data = _context.Authens.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Authen data)
        {
            if (ModelState.IsValid)
            {
                _context.Update(data);
                _context.SaveChanges();
                TempData["AlertMessage"] = "Authen Edit Success!";
                return RedirectToAction("Index");
            }
            return View(data);
        }

    }
}
