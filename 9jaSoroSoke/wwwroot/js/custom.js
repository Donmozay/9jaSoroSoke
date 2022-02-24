
  $(function () {

    // MENU
    $('.navbar-collapse a').on('click',function(){
      $(".navbar-collapse").collapse('hide');
    });

    // AOS ANIMATION
    AOS.init({
      disable: 'mobile',
      duration: 800,
      anchorPlacement: 'center-bottom'
    });


    // SMOOTHSCROLL NAVBAR
    $(function() {
      $('.navbar a, .hero-text a').on('click', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top - 49
        }, 1000);
        event.preventDefault();
      });
    });    
  });


    
$(document).ready(function () {
    $(".loader").show();
    $.ajax({
        "type": "Get",
        "url": "/home/CarOwnersReports",
        success: (function (resp) {
            $(".loader").hide();
            $("#list").html(resp);

        }),
        error: (function (ex) {
            $(".loader").hide();
            alert("An error has occured");
        })
    });

    $.ajax({
        "type": "Get",
        "url": "/home/CompanyOwnersReports",
        success: (function (resp) {
            $(".loader").hide();
            $("#list").html(resp);

        }),
        error: (function (ex) {
            $(".loader").hide();
            alert("An error has occured");
        })
    });
})


function searchFunction() {
    var value = $("#searchString").val().toLowerCase();
    $("#myTable tr").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
}
function addFunction() {
    $("#list").empty(); $(".loader").show();
    $.ajax({
        "type": "Get",
        "url": "/home/Addemployee",
        success: (function (resp) {
            $(".loader").hide();
            $("#list").html(resp);

        }),
        error: (function (ex) {
            $(".loader").hide();
            alert("An error has occured");
        })
    });
}

