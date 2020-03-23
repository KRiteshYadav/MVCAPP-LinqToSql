using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp_Linq.Controllers
{
    public class FriendCRUDController : Controller
    {
        // GET: FriendCRUD
        DataClasses2DataContext dc = new DataClasses2DataContext();
        public ActionResult Index()
        {
            var friendDetails = from x in dc.Tables select x;
            return View(friendDetails);
        }

        // GET: FriendCRUD/Details/5
        public ActionResult Details(int id)
        {
            var getFriendDetails = dc.Tables.Single(x => (x.FreindId) == id.ToString());
            return View(getFriendDetails);
        }

        // GET: FriendCRUD/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: FriendCRUD/Create
        [HttpPost]
        public ActionResult Create(Table collection)
        {
            try
            {
                // TODO: Add insert logic here
                dc.Tables.InsertOnSubmit(collection);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendCRUD/Edit/5
        public ActionResult Edit(int id)
        {
            var getFriendDetails = dc.Tables.Single(x => x.FreindId == id.ToString());
            return View(getFriendDetails);
        }

        // POST: FriendCRUD/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Table collection)
        {
            try
            {
                // TODO: Add update logic here
                Table updatetable = dc.Tables.Single(x => x.FreindId == id.ToString());
                updatetable.FriendName = collection.FriendName;
                updatetable.Place = collection.Place;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendCRUD/Delete/5
        public ActionResult Delete(int id)
        {
            var getFriendDetails = dc.Tables.Single(x => x.FreindId == id.ToString());
            return View(getFriendDetails);
        }

        // POST: FriendCRUD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Table collection)
        {
            try
            {
                // TODO: Add delete logic here
                var frienddel = dc.Tables.Single(x => x.FreindId == id.ToString());
                dc.Tables.DeleteOnSubmit(frienddel);
                dc.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
