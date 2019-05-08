var wnd, detailsTemplate, deleteTemplate;

$(document).ready(function () {
    let grid = $("#chairsGrid").kendoGrid({
        dataSource: {
            pageSize: 10,
            data: chairs
        },
        sortable: {
            mode: "single",
            allowUnsort: false
        },
        pageable: true,
        height: 600,
        filterable: {
            mode: "row"
        },
        columns: [
            {
                field: "id", hidden: true, title: "Id", width: "50px", attributes: {
                    "class": "itemId"
                }
            },
            { field: "name", title: "Name", width: "150px" },
            { field: "cipher", title: "Cipher", width: "80px" },
            { field: "facultyName", title: "Faculty Name", width: "80px" },
            {
                command: [
                    { text: "View Details", click: showDetails },
                    { text: "Edit", click: openEditChairItem },
                    { text: "Delete", click: onDeleteChairItem }
                ],
                title: "&nbsp;",
                width: "180px"
            }
        ],
        noRecords: true,
        messages: {
            noRecords: "There are no chairs on current page"
        }
    }).data("kendoGrid");

    wnd = $("#chairDetails")
        .kendoWindow({
            title: "Chair Details",
            modal: true,
            visible: false,
            resizable: false,
            width: 300
        }).data("kendoWindow");

    detailsTemplate = kendo.template($("#detailWindowTemplate").html());
    deleteTemplate = kendo.template($("#deleteWindowTemplate").html());
});

function showDetails(e) {
    e.preventDefault();

    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();
}

function openEditChairItem(e) {
    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    window.location.href = "EditChair?id=" + dataItem.id;
}

var itemToDelete;
var rowToDelete;
function onDeleteChairItem(e) {
    itemToDelete = this.dataItem($(e.currentTarget).closest("tr"));
    rowToDelete = $(e.currentTarget).closest("tr");

    wnd.content(deleteTemplate(itemToDelete));
    wnd.center().open();
}

function confirmDelete(e) {
    $.ajax({
        type: "GET",
        url: "/Admin/DeleteChair",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            "id": itemToDelete.id
        },
        success: function (data) {
            $("#chairsGrid").data("kendoGrid").removeRow(rowToDelete);
            closeModal(e);
        },
        error: function (data) {
            console.log(data.responseJSON.message);
        }
    });
}

function closeModal(e) {
    $(e).closest("[data-role=window]").data("kendoWindow").close();
}