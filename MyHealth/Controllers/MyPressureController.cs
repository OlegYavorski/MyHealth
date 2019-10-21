using MyHealth.Models;
using System;
using System.Web.Mvc;


namespace MyHealth.Controllers
{
    public class MyPressureController : Controller
    {
        private ApplicationDbContext _context;

        public MyPressureController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: MyPressure
        public ActionResult Index()
        {
            var model = _context.MyPressures;
            return View("List", model);
        }

        // GET: MyPressure
        public ActionResult List()
        {
            var model = _context.MyPressures;
            return View("List", model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MyPressure myPressure)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            _context.MyPressures.Add(myPressure);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index", "MyPressures");
        }
       
    }
}