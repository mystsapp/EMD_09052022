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

        $('.cursor-pointer .tdVal').click(function () {
            var id = $(this).data('id');
            var url = "/EMDs/DetailById";
            $.get(url, { id: id }, function (data) {
                console.log(data);
                $('#detialsById').html(data);
            });
        });
    }

};
indexController.init();