using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyMusicApp.Domain;

namespace MyMusicApp.DAO
{
    public sealed class ArtistDao
    {
        private static readonly ArtistDao dao = new ArtistDao();
        private static List<Artist> mockDataModel;
 
        static ArtistDao() {
            mockDataModel = new List<Artist>();
 
            mockDataModel.Add(new Artist( 1, "Morrissey"));
            mockDataModel.Add(new Artist( 2, "The Smiths"));
            mockDataModel.Add(new Artist( 3, "Depeche Mode"));
            mockDataModel.Add(new Artist( 4, "Thirty Seconds to Mars"));
            mockDataModel.Add(new Artist( 5, "VNV Nation"));
        }
 
        private ArtistDao() { }
 
        public static ArtistDao Instance {
            get { return dao; }
        }
 
        public ICollection<Artist> select() {
            return mockDataModel;
        }
 
        public Artist select(int id) {
            Artist returnValue = null;
 
            for (int i = 0; i < mockDataModel.Count; i++) {
                if (mockDataModel[i].ArtistId == id) {
                    returnValue = mockDataModel[i];
                    break;
                }
            }
 
            return returnValue;
        }
 
        public void insert(Artist artist) {
            int newId = getNextId();
            artist.ArtistId = newId;
            mockDataModel.Add(artist);
        }
 
        public void update(Artist artist) {
            for (int i = 0; i < mockDataModel.Count; i++) {
                if (mockDataModel[i].ArtistId == artist.ArtistId)
                {
                    mockDataModel[i] = artist;
                    break;
                }
            }
        }
 
        public void delete(Artist artist) {
            for (int i = 0; i < mockDataModel.Count; i++) {
                if (mockDataModel[i].ArtistId == artist.ArtistId)
                {
                    mockDataModel.RemoveAt(i);
                    break;
                }
            }
        }
       
        private int getNextId() {
            int returnValue = 0;
 
            if (mockDataModel.Count > 0) {
                for (int i = 0; i < mockDataModel.Count; i++) {
                    if (mockDataModel[i].ArtistId > returnValue)
                    {
                        returnValue = mockDataModel[i].ArtistId;
                    }
                }
            }
            return returnValue + 1;
        }
    }
}