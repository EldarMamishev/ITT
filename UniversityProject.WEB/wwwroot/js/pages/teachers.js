﻿var wnd, detailsTemplate, deleteTemplate;

$(document).ready(function () {
    let grid = $("#teachersGrid").kendoGrid({
        dataSource: {
            pageSize: 10,
            data: teachers
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
                field: "userName", hidden: true, title: "UserName", width: "50px", attributes: {
                    "class": "itemUserName"
                }
            },
            { field: "fullName", title: "FullName", width: "80px" },
            { field: "subjectName", title: "Subject", width: "80px" },
            {
                command: [
                    { text: "View Details", click: showDetails },
                    { text: "Edit", click: openEditTeacherItem },
                    { text: "Delete", click: onDeleteTeacherItem }
                ],
                title: "&nbsp;",
                width: "180px"
            }
        ],
        noRecords: true,
        messages: {
            noRecords: "There are no teachers on current page"
        }
    }).data("kendoGrid");

    wnd = $("#teacherDetails").kendoWindow({
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

function openEditTeacherItem(e) {
    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    window.location.href = "EditTeacherAccount?userName=" + dataItem.userName;
}

var itemToDelete;
var rowToDelete;
function onDeleteTeacherItem(e) {
    itemToDelete = this.dataItem($(e.currentTarget).closest("tr"));
    rowToDelete = $(e.currentTarget).closest("tr");

    wnd.content(deleteTemplate(itemToDelete));
    wnd.center().open();
}

function confirmDelete(e) {
    $.ajax({
        type: "GET",
        url: "/Admin/DeleteTeacher",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            "userName": itemToDelete.itemUserName
        },
        success: function (data) {
            $("#teachersGrid").data("kendoGrid").removeRow(rowToDelete);
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