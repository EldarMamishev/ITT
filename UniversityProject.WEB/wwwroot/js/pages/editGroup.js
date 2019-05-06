$(document).ready(function () {
    $("#yearpicker").kendoDatePicker({
        start: "decade",
        depth: "decade",
        format: "yyyy"
    });

    $("#facultyBox").change(function () {
        getChairs();
    });
});

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