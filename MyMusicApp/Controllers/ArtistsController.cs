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
            try
            {
                service = new ArtistService();
            }
            catch (NullReferenceException e)
            {
                ShowErrorPage();
            }
            ShowErrorPage();
        }

        public ArtistsController(IArtistService artistService)
        {
            service = artistService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowErrorPage()
        {
            ViewBag.Message = "FEEEFEFEWFWFWEEFWEEFF";
            return View();
        }

        public JsonResult GetAllArtists()
        {
            List<Artist> theList = service.getArtists();
            theList = theList.OrderBy(m => m.Name).ToList();
            return Json(theList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAutocompleteArtists(string term)
        {
            List<string> artistsNames = new List<string>();
            var allArtists = service.getArtists();
            var filteredArtists = allArtists.Where( artist => artist.Name.Contains(term));
            foreach (Artist art in filteredArtists)
                artistsNames.Add(art.Name);

            return Json(artistsNames, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddArtist(Artist artist)
        {
            service.addArtist(artist);
            return Json(artist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditArtist(int id, Artist artist)
        {
           artist.ArtistId = id;
           service.editArtist(artist);
           List<Artist> theList = service.getArtists();
           theList = theList.OrderBy(m => m.Name).ToList();
           return Json(theList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteArtist(int id)
        {
            Artist artist = new Artist();
            artist = service.getArtist(id);
            //todo
            service.deleteArtist(artist);
            List<Artist> theList = service.getArtists();
            theList = theList.OrderBy(m => m.Name).ToList();
            return Json(theList, JsonRequestBehavior.AllowGet);
        }
    }
}
