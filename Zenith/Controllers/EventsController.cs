using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;
using System.Globalization;
using Zenith.Models;

namespace Zenith.Controllers
{
    [Authorize(Roles="Admin")]
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public async Task<ActionResult> Index()
        {
            var events = db.Events.Include(E => E.ActivityCategory);
            return View(await events.ToListAsync());
        }
        public async Task<ActionResult> Schedule()
        {
            return View(getDic());
        }
        public ScheduleViewModel getDic()
        {
            DateTime startOfWeek = DateTime.Today.AddDays(
                (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
                (int)DateTime.Today.DayOfWeek);

            string result = string.Join("," + Environment.NewLine, Enumerable
              .Range(0, 7)
              .Select(i => startOfWeek
                 .AddDays(i)
                 .ToString("dd-MMMM-yyyy")));
            var weekDays = result.Split(',');
            List<DateTime> dates = new List<DateTime>();
            foreach(var w in weekDays)
            {
                dates.Add(Convert.ToDateTime(w));
            }

            //can't get this this to work; can't use datetimes in linq query, all online says is dbfunctions.truncatetime but still doesn't work
            //var events = db.Events.Include(e => e.ActivityCategory).Where(e => dates.Any(d => DbFunctions.TruncateTime(d.Date) == e.CreationDate.Date)).ToList();

            var events = db.Events.Include(e => e.ActivityCategory).ToList();
            Dictionary<string, List<Event>> dic = new Dictionary<string, List<Event>>();
            foreach (var d in dates)
            {
                dic.Add(GetDateString(d), new List<Event>());
                foreach (var e in events)
                {
                    if(e.StartDateTime.Date == d.Date)
                    {
                        dic[GetDateString(d)].Add(e);
                    }
                }
            }
            

            return new ScheduleViewModel()
            {
                DaysAndEvents = dic
            };


        }
        public string GetDateString(DateTime date)
        {
            return date.DayOfWeek.ToString() + " " + date.ToString("MMMM") + " " + date.Day.ToString() + ", " + date.Year.ToString();
        }
        // GET: Events/Details/5
        public async Task<ActionResult> Details(int? id)
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
