using System;
using System.Collections.Generic;
using MyMusicApp.Domain;

namespace MyMusicApp.Services
{
    public interface IArtistService
    {
        List<Artist> getArtists();
        Artist getArtist(int ArtistId);
    }
}
