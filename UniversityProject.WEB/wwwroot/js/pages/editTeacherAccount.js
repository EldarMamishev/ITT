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
                field: "id",
                hidden: true,
                title: "Id",
                width: "50px",
                attributes: {
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
                    {
                        template: '<a class="k-button k-button-icontext k-grid-Delete" onclick="onDeleteSubjectItem($(this));">Delete</a>',
                    }
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

    $("#facultyBox").change(function () {
        getChairs();
    });
});

var itemToDelete;
var rowToDelete;
function onDeleteSubjectItem(e) {

    let row = e.select().closest("tr");
    let grid = $('#subjectsGrid').data('kendoGrid');

    itemToDelete = grid.dataItem(row);
    rowToDelete = row;

    wnd.content(deleteTemplate(itemToDelete));
    wnd.center().open();
}

function onCreateSubjectItem() {
    $("#createTabError").text("");
    wnd.content(createTemplate);
    wnd.center().open();
}

function createSubject(e) {
    let subjectId = $("#newSubjectId").val();
    let username = $("#username").val();

    $.ajax({
        type: "POST",
        url: "/Admin/AddSubjectToTeacher",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            username: username,
            subjectId: subjectId
        }),
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
    let username = $("#username").val();

    $.ajax({
        type: "POST",
        url: "/Admin/DeleteSubjectFromTeacher",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({
            username: username,
            subjectId: itemToDelete.id
        }),
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

function getChairs() {
    let facultyId = $("#facultyBox").val();

    $("#chairBox").empty();
    //$(".stateSpinner").show();

    $.ajax({
        type: "GET",
        url: "/Admin/LoadChairsByFacultyId",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            facultyId: facultyId
        },
        success: function (response) {
            //$(".stateSpinner").hide();

            $.each(response, function (i, chair) {
                $("#chairBox").append('<option value="' + chair.id + '">' + chair.chairName + '</option>');
            });
        },
        error: function (response) { }
    });
}