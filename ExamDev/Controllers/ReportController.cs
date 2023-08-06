using ExamDev.Infra;
using ExamDev.Infra.Data;
using ExamDev.Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExamDev.WebUi.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;
        public ReportController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Report> AllRep = _context.Reports;
            return View(AllRep);
        }
        public IActionResult Create()
        {
            var userList = (from a in _context.Users
                              where (a.Status == true)
                              select new UserVM
                              {
                                  Id = a.Id,
                                  FullName = a.FullName,
                              }).ToList();
            ViewBag.UserList = userList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Report lg)
        {
            var userList = (from a in _context.Users
                            where (a.Status == true)
                            select new UserVM
                            {
                                Id = a.Id,
                                FullName = a.FullName,
                            }).ToList();
            ViewBag.UserList = userList;
            if (ModelState.IsValid)
           {
                var diffOfDates = lg.End.Subtract(lg.Start);
                lg.Days = diffOfDates.Days;
                _context.Add(lg);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lg);
        }
        public IActionResult Edit(int? id)
        {
            var userList = (from a in _context.Users
                            where (a.Status == true)
                            select new UserVM
                            {
                                Id = a.Id,
                                FullName = a.FullName,
                            }).ToList();
            ViewBag.UserList = userList;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var data = _context.Reports.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Report data)
        {
            if (ModelState.IsValid)
            {
                var diffOfDates = data.End.Subtract(data.Start);
                data.Days = diffOfDates.Days;
                _context.Update(data);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        public IActionResult Arp(int? id)
        {
            var userList = (from a in _context.Users
                            where (a.Status == true)
                            select new UserVM
                            {
                                Id = a.Id,
                                FullName = a.FullName,
                            }).ToList();
            ViewBag.UserList = userList;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var data = _context.Reports.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return View();
        }

    }
}
