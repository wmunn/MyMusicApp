using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyMusicApp.Domain;
using MyMusicApp.DAO;

namespace MyMusicApp.Services
{
    public class ArtistService : IArtistService
    {
        public List<Artist> getArtists() {
            return (new List<Artist>(ArtistDao.Instance.select()));
        }
    }
}
