var wnd, detailsTemplate, deleteTemplate, createTemplate, editTemplate;

$(document).ready(function () {
    $("#yearpicker").kendoDatePicker();

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
        height: 400,
        width: 600,
        filterable: {
            mode: "row"
        },
        toolbar: [
            {
                name: "create",
                template: '<a class="k-button" href="javascript:void(0)" onclick="onCreateSubjectItem();">Add subject</a>'
            }
        ],
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
                    { text: "Delete", click: onDeleteSubjectItem }
                ],
                title: "&nbsp;",
                width: "40px"
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

    deleteTemplate = kendo.template($("#deleteWindowTemplate").html());
    createTemplate = kendo.template($("#createWindowTemplate").html());
});

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
    let name = $("#createSubjectInput").val();
    let username = $("#username").val();

    $.ajax({
        type: "GET",
        url: "/Admin/AddSubjectToTeacher",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            "username": username,
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