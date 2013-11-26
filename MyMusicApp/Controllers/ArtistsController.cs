using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicApp.Services;
using MyMusicApp.Models;
using MyMusicApp.Domain;

namespace MyMusicApp.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IArtistService service;

        public ArtistsController()
        {
            service = new ArtistService();
        }

        public ActionResult Index()
        {
            List<Artist> theList = service.getArtists();
            IEnumerable<ArtistModel> selectedModels = theList.Select(x => new ArtistModel { ArtistId = x.ArtistId, Name = x.Name });
            return View(selectedModels);
        }
        
        public JsonResult GetAllArtists()
        {
            return Json(service.getArtists(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddArtist(Artist artist)
        {
            System.Diagnostics.Debug.WriteLine("This is " + artist.Name);
            service.addArtist(artist);
            return Json(artist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditArtist(int id, Artist artist)
        {
           artist.ArtistId = id;
           service.editArtist(artist);
           return Json(service.getArtists(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteArtist(int id)
        {
            Artist artist = new Artist();
            artist.ArtistId = id;
            service.deleteArtist(artist);
            return Json(service.getArtists(), JsonRequestBehavior.AllowGet);
        }
    }
}
