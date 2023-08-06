using ExamDev.Infra;
using ExamDev.Infra.Data;
using ExamDev.Infra.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ExamDev.WebUi.Controllers
{
    public class LogController : Controller
    {
        private readonly AppDbContext _context;
        public LogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Log> AllLog = _context.Logs;
            return View(AllLog);
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
        public IActionResult Create(Log lg)
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
            var data = _context.Logs.Find(id);
            if (data != null)
            {
                return View(data);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Log data)
        {
            if (ModelState.IsValid)
            {
                _context.Update(data);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }
        public IActionResult Report(string? name)
        {
            var data = _context.Logs.Find(name);
            if (data != null)
            {
                return View(data);
            }
            return View();
        }
    }
}
