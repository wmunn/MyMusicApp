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
        public List<Artist> getArtists() 
        {
            return (new List<Artist>(ArtistDao.Instance.select()));
        }

        public Artist getArtist(int id)
        {
            return (ArtistDao.Instance.select(id));
        }

        public void editArtist(Artist artist)
        {
            ArtistDao.Instance.update(artist);
        }

        public void addArtist(Artist artist)
        {
            ArtistDao.Instance.insert(artist);
        }

        public void deleteArtist(Artist artist)
        {
            ArtistDao.Instance.delete(artist);
        }

    }
}
