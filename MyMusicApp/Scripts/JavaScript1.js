$(function () {

    $("#ArtistsEditDialog2").dialog({
        autoOpen: false,
        width: 400,
        height: 250,
        modal: true,
        buttons: {
            "Cancel": function () {
                $(this).dialog("close");
            },
            "Save": function () {
                $(this).dialog("close");
            }
        },
        open: function () {
            //var rowid = $(this).data("Name");
            alert(rowid);
            loadArtistDialog(rowid, $(this));
        },
        close: function () {
            refreshArtists();
        }
    });

    loadArtistDialog = function (grid, rowid, dialog) {

        alert("in loadArtistDialog");

        var xurl = dialog.attr("url");  // From <div> on Artists.cshtml
        var row = grid.getLocalRow(rowid);
        if (!row)
            row = grid.getRowData(rowid);

        $.ajax({
            url: xurl + "/" + row.ID,
            type: 'POST',
            data: null,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                ko.mapping.fromJS(data, {}, viewModel.ArtistModel);
            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    };

    saveArtist = function (dialog) {
        var valid = true;

        if (valid) {
            var url = dialog.attr("data-editUrl");

            dataModel = { data: { Model: ko.mapping.toJS(model)} };
            $.ajax({
                url: url,
                type: 'POST',
                data: ko.mapping.toJSON(dataModel),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    // Would be nice to pop up a successful message of some sort here
                    dialog.dialog("close");
                },
                error: function (error) {
                    alert(error.responseText);
                }
            });
        }
    };



    function refreshArtists() {
        alert("Testing");
    }

    $("#openEditArtistModal2").click(function () {
        $("#ArtistsEditDialog2").dialog("open");
    });

    $("#delete-artist-modal").dialog({
        autoOpen: false,
        width: 400,
        height: 250,
        modal: true,
        buttons: {
            "Cancel": function () {
                $(this).dialog("close");
            },
            "Continue": function () {
                $(this).dialog("close");
            }
        }
    });

    $("#open-delete-artist-modal").click(function () {
        $("#delete-artist-modal").dialog("open");
    });

    $("#create-artist-modal").dialog({
        autoOpen: false,
        width: 400,
        height: 250,
        modal: true,
        buttons: {
            "Cancel": function () {
                $(this).dialog("close");
            },
            "Save": function () {
                $(this).dialog("close");
            }
        }

    });

    $("#open-create-artist-modal").click(function () {
        $("#create-artist-modal").dialog("open");
    });
});