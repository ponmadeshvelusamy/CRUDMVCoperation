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
        public ActionResult Details(long id)
        {
            var datas=refobj.getbyID(id).FirstOrDefault();
            return View("Details",datas);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            var insert=new Schoolmodel();
            return View("Create",insert);
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Schoolmodel collection)
        {
            try
            {
                refobj.Schoolin(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(long id)
        {
            var values = refobj.getbyID(id).FirstOrDefault();
            return View("Edit",values);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Schoolmodel refer)
        {
            try
            {
                refobj.Update(refer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(long id)
        {
            var values =refobj.getbyID(id).FirstOrDefault();
            return View("Delete",values);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Schoolmodel values)
        {
            try
            {
                var ID = values.SchoolID;
                refobj.Delete(ID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
