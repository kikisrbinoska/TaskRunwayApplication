using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskRunwayApplication.Models;

namespace TaskRunwayApplication.Controllers
{
    public class TasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tasks
        public ActionResult Index()
        {
            return View(db.Tasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,DueDate,UserId,Spent,TaskStatus,Category")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Calendar");
            }

            return View("Create",task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,DueDate,UserId,Spent,TaskStatus,Category")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST: Tasks/SaveTasks
        [HttpPost]
        public ActionResult SaveTasks(FormCollection form)
        {
            foreach (var key in form.AllKeys)
            {
                if (key.StartsWith("timeSpent_"))
                {
                    var taskId = int.Parse(key.Substring("timeSpent_".Length));
                    var spent = int.Parse(form[key]);

                    var task = db.Tasks.Find(taskId);
                    if (task != null)
                    {
                        task.Spent += spent;
                        db.Entry(task).State = EntityState.Modified;
                    }
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Tasks/Statistics
        public ActionResult Statistics()
        {
            var tasks = db.Tasks.ToList();
            return View(tasks);
        }

        //GET: Tasks/GetEvents
        public JsonResult GetEvents()
        {
            var tasks = db.Tasks.ToList();
            var events = tasks.Select(t => new
            {
                title = t.Title,
                start = t.DueDate.ToString("yyyy-MM-ddTHH:mm:ss")
            });

            return Json(events, JsonRequestBehavior.AllowGet);
        }
        // GET: Tasks/Calendar
        public ActionResult Calendar()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
