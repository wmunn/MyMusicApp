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
        //
        // GET: /Artists/
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

        [HttpPost]
        public ActionResult Edit(ArtistModel artist)
        {
            Artist selectedArtist = service.getArtist(artist.ArtistId);
            return PartialView(/*selectedArtist*/);
        }

        public ActionResult Delete(int id)
        {
            Artist selectedArtist = service.getArtist(id);
            ArtistModel deleteArtist = new ArtistModel{ ArtistId  = id, Name = selectedArtist.Name };
            return PartialView(deleteArtist);
        }

    }
}
