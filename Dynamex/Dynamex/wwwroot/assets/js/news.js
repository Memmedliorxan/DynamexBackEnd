$(document).ready(function () {
    $('.chev, .main').click(function(){
        $('.chev').toggleClass('chev-active');
        $('.options').toggleClass('show-options');
    });
    
    $("#op-news").click(function(){
        selectOption(this);
    });

    $("#op-bulletin").click(function(){
        selectOption(this);
    });

    $("#op-blogs").click(function(){
        selectOption(this);
    });
    
    function selectOption(option){
        $('.chev').toggleClass('chev-active');
        $('.options').toggleClass('show-options');
        $(option).toggleClass("op-selected");
        $(option).siblings().removeClass("op-selected");
        $(option).parent().siblings('.main').text(option.text);
    }
    
    // chnage pages with numbers
    $('.page').click(function(){
        $(this).siblings().children().removeClass('active-page');
        $(this).children('.go-page').addClass('active-page');
        isLastPage('.next');
        isFirstPage('.prev');
    });

    // change pages with arrows
    $('.next').click(function(){
        const activePage = parseInt($('.active-page').text());
        const totalPages = $('.pagination').children().length;
        if(activePage < totalPages){
            $('.active-page').removeClass('active-page');
            $('.page').eq(activePage-1).next().children('.go-page').addClass('active-page');
            isLastPage('.next');
            isFirstPage('.prev');
        }
        
    });

    // change pages with arrows
    $('.prev').click(function(){
        const activePage = parseInt($('.active-page').text());
        const totalPages = $('.pagination').children().length;
        if(activePage > 1){
            $('.active-page').removeClass('active-page');
            $('.page').eq(activePage-2).children('.go-page').addClass('active-page');
            isLastPage('.next');
            isFirstPage('.prev');
        }
    });

    function isLastPage(option){
        const activePage = parseInt($('.active-page').text());
        const lastPage = $('.pagination').children().length;
        if(activePage == lastPage) $(option).addClass('disabled');
        else $(option).removeClass('disabled');
    }

    function isFirstPage(option){
        const activePage = parseInt($('.active-page').text());
        if(activePage == 1) $(option).addClass('disabled');
        else $(option).removeClass('disabled');
    }

});