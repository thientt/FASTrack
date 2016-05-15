$(function () {
    var pop = function () {
        $('#screen').css({ opacity: 0.2, 'width': $(document).width(), 'height': $(document).height() });
        $('body').css({ 'overflow': 'hidden' });
        $('#box').css({ 'display': 'block' });
    }
    $('input[type=submit]').click(pop);
});