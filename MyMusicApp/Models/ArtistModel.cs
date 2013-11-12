using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMusicApp.Models
{
    public class ArtistModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public ArtistModel()
        {
        }

        public ArtistModel(int ArtistId, string Name)
        {
            this.ArtistId = ArtistId;
            this.Name = Name;    
        }
    }
}