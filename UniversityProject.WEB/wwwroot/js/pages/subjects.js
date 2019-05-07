var wnd, detailsTemplate, deleteTemplate, createTemplate, editTemplate;

$(document).ready(function () {
    let grid = $("#subjectsGrid").kendoGrid({
        dataSource: {
            pageSize: 10,
            data: subjects
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
            {
                field: "name", title: "Name", width: "200px", attributes: {
                    "class": "itemName"
                }
            },
            {
                command: [
                    { text: "View Details", click: showDetails },
                    { text: "Edit", click: onEditSubjectItem },
                    { text: "Delete", click: onDeleteSubjectItem }
                ],
                title: "&nbsp;",
                width: "180px"
            }
        ],
        noRecords: true,
        messages: {
            noRecords: "There are no subjects on current page"
        }
    }).data("kendoGrid");

    wnd = $("#subjectDetails").kendoWindow({
        title: "Subject Details",
        modal: true,
        visible: false,
        resizable: false,
        width: 300
    }).data("kendoWindow");

    detailsTemplate = kendo.template($("#detailWindowTemplate").html());
    deleteTemplate = kendo.template($("#deleteWindowTemplate").html());
    createTemplate = kendo.template($("#createWindowTemplate").html());
    editTemplate = kendo.template($("#editWindowTemplate").html());
});

function showDetails(e) {
    e.preventDefault();

    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();
}

function openEditSubjectItem(e) {
    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    window.location.href = "EditSubject?id=" + dataItem.id;
}

var itemToDelete;
var rowToDelete;
function onDeleteSubjectItem(e) {
    itemToDelete = this.dataItem($(e.currentTarget).closest("tr"));
    rowToDelete = $(e.currentTarget).closest("tr");

    wnd.content(deleteTemplate(itemToDelete));
    wnd.center().open();
}

function onCreateSubjectItem() {
    $("#createTabError").text("");
    wnd.content(createTemplate);
    wnd.center().open();
}

function createSubject(e) {
    var name = $("#createSubjectInput").val();

    $.ajax({
        type: "GET",
        url: "/Admin/CreateSubject",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            "subjectName": name
        },
        success: function (data) {
            $("#createTabError").text("");
            let grid = $("#subjectsGrid").data("kendoGrid");
            grid.dataSource.add({ id: data.id, name: data.name });

            closeModal(e);
        },
        error: function (data) {
            $("#createTabError").text(data.responseText);
        }
    });
}

var editItem;
function onEditSubjectItem(e) {
    $("#editTabError").text("");
    editItem = this.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(editTemplate(editItem));
    wnd.center().open();
}

function editSubject(e) {
    let id = $("#editSubjectIdInput").val();
    let subjectName = $("#editSubjectNameInput").val();

    $.ajax({
        type: "POST",
        url: "/Admin/EditSubject",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            id: id,
            subjectName: subjectName
        }),
        success: function (data) {
            $("#editTabError").text("");
            let grid = $("#subjectsGrid").getKendoGrid();
            let dataSource = grid.dataSource;
            let dataItem = dataSource.get(editItem.id);
            dataItem.name = data.name;
            dataItem.set("Name", data.name);

            closeModal(e);
        },
        error: function (data) {
            $("#editTabError").text(data.responseText);
        }
    });
}

function confirmDelete(e) {
    $.ajax({
        type: "GET",
        url: "/Admin/DeleteSubject",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            "id": itemToDelete.id
        },
        success: function (data) {
            $("#subjectsGrid").data("kendoGrid").removeRow(rowToDelete);
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