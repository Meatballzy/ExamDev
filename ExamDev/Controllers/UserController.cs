using ExamDev.Infra;
using ExamDev.Infra.Data;
using ExamDev.Infra.Migrations;
using ExamDev.Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.ComponentModel;

namespace ExamDev.WebUi.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<User> AllUser = _context.Users;
            return View(AllUser);
        }
        public IActionResult Create()
        {
            try
            {
                var authenList = (from a in _context.Authens
                                  where (a.Status == true)
                                  select new AuthenVM
                                  {
                                      Id = a.Id,
                                      AuthenName = a.AuthenName,
                                  }).ToList();
                ViewBag.AuthenList = authenList;
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User Us)
        {
            var authenList = (from a in _context.Authens
                              where (a.Status == true)
                              select new AuthenVM
                              {
                                  Id = a.Id,
                                  AuthenName = a.AuthenName,
                              }).ToList();
            ViewBag.AuthenList = authenList;
            if (ModelState.IsValid)
            {
                _context.Add(Us);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(Us);
        }

        public IActionResult Edit(int? id)
        {
            var authenList = (from a in _context.Authens
                              where (a.Status == true)
                              select new AuthenVM
                              {
                                  Id = a.Id,
                                  AuthenName = a.AuthenName,
                              }).ToList();
            ViewBag.AuthenList = authenList;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var data = _context.Users.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User data)
        {
            if (ModelState.IsValid)
            {
                _context.Update(data);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

    }
}
