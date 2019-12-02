$(document).ready(function () {
    $("#yearpicker").kendoDatePicker({
        start: "decade",
        depth: "decade",
        format: "yyyy"
    });

    $("#facultyBox").change(function () {
        getCathedras();
    });
});

function getCathedras() {
    let facultyId = $("#facultyBox").val();

    $("#cathedraBox").empty();
    //$(".stateSpinner").show();

    $.ajax({
        type: "GET",
        url: "/Admin/LoadCathedrasByFacultyId",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            facultyId: facultyId
        },
        success: function (response) {
            //$(".stateSpinner").hide();

            $.each(response, function (i, cathedra) {
                $("#cathedraBox").append('<option value="' + cathedra.id + '">' + cathedra.cathedraName + '</option>');
            });
        },
        error: function (response) { }
    });
}