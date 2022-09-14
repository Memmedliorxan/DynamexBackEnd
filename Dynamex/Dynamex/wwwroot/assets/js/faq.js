$(document).ready(function(){
    $('.open').click(function(){
        $(this).css("display", "none");
        $(this).next().css("display", "block");
        $(this).parent().next().slideDown();
        
    });
    $('.close').click(function(){
        $(this).css("display", "none");
        $(this).prev().css("display", "block");
        $(this).parent().next().slideUp();
    });
});