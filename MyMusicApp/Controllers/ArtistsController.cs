using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using MyMusicApp.Services;

namespace MyMusicApp.Controllers
{
    public class ArtistsController : Controller
    {
        //
        // GET: /Artists/
        
        public ActionResult Index()
        {
            //return View(new ArtistService().getArtists());
            return View();
        }

    }
}
