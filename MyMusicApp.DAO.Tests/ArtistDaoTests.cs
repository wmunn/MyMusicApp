using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMusicApp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace MyMusicApp.DAO.Tests
{
    [TestClass]
    public class ArtistDaoTests
    {
        List<Artist> mockDb;
        
        public ArtistDaoTests()
        {
            mockDb = new List<Artist>();
            mockDb.Add(new Artist( 1, "Fun."));
            mockDb.Add(new Artist( 2, "The Doors"));
        }

        //[TestMethod]
        //public void select_ReturnsAllArtistsInDb()
        //{
        //    //Arrange
        //    ArtistDao testDao = new ArtistDao(mockDb);

        //    //Act
        //    List<Artist> artists = testDao.select().ToList();

        //    //Assert
        //    CollectionAssert.AreEqual(artists, mockDb);
        //}

        [TestMethod]
        public void select_ReturnsArtistInDb()
        {
            //Arrange
            ArtistDao testDao = new ArtistDao(mockDb);
            Artist expectedArtist = new Artist(1, "Fun.");

            //Act
            Artist actualArtist = testDao.select(expectedArtist.ArtistId);

            //Assert
            Assert.AreEqual(expectedArtist.ArtistId, actualArtist.ArtistId);
            Assert.AreEqual(expectedArtist.Name, actualArtist.Name);
        }

        [TestMethod]
        public void insert_InsertsArtistInDb()
        {
            //Arrange
            ArtistDao testDao = new ArtistDao(mockDb);
            Artist newArtist = new Artist(3, "Prince");

            //Act
            testDao.insert(newArtist);

            //Assert
            IEnumerable<Artist> artists = testDao.select();
            Assert.IsTrue(artists.ToList().Contains(newArtist));
        }

        [TestMethod]
        public void delete_RemovesArtistFromDb()
        {
            //Arrange
            ArtistDao testDao = new ArtistDao(mockDb);
            Artist deleteArtist = new Artist(1, "Fun.");

            //Act
            testDao.delete(deleteArtist);

            //Assert
            IEnumerable<Artist> artists = testDao.select();
            Assert.IsTrue(!artists.ToList().Contains(deleteArtist));
        }

        [TestMethod]
        public void update_UpdatesArtistInDb()
        {
            //Arrange
            ArtistDao testDao = new ArtistDao(mockDb);
            Artist updateArtist = new Artist(1, "Not Fun.");

            //Act
            testDao.update(updateArtist);

            //Assert
            IEnumerable<Artist> artists = testDao.select();
            Assert.IsTrue(artists.ToList().Contains(updateArtist));
        }
    }
}