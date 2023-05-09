
// Back to top button
$(window).scroll(function () {
    if ($(this).scrollTop() > 100) {
        $('.back-to-top').fadeIn('block');
    } else {
        $('.back-to-top').fadeOut('none');
    }
});
$('.back-to-top').click(function () {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
    return false;
});


