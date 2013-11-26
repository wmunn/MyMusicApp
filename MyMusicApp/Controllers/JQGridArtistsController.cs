using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMusicApp.Models;
using MyMusicApp.Services;
using MyMusicApp.Domain;
using Trirand.Web.Mvc;

namespace MyMusicApp.Controllers
{
    public class JQGridArtistsController : Controller
    {
        private readonly IArtistService service;

        public JQGridArtistsController()
        {
            service = new ArtistService();
        }
        //
        // GET: /JQGridArtists/

        public ActionResult Index()
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
            artistsGrid.Columns.Find(c => c.DataField == "").Searchable = false;
            artistsGrid.Columns.Find(c => c.DataField == "").EditActionIconsColumn = true;
            artistsGrid.Columns.Find(c => c.DataField == "").HeaderText = "Actions";

            //SetUpCustomerIDSearchDropDown(ordersGrid);
            //SetUpFreightSearchDropDown(ordersGrid);
            SearchArtists(artistsGrid);

            artistsGrid.ToolBarSettings.ShowEditButton = true;
            artistsGrid.ToolBarSettings.ShowAddButton = true;
            artistsGrid.ToolBarSettings.ShowDeleteButton = true;
            artistsGrid.EditDialogSettings.CloseAfterEditing = true;
            artistsGrid.AddDialogSettings.CloseAfterAdding = true;

            // setup the dropdown values for the CustomerID editing dropdown
            //SetUpCustomerIDEditDropDown(ordersGrid);
        }

        public ActionResult EditRows(Artist editedArtist)
        {
            // Get the grid and database (northwind) models
            var gridModel = new Grid();

            // If we are in "Edit" mode
            if (gridModel.ArtistsGrid.AjaxCallBackMode == AjaxCallBackMode.EditRow)
            {
                // Get the data from and find the Artist corresponding to the edited row
                Artist artist = service.getArtist(editedArtist.ArtistId);

                // update the Artist information
                artist.Name = editedArtist.Name;

                service.editArtist(artist);
            }
            if (gridModel.ArtistsGrid.AjaxCallBackMode == AjaxCallBackMode.AddRow)
            {
                // since we are adding a new Order, create a new istance
                Artist artist = new Artist(editedArtist.Name);

                service.addArtist(artist);
            }
            if (gridModel.ArtistsGrid.AjaxCallBackMode == AjaxCallBackMode.DeleteRow)
            {
                service.deleteArtist(editedArtist);
            }

            return RedirectToAction("Index", "Artists");
        }

        private void SearchArtists(JQGrid artistsGrid)
        {
            JQGridColumn nameColumn = artistsGrid.Columns.Find(c => c.DataField == "Name");
            nameColumn.Searchable = true;
            nameColumn.DataType = typeof(string);
            nameColumn.SearchToolBarOperation = SearchOperation.Contains;
            nameColumn.SearchType = SearchType.TextBox;
        }


        public ActionResult GetArtist(int id)
        {
            Artist selectedArtist = service.getArtist(id);
            return Json(new ArtistModel
            {
                ArtistId = id,
                Name = selectedArtist.Name
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveArtist(ArtistModel data)
        {

            if (!ModelState.IsValid)
            {
                //data.ResponseAction.ValidationResults = ModelState.ToValidationResults();
                // data.ResponseAction.Message = "Please correct the errors.";
                return Json(data);
            }
            else
            {
                // service.editArtist(data.Model.ArtistModel);
                // Just a thought here... may not be best approach
                Artist selectedArtist = service.getArtist(data.ArtistId);
                return Json(new ArtistModel
                {
                    ArtistId = data.ArtistId,
                    Name = selectedArtist.Name
                }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
