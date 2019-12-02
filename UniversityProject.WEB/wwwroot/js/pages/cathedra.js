var wnd, detailsTemplate, deleteTemplate;

$(document).ready(function () {
    let grid = $("#cathedrasGrid").kendoGrid({
        dataSource: {
            pageSize: 10,
            data: cathedras
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
            { field: "name", title: "Назва", width: "150px" },
            { field: "cipher", title: "Шифр", width: "80px" },
            { field: "facultyName", title: "Назва факультету", width: "80px" },
            {
                command: [
                    { text: "View Details", click: showDetails },
                    { text: "Edit", click: openEditCathedraItem },
                    { text: "Delete", click: onDeleteCathedraItem }
                ],
                title: "&nbsp;",
                width: "180px"
            }
        ],
        noRecords: true,
        messages: {
            noRecords: "There are no cathedras on current page"
        }
    }).data("kendoGrid");

    wnd = $("#cathedraDetails")
        .kendoWindow({
            title: "Cathedra Details",
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

function openEditCathedraItem(e) {
    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    window.location.href = "EditCathedra?id=" + dataItem.id;
}

var itemToDelete;
var rowToDelete;
function onDeleteCathedraItem(e) {
    itemToDelete = this.dataItem($(e.currentTarget).closest("tr"));
    rowToDelete = $(e.currentTarget).closest("tr");

    wnd.content(deleteTemplate(itemToDelete));
    wnd.center().open();
}

function confirmDelete(e) {
    $.ajax({
        type: "GET",
        url: "/Admin/DeleteCathedra",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            "id": itemToDelete.id
        },
        success: function (data) {
            $("#cathedrasGrid").data("kendoGrid").removeRow(rowToDelete);
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