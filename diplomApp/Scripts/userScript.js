var mobMenuLg = document.querySelector('#mobMenuLg');
var mobMenuSm = document.querySelector('#mobMenuSm');

$(window).ready(function(){
    var targetWidth = 768;
     if ( $(window).width() < 991) {     
        mobMenuSm.innerHTML=mobMenuLg.innerHTML;
        mobMenuSm.getElementsByClassName("dropdown-menu")[0].classList.remove("dropdown-menu");

     }
    });

$(window).resize(function(){
    var targetWidth = 768;
     if ( $(window).width() < 991) {     
        mobMenuSm.innerHTML=mobMenuLg.innerHTML;
        mobMenuSm.getElementsByClassName("dropdown-menu")[0].classList.remove("dropdown-menu");
     }
    });

