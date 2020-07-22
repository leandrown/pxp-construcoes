// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function() {
   $('.clients-carousel').slick({
      slidesToShow: 6,
      slidesToScroll: 1,
      autoplay: true,
      autoplaySpeed: 1000,
      arrows: true,
      prevArrow: '<i class="fas fa-caret-square-left py-4"></i>',
      nextArrow: '<i class="fas fa-caret-square-right py-4"></i>',
      dots: false,
      pauseOnHover: true,
      responsive: [{
         breakpoint: 768,
         settings: {
            slidesToShow: 4,
            arrows: false
         }
      }, {
         breakpoint: 520,
         settings: {
            slidesToShow: 2,
            arrows: false
         }
      }]
   });
});
