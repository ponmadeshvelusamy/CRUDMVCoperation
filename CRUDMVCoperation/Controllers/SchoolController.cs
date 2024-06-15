using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDMVCLibrary;

namespace CRUDMVCoperation.Controllers
{     
    public class SchoolController : Controller
    {
        SchoolRepostery refobj;
        public SchoolController(IConfiguration configuration)
        {
            refobj=new SchoolRepostery(configuration);
        }
        // GET: SchoolController
        public ActionResult Index()
        {
            var value = refobj.Showall();
            return View("Showall",value);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
