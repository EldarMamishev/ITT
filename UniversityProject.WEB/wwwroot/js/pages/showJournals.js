var wnd, detailsTemplate, deleteTemplate;

$(document).ready(function () {
    let grid = $("#groupsGrid").kendoGrid({
        dataSource: {
            pageSize: 10,
            data: [
                {
                    "id": 1,
                    "subject": "Вища математика"
                },
                {
                    "id": 2,
                    "subject": "ООП"
                },
                {
                    "id": 3,
                    "subject": "КП"
                },
                {
                    "id": 4,
                    "subject": "АДіВМ"
                }
            ]
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
            { field: "subject", title: "Предмет", width: "80px" },
            {
                command: [
                    { text: "View Details", click: showDetails }
                ],
                title: "&nbsp;",
                width: "180px"
            }
        ],
        noRecords: true,
        messages: {
            noRecords: "Нема журналів"
        }
    }).data("kendoGrid");
});

function showDetails(e) {
    e.preventDefault();

    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    wnd.content(detailsTemplate(dataItem));
    wnd.center().open();
}

function openEditGroupItem(e) {
    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    window.location.href = "EditGroup?id=" + dataItem.id;
}

var itemToDelete;
var rowToDelete;
function onDeleteGroupItem(e) {
    itemToDelete = this.dataItem($(e.currentTarget).closest("tr"));
    rowToDelete = $(e.currentTarget).closest("tr");

    wnd.content(deleteTemplate(itemToDelete));
    wnd.center().open();
}