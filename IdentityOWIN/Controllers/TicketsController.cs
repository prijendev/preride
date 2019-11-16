using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityOWIN;
using Microsoft.AspNet.Identity;

namespace IdentityOWIN.Controllers
{
    public class TicketsController : Controller
    {
        private Entities1 db = new Entities1();
        private Ticket tck  = new Ticket();

        // GET: Tickets
        public ActionResult Index(int id, DateTime date)
        {
            
            TempData["id"] = id;
            TempData["date"] = date;

            
            return View();
        }
        [HttpPost]
        public ActionResult Index()
        {
            
            
            var ticketlist = new List<String>();

            //ViewBag["id"] = date;
            //ViewBag.dt = dt;
            //ViewBag["tickets"] = tick;

            /*var tickets = from m in db.Tickets select m;

            tickets = tickets.Where(m => m.Bus_Id == id);
            tickets = tickets.Where(m => m.Date == date);

            tickets = tickets.Where(m => m.User_Id == user.GetUserId());

            var tick = tickets.Select(m => m.ticketNo);*/
            
           //var tickets1 = db.Tickets.Include(t => t.AspNetUser).Include(t => t.Bus);
            return View();
        }


        [HttpPost]
        public ActionResult Book(string tickets)
        {
            

            string str = tickets;
            string[] tickets1;
            tickets1 = str.Split(',');
            int[] tk = new int[tickets1.Length];

            

            tck.Bus_Id =(int)TempData["id"];
            tck.Date = (DateTime)TempData["date"];
            var user = User.Identity;
            tck.User_Id = user.GetUserId();

            int i;
            for( i=0; i<tickets1.Length; i++)
            {
                tk[i] = Convert.ToInt32(tickets[i]);
                tck.ticketNo = tk[i];

                db.Tickets.Add(tck);
                db.SaveChanges();
                

            }
            if (i == tickets1.Length)
                return Content(tickets);
            else
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
