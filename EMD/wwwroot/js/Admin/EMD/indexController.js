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

        //$('.cursor-pointer .tdVal').click(function () {
        //    var id = $(this).data('id');
        //    var url = "/EMDs/DetailById";
        //    $.get(url, { id: id }, function (data) {
        //        console.log(data);
        //        $('#detialsById').html(data);
        //    });
        //});

        //$('.tdVal').click(function () {
        //    id = $(this).data('id');
        //    $('#hidId').val(id);
            
        //    var page = $('.active span').text();
        //    $('#hidPage').val(page);

        //    //$.ajax({
        //    //    url: '/CapThes/Index',
        //    //    data: {
        //    //        maCT: id
        //    //    },
        //    //    dataType: 'json',
        //    //    type: 'GET',
        //    //    success: function (response) {

        //    //    }
        //    //});

        //    $('#btnSubmit').click();
        //});
    }

};
indexController.init();