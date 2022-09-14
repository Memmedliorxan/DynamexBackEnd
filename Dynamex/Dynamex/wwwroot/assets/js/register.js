$(document).ready(function () {
    $('.natural').click(function(){
        $('.juridical').removeClass('selected');
        $(this).addClass('selected');
        $('.juridical-person').hide();
        $('.natural-person').fadeIn().show();
    });
    $('.juridical').click(function(){
        $('.natural').removeClass('selected');
        $(this).addClass('selected');
        $('.natural-person').hide();
        $('.juridical-person').fadeIn().show();
    });
}); 