$(document).ready(function () {
    $("#yearpicker").kendoDatePicker({
        format: "MM/dd/yyyy"
    });

    $("#yearpicker").attr("readonly", true);

    var datepicker = $("#yearpicker").data("kendoDatePicker");

    $("#yearpicker").click(function () {
        datepicker.open();
    });

    $("#facultyBox").change(function () {
        getCathedras();
    });
});