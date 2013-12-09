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
    class MockArtistService : Services.IArtistService
    {
        private List<Artist> mockDb = new List<Artist>();

        public List<Artist> getArtists()
        {
            return mockDb;
        }
        
        public Artist getArtist(int ArtistId)
        {
            return mockDb.FirstOrDefault(artist => artist.ArtistId == ArtistId);   
        }

        public void editArtist(Artist artist)
        {
            foreach (Artist a in mockDb)
            {
                if (a.ArtistId == artist.ArtistId)
                {
                    mockDb.Remove(a);
                    mockDb.Add(artist);
                    break;
                }
            }
        }

        public void addArtist(Artist artist)
        {
            mockDb.Add(artist);
        }

        public void deleteArtist(Artist artist)
        {
            mockDb.Remove(artist);
        }
    }
}
