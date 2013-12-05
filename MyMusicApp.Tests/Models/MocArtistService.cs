using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMusicApp.Models;
using MyMusicApp.Services;
using MyMusicApp.Domain;

namespace MyMusicApp.Tests.Models
{
    class MocArtistService : Services.IArtistService
    {
        private List<Artist> mocDb = new List<Artist>();

        public List<Artist> getArtists()
        {
            return mocDb;
        }
        
        public Artist getArtist(int ArtistId)
        {
            return mocDb.FirstOrDefault(artist => artist.ArtistId == ArtistId);   
        }

        public void editArtist(Artist artist)
        {
            foreach (Artist a in mocDb)
            {
                if (a.ArtistId == artist.ArtistId)
                {
                    mocDb.Remove(a);
                    mocDb.Add(artist);
                    break;
                }
            }
        }

        public void addArtist(Artist artist)
        {
            mocDb.Add(artist);
        }

        public void deleteArtist(Artist artist)
        {
            mocDb.Remove(artist);
        }
    }
}
