using System;
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


        public Artist(string Name)
        {
            this.Name = Name;
        }
    }
}
