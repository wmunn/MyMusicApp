$(function () {

    $("#edit-artist-modal").dialog({
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
            $("#edit-artist-modal").load("Artist/Edit.cshtml");
        },
        close: function () {
            refreshArtists();
        }
    });

    function refreshArtists() {
        alert("Testing");
    }

    $("#open-edit-artist-modal").click(function () {
        $("#edit-artist-modal").dialog("open");
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