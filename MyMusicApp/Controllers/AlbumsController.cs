using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicApp.Models;

namespace MyMusicApp.Controllers
{
    public class AlbumsController : Controller
    {
        //
        // GET: /Albums/
        public ActionResult KoSample()
        {
            return View();
        }
        public ActionResult Yo()
        {
            return View();
        }

        public ActionResult Index()
        {

            var initialData = new GiftListModel
            {
                Gifts = new List<GiftModel>
                {
                    new GiftModel {Title = "Tall Hat", Price = 49.95},
                    new GiftModel {Title = "Long Cloak", Price = 78.25}
                }
            };
            return View(initialData);
        }

        public ActionResult AddGift(GiftListModel model)
        {
            model.AddGift();
            return Json(model);
        }

        public ActionResult RemoveGift(GiftListModel model, int index)
        {
            model.RemoveGift(index);
            return Json(model);
        }

        public ActionResult Save(GiftListModel model)
        {
            model.Save();
            return Json(model);
        }
    }
}
