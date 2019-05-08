$(document).ready(function () {
    $("#yearpicker").kendoDatePicker();
});

$(function () {    
    //$("#yearpicker").kendoDatePicker();
    //{
    //    start: "decade",
    //    depth: "decade",
    //    //format: "yyyy"
    //});

    if ($(window).width() <= 768) {
        $(".info, .overlay").height($(".content").innerHeight());
        $(".form").height($(".cont-form").innerHeight());
    } else {
        $(".info, .form").height("100vh");
    }

    $(window).resize(function () {
        if ($(window).width() <= 768) {
            $(".info, .overlay").height($(".content").innerHeight());
            $(".form").height($(".cont-form").innerHeight());
        } else {
            $(".info, .form").height($("100vh"));
        }
    });

});

