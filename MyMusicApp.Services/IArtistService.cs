using System;
using System.Collections.Generic;
using MyMusicApp.Domain;

namespace MyMusicApp.Services
{
    public interface IArtistService
    {
        List<Artist> getArtists();
        Artist getArtist(int ArtistId);
        void editArtist(Artist artist);
        void addArtist(Artist artist);
        void deleteArtist(Artist artist);
    }
}
