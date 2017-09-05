using DemoWindowsApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesetApp.Controllers
{
    public class pesronController : Controller
    {
        DBConnect context = new DBConnect();
        // GET: pesron
        public ActionResult Index()
        {
            List<Person> data = context.SelectAll();
            return View(data);
        }

        // GET: pesron/Details/5
        public ActionResult Details(int id)
        {
            Person p = context.Select(id);
            return View(p);
        }

        // GET: pesron/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pesron/Create
        [HttpPost]
        public ActionResult Create(Person p)
        {
            try
            {
                // TODO: Add insert logic here
                context.Insert(p);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(p);
            }
        }

        // GET: pesron/Edit/5
        public ActionResult Edit(int id)
        {
            Person p = context.Select(id);
            return View(p);
        }

        // POST: pesron/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [System.Web.Http.FromBody] Person p)
        {
            try
            {
                context.Update(p);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: pesron/Delete/5
        public ActionResult Delete(int id)
        {
            Person p = context.Select(id);
            return View(p);
        }

        // POST: pesron/Delete/5
        [HttpPost]
        public ActionResult Delete(Person p)
        {
            try
            {
                // TODO: Add delete logic here
                context.Delete(p.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(p);
            }
        }
    }
}
