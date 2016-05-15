//function displayProgressMessage(ctl, msg) {
//    $(".submit-progress").removeClass("hidden");
//    $("body").addClass("submit-progress-bg");

//    //$(ctl).attr("disabled", true);//.text(msg);
//    return true;
//};

function waitingDialog() {
    $('#pnWaitingProcess').dialog({
        autoOpen: false,
        dialogClass: "loadingScreenWindow",
        closeOnEscape: false,
        draggable: false,
        width: 200,
        height: 250,
        minHeight: 30,
        modal: true,
        buttons: {},
        resizable: false,
        open: function () {
            // scrollbar fix for IE
            $('body').css('overflow', 'hidden');
        },
        close: function () {
            // reset overflow
            $('body').css('overflow', 'auto');
        }
    });

    $("#pnWaitingProcess").dialog('open');
};
