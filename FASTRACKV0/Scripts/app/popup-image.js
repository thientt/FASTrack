
jQuery(function () {
    ////----- OPEN
    $('.data-popup-open').on('click', function (e) {
        var url = $(this).attr('href');
        $.get(url, function (res) {
            $('#showImage').html(res);
            $('[data-popup="popupShowImage"]').fadeIn(1000);
        });
        e.preventDefault();
    });

    ////----- CLOSE
    $('[data-popup-close]').on('click', function (e) {
        var targeted_popup_class = jQuery(this).attr('data-popup-close');
        $('[data-popup="' + targeted_popup_class + '"]').fadeOut(1000);

        e.preventDefault();
    });
});