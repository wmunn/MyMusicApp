using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMusicApp.Controllers;
using System.Web.Mvc;
using MyMusicApp.Models;
using MyMusicApp.Tests.Models;
using MyMusicApp.Domain;
using System.Web.Script.Serialization;

namespace MyMusicApp.Tests.Controllers
{
    /// <summary>
    /// Summary description for ArtistsControllerTest
    /// </summary>
    [TestClass]
    public class ArtistsControllerTest
    {
        public ArtistsControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        Artist GetArtist()
        {
            return GetArtist(1, "Fun.");
        }

        Artist GetArtist(int id, string name)
        {
            return new Artist
            {
                ArtistId = id,
                Name = name
            };
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            ArtistsController controller = new ArtistsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddArtist_PutsValidArtistIntoDb()
        {
            // Arrange
            MockArtistService mockService = new MockArtistService();
            ArtistsController controller = new ArtistsController(mockService);
            Artist artist = GetArtist();

            // Act
            controller.AddArtist(artist);

            // Assert
            List<Artist> artists = mockService.getArtists();
            Assert.IsTrue(artists.Contains(artist));
        }

        [TestMethod]
        public void DeleteArtist_RemovesValidArtistFromDb()
        {
            // Arrange
            MockArtistService mockService = new MockArtistService();
            ArtistsController controller = new ArtistsController(mockService);
            Artist artist = GetArtist();
            mockService.addArtist(artist);

            // Act
            controller.DeleteArtist(artist.ArtistId);

            // Assert
            List<Artist> artists = mockService.getArtists();
            Assert.IsTrue(!artists.Contains(artist));
        }

        [TestMethod]
        public void EditArtist_UpdatesValidArtistInDb()
        {
            // Arrange
            MockArtistService mockService = new MockArtistService();
            ArtistsController controller = new ArtistsController(mockService);
            Artist originalArtist = GetArtist();
            mockService.addArtist(originalArtist);
            Artist editedArtist = GetArtist();
            editedArtist.Name = "NewName";

            // Act
            controller.EditArtist(originalArtist.ArtistId, editedArtist);

            // Assert
            List<Artist> artists = mockService.getArtists();
            Assert.IsTrue(!artists.Contains(originalArtist));
            Assert.IsTrue(artists.Contains(editedArtist));
        
        }

        //[TestMethod]
        //public void GetAllArtists_ReturnsAllArtistsInDb()
        //{
        //    // Arrange
        //    MocArtistService mockService = new MocArtistService();
        //    ArtistsController controller = new ArtistsController(mockService);
        //    List<Artist> localList = new List<Artist>();
        //    Artist artist = GetArtist();
        //    Artist artist2 = GetArtist(2, "Two");
        //    Artist artist3 = GetArtist(3, "Three");
        //    mockService.addArtist(artist);
        //    mockService.addArtist(artist2);
        //    mockService.addArtist(artist3);
        //    localList.Add(artist);
        //    localList.Add(artist2);
        //    localList.Add(artist3);           
           
        //    // Act
        //    var list = new JavaScriptSerializer().Deserialize<List<Artist>>(controller.GetAllArtists()); 
        //    List<Artist> serviceList = 
             

        //    // Assert
        //    List<Artist> artists = mockService.getArtists();
        //    Assert.IsTrue(!artists.Contains(originalArtist));
        //    Assert.IsTrue(artists.Contains(editedArtist));
        //}
    }
}
