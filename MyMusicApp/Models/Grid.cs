using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trirand.Web.Mvc;
using System.Web.UI.WebControls;

namespace MyMusicApp.Models
{
    public class Grid
    {
        public Grid()
        {
            ArtistsGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                {
                    new JQGridColumn { DataField = "ArtistId", 
                                    // always set PrimaryKey for Add,Edit,Delete operations
                                    // if not set, the first column will be assumed as primary key
                                    PrimaryKey = true,
                                    Editable = false,
                                    Visible = false,
                                    Width = 0 },
                    new JQGridColumn { DataField = "Name", 
                                    Editable = true,
                                    Width = 400 },
                    new JQGridColumn { Sortable = false, 
                                    Editable = false,
                                    Fixed =true,
                                    Width = 150 }
                },
                Width = Unit.Pixel(400)
            };

            ArtistsGrid.ToolBarSettings.ShowRefreshButton = true;
        }

        public JQGrid ArtistsGrid { get; set; }
    }
}