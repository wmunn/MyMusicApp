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
    public class KoArtistsController : Controller
    {
        private readonly IArtistService service;

        public KoArtistsController()
        {
            service = new ArtistService();
        }
        
        
        //
        // GET: /KoArtists/

        public ActionResult Index()
        {
            List<Artist> theList = service.getArtists();
            IEnumerable<ArtistModel> selectedModels = theList.Select(x => new ArtistModel { ArtistId = x.ArtistId, Name = x.Name });
            return View(selectedModels);
        }

    }
}
