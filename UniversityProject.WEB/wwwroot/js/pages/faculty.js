var wnd, detailsTemplate;

$(document).ready(function () {
    var grid = $("#grid").kendoGrid({
        dataSource: {
            pageSize: 10,
            data: faculties
        },
        sortable: {
            mode: "single",
            allowUnsort: false
        },
        pageable: true,
        height: 600,
        columns: [
            {
                field: "id", hidden: true, title: "Id", width: "50px", attributes: {
                    "class": "itemId"
                }
            },
            { field: "name", title: "Name", width: "50px" },
            { field: "cipher", title: "Cipher", width: "80px" },
            { field: "phoneNumber", title: "PhoneNumber", width: "140px" },
            {
                command: [
                    { text: "View Details", click: showDetails },
                    { text: "Edit", click: openEditFacultyItem },
                    { text: "Delete", click: onDeleteFacultyItem }
                ],
                title: "&nbsp;",
                width: "180px"
            }
        ]
    }).data("kendoGrid");

    wnd = $("#details")
        .kendoWindow({
            title: "Faculty Details",
            modal: true,
            visible: false,
            resizable: false,
            width: 300
        }).data("kendoWindow");

    detailsTemplate = kendo.template($("#template").html());
});

function showDetails(e) {
    e.preventDefault();

    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();
}

function openEditFacultyItem(e) {
    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    window.location.href = "EditFaculty?id=" + dataItem.id;
}

var itemToDelete;
var rowToDelete;
function onDeleteFacultyItem(e) {
    itemToDelete = this.dataItem($(e.currentTarget).closest("tr"));
    rowToDelete = $(e.currentTarget).closest("tr");
    
    $("#confirmDelete").modal();
}

function confirmDelete() {
    $.ajax({
        type: "GET",
        async: false,
        url: "/Admin/DeleteFaculty",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            "id": itemToDelete.id
        },
        success: function (data) {
            $("#grid").data("kendoGrid").removeRow(rowToDelete);
            closeModal();
        },
        error: function (data) {
            console.log(data.responseJSON.message);
        }
    });    
}

function closeModal() {
    $('#confirmDelete').modal('hide');
}