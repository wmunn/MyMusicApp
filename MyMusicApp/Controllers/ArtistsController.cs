﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicApp.Services;
using MyMusicApp.Models;
using MyMusicApp.Domain;
using Trirand.Web.Mvc;

namespace MyMusicApp.Controllers
{
    public class ArtistsController : Controller
    {
        //
        // GET: /Artists/
        private readonly IArtistService service;

        public ArtistsController()
        {
            service = new ArtistService();
        }

        public ActionResult Index()
        {
            List<Artist> theList = service.getArtists();
            IEnumerable<ArtistModel> selectedModels = theList.Select(x => new ArtistModel { ArtistId = x.ArtistId, Name = x.Name });
            return View(selectedModels);
        }

        [HttpPost]
        public ActionResult Edit(ArtistModel artist)
        {
            Artist selectedArtist = service.getArtist(artist.ArtistId);
            return PartialView(/*selectedArtist*/);
        }

        public ActionResult Delete(int id)
        {
            Artist selectedArtist = service.getArtist(id);
            ArtistModel deleteArtist = new ArtistModel{ ArtistId  = id, Name = selectedArtist.Name };
            return PartialView(deleteArtist);
        }

        public ActionResult Testing()
        {            
            // Get the model (setup) of the grid defined in the /Models folder.
            var gridModel = new Grid();
            var artistsGrid = gridModel.ArtistsGrid;

            // customize the default Orders grid model with custom settings
            // NOTE: you need to call this method in the action that fetches the data as well,
            // so that the models match
            SetUpGrid(artistsGrid);

            // Pass the custmomized grid model to the View
            return View(gridModel);   
        }

        public JsonResult SearchGridDataRequested()
        {
            // Get both the grid Model and the data Model
            var gridModel = new Grid();

            // customize the default Artists grid model with our custom settings
            SetUpGrid(gridModel.ArtistsGrid);

            List<Artist> theList = service.getArtists();
            IEnumerable<ArtistModel> selectedModels = theList.Select(x => new ArtistModel { ArtistId = x.ArtistId, Name = x.Name });
            // return the result of the DataBind method, passing the datasource as a parameter
            // jqGrid for ASP.NET MVC automatically takes care of paging, sorting, filtering/searching, etc
            return gridModel.ArtistsGrid.DataBind(selectedModels.AsQueryable());
        }

        private void SetUpGrid(JQGrid artistsGrid)
        {
            // Customize/change some of the default settings for this model
            // ID is a mandatory field. Must by unique if you have several grids on one page.
            artistsGrid.ID = "ArtistsGrid";
            // Setting the DataUrl to an action (method) in the controller is required.
            // This action will return the data needed by the grid
            artistsGrid.DataUrl = Url.Action("SearchGridDataRequested");
            artistsGrid.EditUrl = Url.Action("EditRows");
            // show the search toolbar
            artistsGrid.ToolBarSettings.ShowSearchToolBar = true;
            artistsGrid.Columns.Find(c => c.DataField == "ArtistId").Searchable = false;

            //SetUpCustomerIDSearchDropDown(ordersGrid);
            //SetUpFreightSearchDropDown(ordersGrid);
            //SetShipNameSearchDropDown(ordersGrid);

            artistsGrid.ToolBarSettings.ShowEditButton = true;
            artistsGrid.ToolBarSettings.ShowAddButton = true;
            artistsGrid.ToolBarSettings.ShowDeleteButton = true;
            artistsGrid.EditDialogSettings.CloseAfterEditing = true;
            artistsGrid.AddDialogSettings.CloseAfterAdding = true;

            // setup the dropdown values for the CustomerID editing dropdown
            //SetUpCustomerIDEditDropDown(ordersGrid);
        }

    }
}
