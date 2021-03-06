﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Domain
{
    public class Artist
    {

        public int ArtistId { get; set; }
        public string Name { get; set; }

        public Artist()
        {
        }

        public Artist(string Name)
        {
            this.Name = Name;
        }

        public Artist(int ArtistId, string Name)
        {
            this.ArtistId = ArtistId;
            this.Name = Name;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public bool Equals(Artist artist)
        {
            return ( ArtistId == artist.ArtistId && Name == artist.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ ArtistId;
        }
    }
}
