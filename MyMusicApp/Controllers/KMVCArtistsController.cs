using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicApp.Services;
using MyMusicApp.Domain;
using Trirand.Web.Mvc;

namespace MyMusicApp.Controllers
{
    public class KMVCArtistsController : Controller
    {
        private readonly IArtistService service;

        public KMVCArtistsController()
        {
            service = new ArtistService();
        }        //
        // GET: /KMVCArtists/

        public ActionResult Index()
        {
            var model = service.getArtists();
            return View(model);
        }

    }
}
