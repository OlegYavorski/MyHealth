using MyHealth.Models;
using System;
using System.Web.Mvc;
using System.Linq;


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

        public ActionResult Edit(int id)
        {
            var item = _context.MyPressures.SingleOrDefault(c => c.Id == id);

            if (item == null)
                return HttpNotFound();

            return View("Edit", item);
        }

        public ActionResult Delete(int id)
        {
            var item = _context.MyPressures.SingleOrDefault(c => c.Id == id);

            if (item == null)
                return HttpNotFound();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(MyPressure myPressure)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            if (myPressure.Id == 0)
            {
                _context.MyPressures.Add(myPressure);
            }
            else
            {
                var myPressureInDb = _context.MyPressures.Single(m => m.Id == myPressure.Id);
                myPressureInDb.High = myPressure.High;
                myPressureInDb.Low = myPressure.Low;
                myPressureInDb.When = myPressure.When;
                myPressureInDb.TonometerId = myPressure.TonometerId;
                myPressureInDb.PersonId = myPressure.PersonId;
                myPressureInDb.Comment = myPressure.Comment;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("List", "MyPressure");
        }

    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MyPressure myPressure)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            if (myPressure.Id == 0)
            {
                _context.MyPressures.Add(myPressure);
            }
            else
            {
                var myPressureInDb = _context.MyPressures.Single(m => m.Id == myPressure.Id);
                myPressureInDb.High = myPressure.High;
                myPressureInDb.Low = myPressure.Low;
                myPressureInDb.When = myPressure.When;
                myPressureInDb.TonometerId = myPressure.TonometerId;
                myPressureInDb.PersonId = myPressure.PersonId;
                myPressureInDb.Comment = myPressure.Comment;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("List", "MyPressure");
        }
       
    }
}