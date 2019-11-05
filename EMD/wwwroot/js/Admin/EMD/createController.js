function addCommas(x) {
    var parts = x.toString().split(".");
    parts[0] = parts[0].replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    return parts.join(".");
}

var createController = {
    init: function () {
        createController.registerEvent();
    },
    registerEvent: function () {
        $('#txtSgtCode').on('change', function () {
            codedoan = $(this).val().toUpperCase();
            $.ajax({
                url: '/EMDs/GetBySGTCode',
                type: 'GET',
                data: {
                    sgtCode: codedoan
                },
                success: function (response) {


                    if (response.status) {
                        console.log(response.data);
                        var list = response.data.split('#');
                        $('#txtBatDau').val(list[1]);
                        $('#txtKetThuc').val(list[2]);
                        //$('#tuyentq').val(list[3]);
                        //$('#nuocden').val(list[4]);
                        $('#txtSLVeDatCoc').val(list[5]);
                    }
                    else {
                        $('#txtBatDau').val('');
                        $('#txtKetThuc').val('');
                        //$('#tuyentq').val('');
                        //$('#nuocden').val('');
                        $('#txtSLVeDatCoc').val('');
                    }
                }
            });
        });

        $('input.numbers').keyup(function (event) {

            // Chỉ cho nhập số
            if (event.which >= 37 && event.which <= 40) return;

            $(this).val(function (index, value) {
                return addCommas(value);
            });
        });
    }

};
createController.init();