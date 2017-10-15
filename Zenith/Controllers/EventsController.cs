using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ZenithDataLib.Models;
using System.Globalization;
using Zenith.Models;
using Zenith.Util;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Zenith.Controllers
{
    [Authorize(Roles="Admin")]
    public class EventsController : Controller
    {
        private ApplicationDbContext db;
        private UserManager<ApplicationUser> manager;

        public EventsController()
        {
            db      = new ApplicationDbContext();
            manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        }

        // GET: Events
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var dates = EventUtil.GetDaysOfCurrentWeek();
            var events = db.Events.Include(e => e.ActivityCategory).Where(e => e.IsActive == true).ToList();

            // Sort the events by date time
            events.Sort((x, y) => x.StartDateTime.CompareTo(y.StartDateTime));

            Dictionary<string, List<Event>> dic = new Dictionary<string, List<Event>>();
            foreach (var d in dates)
            {
                dic.Add(d.ToString("D", new CultureInfo("EN-US")), new List<Event>());
                foreach (var e in events)
                {
                    if (e.StartDateTime.Date == d.Date)
                    {
                        dic[d.ToString("D", new CultureInfo("EN-US"))].Add(e);
                    }
                }
            }
            return View( new ScheduleViewModel(){ DaysAndEvents = dic });
        }
        public async Task<ActionResult> Manage()
        {
            return View(await db.Events.Include(e => e.ActivityCategory).ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = await db.Events.Include(e => e.ActivityCategory).Where(e => e.EventId == id).FirstOrDefaultAsync();
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "ActivityCategoryId", "ActivityDescription");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EventId,StartDateTime,EndDateTime,Username,CreationDate,IsActive,ActivityCategoryId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.Username = manager.FindById(User.Identity.GetUserId()).UserName;

                db.Events.Add(@event);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "ActivityCategoryId", "ActivityDescription", @event.ActivityCategoryId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = await db.Events.FindAsync(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "ActivityCategoryId", "ActivityDescription", @event.ActivityCategoryId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EventId,StartDateTime,EndDateTime,Username,CreationDate,IsActive,ActivityCategoryId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityCategoryId = new SelectList(db.ActivityCategories, "ActivityCategoryId", "ActivityDescription", @event.ActivityCategoryId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = await db.Events.FindAsync(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Event @event = await db.Events.FindAsync(id);
            db.Events.Remove(@event);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
