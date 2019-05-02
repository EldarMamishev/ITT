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
                    { name: "edit", text: "Edit", click: openEditFacultyItem },
                    { name: "destroy", text: "Delete" }
                ],
                title: "&nbsp;",
                width: "180px"
            }
            //{ command: ["View Details", "Edit", "destroy"], title: "&nbsp;", width: "180px" }
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