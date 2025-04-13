var table;

function DataTableGenerate() {
        
    if ($.fn.DataTable.isDataTable('#tblTurler')) {
        $('#tblTurler').DataTable().destroy();
    }

    table = $("#tblTurler").DataTable({
        "dom": "Bfrtip",
        "responsive": true,
        "lengthChange": true,
        "pageLength": 10,
        "autoWidth": false,
        ajax: { url: '/AdminPanel/Tur/List', type: 'post' },
        columns: [
            { data: 'id', visible: false },
            { data: 'turAdi' },
            { data: 'aktif' },
            { data: 'id' },
            { data: 'id' },
        

        ],
        columnDefs: [
            {
                targets: 2,
                render: function (data, type, row, meta) {
                    var turid = row["id"];
                    var aktifDurum = row["aktif"];

                    // Aktif durumuna göre checked özelliğini ayarla
                    var checkedAttr = aktifDurum ? "checked" : "";

                    return "<div class='d-flex justify-content-between'><div class='form-check form-switch ms-2'><input class='form-check-input' type='checkbox' " + checkedAttr + " turid='" + turid + "'/></div></div>";
                }
            },

            {
                targets: 3,
                render: function (data, type, row, meta) {

                    return "<a class='btn btn-info btnDuzenle' turid=" + data + ">   <i class='fas fa-pencil-alt'></i> DÜZENLE</a > ";

                }
            },

            {
                targets: 4,
                render: function (data, type, row, meta) {

                    return "<a class='btn btn-danger btnSil' turid=" + data + "><i class='fas fa-trash'></i> SİL</a > ";
                }
            },




        ],
        initComplete: function (settings, json) {

            //let table = new DataTable('#tblTurler');
           
        },

        drawCallback: function () {

            // Arama Yapıldığında, Sayfalama Yapıldığında, Sıralama Yapıldığında Draw yapılıyor
            

        }

    })

  
};

$(function () {
    DataTableGenerate();
});

$("#btnTurEkle").on("click", function () {
    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {

            Swal.showLoading();

        },
    });

    var formData = new FormData();

    var TurAdi = $("#TurAdi").val();

    formData.append("TurAdi", TurAdi)

    $.ajax({
        url: "/AdminPanel/Tur/Add",
        type: "post",
        dataType: "json",
        processData: false,
        contentType: false,
        data:formData,
        success: function (r) {

            $("#modalTurEkle").modal("hide");

            $("#tblTurler").DataTable().destroy();


            DataTableGenerate();


            swal.close();
            if (r.result) {
                Swal.fire({
                    title: "İŞLEM BAŞARILI",
                    text: r.mesaj,
                    icon: "success"
                });
            }

        },
        error: function () {

        }
    }
    );
});

$(function () {

    $(document).on('change', '.form-check-input', function () {
        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        var id = $(this).attr('turid');
        var aktifpasif = $(this).is(':checked');

        $.ajax({
            url: "/AdminPanel/Tur/AktifPasif",
            type: "post",
            dataType: "json",
            data: { id: id, aktif: aktifpasif },
            success: function (r) {
                swal.close();
                if (r.result) {
                    var durum = aktifpasif ? "Aktif" : "Pasif";
                    var mesajMetni = "Kayıt başarıyla " + durum + " durumuna getirildi.";

                    Swal.fire({
                        title: "İŞLEM BAŞARILI",
                        text: mesajMetni,
                        icon: "success"
                    });
                }
                else {
                    Swal.fire({
                        title: "HATA",
                        text: r.mesaj || "İşlem sırasında bir hata oluştu.",
                        icon: "error"
                    });
                }
            },
            error: function (r) {
                swal.close();
                Swal.fire({
                    title: "HATA",
                    text: "İşlem sırasında bir hata oluştu.",
                    icon: "error"
                });
            }
        });
    });

$(document).on('click', '.btnDuzenle', function () {

    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading();
        },
    });

    var id = $(this).attr('turid');
    $("#GId").val(id);

    $.ajax({
        url: "/AdminPanel/Tur/GetTur",
        type: "post",
        dataType: "json",
        data: { id: id },
        success: function (r) {

            if (r.result) {
                // Önce ID değerini set edelim
                $("#GId").val(id);

                // Tür adını form alanına yerleştirelim
                $("#GTurAdi").val(r.turAdi);

                // Yükleme animasyonunu kapatalım
                swal.close();

                // Güncelleme modalını açalım
                $("#modalTurGuncelle").modal('show');

               
            }
            swal.close();




            
        },
        error: function () {
        }
    });





});

    $(document).on('click', '#btnTurGuncelle', function () {

    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {

            Swal.showLoading();

        },
    });

    var formData = new FormData();

    var TurAdi = $("#GTurAdi").val();
    var Id = $("#GId").val();

    formData.append("TurAdi", TurAdi);
    formData.append("Id", Id);

    $.ajax({
        url: "/AdminPanel/Tur/Update",
        type: "post",
        dataType: "json",
        processData: false,
        contentType: false,
        data: formData,
        success: function (r) {
            $("#modalTurEkle").modal("hide");
            $("#tblTurler").DataTable().destroy();

            DataTableGenerate();

            swal.close();
            if (r.result) {
                Swal.fire({
                    title: "İŞLEM BAŞARILI",
                    text: r.mesaj,
                    icon: "success"
                });
            }

        },
        error: function () {
        }

    });
            

});

$(document).on('click', '.btnSil', function () {

    var id = $(this).attr("turid");

    Swal.fire({

        title: "SİLME İŞLEMİ",
        text: "Silmek İstediğinize Emin Misiniz?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Evet",
        cancelButtonText: "Hayır",
        confirmButtonColor: "#d33",
        cancelButtonColor: "#3085d6",
        reverseButtons: false

    }).then((result) => {
        if (result.isConfirmed) {
            var swal = Swal.fire({
                title: "LÜTFEN BEKLEYİNİZ...",
                html: "İşleminiz Yapılıyor",
                timerProgressBar: true,
                didOpen: () => {
                    Swal.showLoading();
                },
            });
            $.ajax({
                url: "/AdminPanel/Tur/Delete",
                type: "post",
                dataType: "json",
                data: { id: id },
                success: function (r) {
                    if (r.result) {
                        $("#tblTurler").DataTable().destroy();
                        DataTableGenerate();
                        swal.close();
                        Swal.fire({
                            title: "İŞLEM BAŞARILI",
                            text: r.mesaj,
                            icon: "success"
                        });
                    }
                },
                error: function () {
                }
            });
        }

    });



});

})
