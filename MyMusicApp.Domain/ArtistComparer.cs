using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Domain
{
    class ArtistComparer : IComparer<Artist>
    {
        public int Compare(Artist a, Artist b)
        {
            if (a.ArtistId == b.ArtistId && a.Name == b.Name)
                return 0;
            return 1;
        }
    }
}
