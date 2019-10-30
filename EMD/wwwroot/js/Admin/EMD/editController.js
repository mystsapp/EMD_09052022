var editController = {
    init: function () {
        editController.registerEvent();
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
    }
};
editController.init();