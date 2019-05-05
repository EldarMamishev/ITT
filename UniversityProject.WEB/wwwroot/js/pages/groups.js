var wnd, detailsTemplate, deleteTemplate;

$(document).ready(function () {
    let grid = $("#groupsGrid").kendoGrid({
        dataSource: {
            pageSize: 10,
            data: groups
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
            { field: "cipher", title: "Cipher", width: "100px" },
            { field: "facultyName", title: "Faculty", width: "80px" },
            { field: "chairName", title: "Chair", width: "80px" },
            { field: "countOfStudents", title: "Students Count", width: "80px" },
            {
                command: [
                    { text: "View Details", click: showDetails },
                    { text: "Edit", click: openEditFacultyItem },
                    { text: "Delete", click: onDeleteFacultyItem }
                ],
                title: "&nbsp;",
                width: "180px"
            }
        ],
        noRecords: true,
        messages: {
            noRecords: "There are no groups on current page"
        }
    }).data("kendoGrid");

    wnd = $("#groupDetails").kendoWindow({
            title: "Group Details",
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

function openEditFacultyItem(e) {
    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    window.location.href = "EditGroup?id=" + dataItem.id;
}

var itemToDelete;
var rowToDelete;
function onDeleteFacultyItem(e) {
    itemToDelete = this.dataItem($(e.currentTarget).closest("tr"));
    rowToDelete = $(e.currentTarget).closest("tr");

    wnd.content(deleteTemplate(itemToDelete));
    wnd.center().open();
}

function confirmDelete(e) {
    $.ajax({
        type: "GET",
        url: "/Admin/DeleteGroup",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            "id": itemToDelete.id
        },
        success: function (data) {
            $("#groupsGrid").data("kendoGrid").removeRow(rowToDelete);
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