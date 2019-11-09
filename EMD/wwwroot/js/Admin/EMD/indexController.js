var indexController = {
    init: function () {
        indexController.registerEvent();
    },
    registerEvent: function () {
        
        $('.tblEMD .cursor-pointer').off('click').on('click', function () {
            if ($(this).hasClass("hoverClass"))
                $(this).removeClass("hoverClass");
            else {
                $('tr.hoverClass').removeClass("hoverClass");
                $(this).addClass("hoverClass");
            }

        });
    }

};
indexController.init();