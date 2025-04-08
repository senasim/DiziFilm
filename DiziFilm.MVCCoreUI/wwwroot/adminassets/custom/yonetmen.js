var table;
function DataTableGenerate() {

    table = $('#tblYonetmen').DataTable({
        "dom": "Bfrtip",
        "responsive": true,
        "lengthChange": true,
        "pageLength": 10,
        "autoWidth": false,
        ajax: { url: '/AdminPanel/Yonetmen/List', type: 'post' },
        columns: [
            { data: 'id', visible: false },
            { data: 'adi' },
            { data: 'soyadi' },
            { data: 'cinsiyet' },
            { data: 'dogumTarihi' },
            { data: 'miniBio' },
            { data: 'yonetmenTurAdi' },
            {
                data: 'id',
                render: function (data, type, row, meta) {
                    return "<a class='btn btn-info btnDuzenle' yonetmenid=" + data + ">   <i class='fas fa-pencil-alt'></i> DÜZENLE</a>";
                }
            },
            {
                data: 'id',
                render: function (data, type, row, meta) {
                    return "<a class='btn btn-danger btnSil' yonetmenid=" + data + "><i class='fas fa-trash'></i> SİL</a>";
                }
            }
        ],
        columnDefs: [
            {
                target: 3,
                render: function (data, type, row, meta) {
                    return data === true ? 'Kadın' : 'Erkek';
                }
            },
            {
                target: 4,
                render: function (data, type, row, meta) {
                    if (data) {
                        var date = new Date(data);
                        return date.toLocaleDateString('tr-TR');
                    }
                    return '';
                }
            },
            {
                target: 5,
                render: function (data, type, row, meta) {
                    if (data && data.length > 50) {
                        return data.substring(0, 50) + '... <button class="btn btn-sm btn-danger" onclick="showFullText(\'' + data + '\')">Devamı</button>';
                    }
                    return data || '';
                }
            }
        ]
    });
};


$(function () {
    DataTableGenerate();
});

$(document).on('click', '#btnYonetmenEkle', function () {
    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading();
        },
    });

    var formData = new FormData();
    var Id = $('#Id').val();
    var YonetmenAdi = $('#Adi').val();
    var YonetmenSoyadi = $('#Soyadi').val();
    var Cinsiyet = $('#Cinsiyet').val();
    var DogumTarihi = $('#DogumTarihi').val();
    var MiniBio = $('#MiniBio').val();
    var YonetmenTurId = $('#YonetmenTurId').val();
    

    formData.append("Id", Id);
    formData.append("Adi", YonetmenAdi);
    formData.append("Soyadi", YonetmenSoyadi);
    formData.append("Cinsiyet", Cinsiyet);
    formData.append("DogumTarihi", DogumTarihi);
    formData.append("MiniBio", MiniBio);
    formData.append("YonetmenTurId", YonetmenTurId);

    $.ajax({
        url: '/AdminPanel/Yonetmen/Add',
        type: 'post',
        dataType: 'json',
        data: formData,
        contentType: false,
        processData: false,
        success: function (response) {

            if (response.result) {
                Swal.fire({
                    title: 'Başarılı!',
                    text: response.mesaj || 'Yonetmen başarıyla eklendi.',
                    icon: 'success',
                    confirmButtonText: 'Tamam'
                });

                $('#modalYonetmenEkle').modal('hide');

                $('#Id, #Adi, #Soyadi, #DogumTarihi, #MiniBio').val('');

                $("#tblYonetmen").DataTable().destroy();
                DataTableGenerate();
            } else {
                Swal.fire({
                    title: 'Hata!',
                    text: response.mesaj || 'İşlem sırasında bir hata oluştu.',
                    icon: 'error',
                    confirmButtonText: 'Tamam'
                });
            }
        },
        error: function (err) {
            console.log(err);
            Swal.fire({
                title: 'Hata!',
                text: 'İşlem sırasında bir hata oluştu.',
                icon: 'error',
                confirmButtonText: 'Tamam'
            });
        }
    });
});

// Oyuncu düzenleme butonu
$(document).on('click', '.btnDuzenle', function () {
    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {

            Swal.showLoading();

        },
    });
    var id = $(this).attr('yonetmenid');
    $("#GId").val(id);

    $.ajax({
        url: '/AdminPanel/Yonetmen/GetYonetmen',
        type: 'post',
        dataType: 'json',
        data: { id: id },
        success: function (r) {
            if (r.result) {
                $("#GAdi").val(r.model.adi);
                $("#GSoyadi").val(r.model.soyadi);
                /*$("#GCinsiyet").val(r.model.cinsiyet);*/
                if (typeof r.model.cinsiyet == 'boolean') {
                    $("#GCinsiyet").val(r.model.cinsiyet ? '1' : '0');
                }
                else {
                    $("#GCinsiyet").val(r.model.cinsiyet);
                }
                /*  $("#GDogumTarihi").val(r.model.dogumTarihi);*/
                if (r.model.dogumTarihi) {
                    $("#GDogumTarihi").val(r.model.dogumTarihi);
                } else {
                    $("#GDogumTarihi").val('');
                }
                $("#GMiniBio").val(r.model.miniBio);
                $("#GYonetmenTurId").val(r.model.yonetmenTurId);

                $('#modalYonetmenGuncelle').modal('show');
                swal.close();
            }
        },
        error: function () {
           
        }

    });


});

// Yönetmen güncelleme butonu
$(document).on('click', '#btnYonetmenGuncelle', function () {

    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {

            Swal.showLoading();

        },
    });

    var formData = new FormData();
    var Id = $('#GId').val();
    var YonetmenAdi = $('#GAdi').val();
    var YonetmenSoyadi = $('#GSoyadi').val();
    var Cinsiyet = $('#GCinsiyet').val();
    var DogumTarihi = $('#GDogumTarihi').val();
    var MiniBio = $('#GMiniBio').val();
    var YonetmenTurId = $('#GYonetmenTurId').val();
    formData.append("Id", Id);
    formData.append("Adi", YonetmenAdi);
    formData.append("Soyadi", YonetmenSoyadi);
    formData.append("Cinsiyet", Cinsiyet);
    formData.append("DogumTarihi", DogumTarihi);
    formData.append("MiniBio", MiniBio);
    formData.append("YonetmenTurId", YonetmenTurId);

    $.ajax({
        url: '/AdminPanel/Yonetmen/Edit',
        type: "post",
        dataType: "json",
        data: formData,
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.success) {
                Swal.fire({
                    title: 'Başarılı!',
                    text: 'Yönetmen başarıyla güncellendi.',
                    icon: 'success',
                    confirmButtonText: 'Tamam'
                });
                $('#modalYonetmenGuncelle').modal('hide');
                $("#tblYonetmen").DataTable().destroy();
                DataTableGenerate();
            }
        },
        error: function (err) {
            console.log(err);
        }
    });



});

// Oyuncu silme butonu
$(document).on('click', '.btnSil', function () {


    var id = $(this).attr('yonetmenid');

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
                url: "/AdminPanel/Yonetmen/Delete",
                type: "post",
                dataType: "json",
                data: { id: id },
                success: function (r) {
                    if (r.result) {
                        $("#tblYonetmen").DataTable().destroy();
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