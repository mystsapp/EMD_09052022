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
                        //console.log(response.data);
                        var list = response.data.split('#');
                        var a = list[1];
                        $('#txtBatDau').val(a);
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

            var number1 = $('#txtNumber1').val();
            $.ajax({
                url: '/EMDs/DienGiaiBySGTCode',
                type: 'GET',
                data: {
                    sgtCode: codedoan,
                    number1: number1.trim()
                },
                success: function (response) {

                    console.log(response.data);
                    if (response.status) {
                        //console.log(response.data);

                        var data = response.data;
                        var stringName = data.tour + '\n' + data.cacVeTuCTHK + '\n' + data.slVeDaXuat + '\n' + data.soTienDaXuat + '\n' +
                            data.cacVeHoanBenCTHK + data.tongThanhToan + data.phiHoan + data.thucTra;

                        //var slv = data.slVeDaXuat.split(' ');

                        // $('#txtTienXuatVe').val(numeral(data.tienXuatVe).format('0,0'));
                        //$('#txtNguoiNhap').val(data.nguoiNhap);

                        //$('#txtSLVeDaXuat').val(parseInt(slv[5]));


                        $('#txtDienGiai').val(stringName);

                        if (data.number2 !== '') {
                            $('#txtSLVeHoan').val(data.slVeHoan);
                            $('#txtThucTra').val(data.thucTraNum);
                        }
                        else {
                            $('#txtSLVeHoan').val(0);
                            $('#txtThucTra').val(0);
                        }

                    }
                    else {
                        $('#txtDienGiai').val('');
                    }
                }
            });
        });

        $('#txtNgayDC').on('change', function () {
            var ngayDc = $(this).val();

            $.ajax({
                url: '/EMDs/GetNgayHetHan',
                type: 'GET',
                data: {
                    ngayDc: ngayDc
                },
                success: function (response) {

                    if (response.status) {
                        var data = response.data;
                        $('#txtHetHan').val(data);
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

        $(".datepicker").datepicker({
            dateFormat: 'dd/mm/yy'
        });
    }

};
createController.init();