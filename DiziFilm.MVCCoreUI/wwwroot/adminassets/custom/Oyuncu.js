$(document).ready(function () {
    var table;
    function DataTableGenerate() {
        table = $('#tblOyuncu').DataTable({
            "dom": "Bfrtip",
            "responsive": true,
            "lengthChange": true,
            "pageLength": 10,
            "autoWidth": false,
            "language": {
                "url": "//cdn.datatables.net/plug-ins/1.10.21/i18n/Turkish.json"
            },
            ajax: {
                url: '/AdminPanel/Oyuncu/List',
                type: 'post'
            },
            columns: [
                { data: 'id', visible: false },
                { 
                    data: 'adi',
                    render: function(data) {
                        return data || '-';
                    }
                },
                { 
                    data: 'soyadi',
                    render: function(data) {
                        return data || '-';
                    }
                },
                { 
                    data: 'cinsiyet',
                    render: function(data) {
                        if (data === null || data === undefined) return '-';
                        return data === true ? 'Kadın' : 'Erkek';
                    }
                },
                { 
                    data: 'dogumTarihi',
                    render: function(data) {
                        if (!data) return '-';
                        try {
                            var date = new Date(data);
                            return date.toLocaleDateString('tr-TR');
                        } catch {
                            return '-';
                        }
                    }
                },
                { 
                    data: 'dogumYeri',
                    render: function(data) {
                        return data || '-';
                    }
                },
                { 
                    data: 'biyografi',
                    render: function(data) {
                        return data || '-';
                    }
                },
                {
                    data: 'aktif',
                    render: function (data, type, row) {
                        var oyuncuid = row["id"];
                        var aktifDurum = row["aktif"];
                        var checkedAttr = aktifDurum ? "checked" : "";
                        return "<div class='d-flex justify-content-between'><div class='form-check form-switch ms-2'><input class='form-check-input' type='checkbox' " + checkedAttr + " oyuncuid='" + oyuncuid + "'/></div></div>";
                    }
                },
                {
                    data: 'id',
                    render: function (data) {
                        return "<div class='d-flex gap-2'>" +
                               "<button class='btn btn-info btn-sm btnDuzenle' oyuncuid='" + data + "'><i class='fas fa-pencil-alt'></i></button>" +
                               "<button class='btn btn-danger btn-sm btnSil' oyuncuid='" + data + "'><i class='fas fa-trash'></i></button>" +
                               "</div>";
                    }
                }
            ]
        });
    };

    $(function () {
        DataTableGenerate();
    });


    //OYUNCU EKLEME

    $('#btnOyuncuEkle').on('click', function () {
        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        var formData = new FormData();

        var OyuncuAdi = $('#Adi').val();
        var OyuncuSoyadi = $('#Soyadi').val();
        var OyuncuCinsiyet = $('#Cinsiyet').val();
        var OyuncuDogumTarihi = $('#DogumTarihi').val();
        var OyuncuDogumYeri = $('#DogumYeri').val();
        var OyuncuBiyografi = $('#Biyografi').val();

        formData.append('Adi', OyuncuAdi);
        formData.append('Soyadi', OyuncuSoyadi);
        formData.append('Cinsiyet', OyuncuCinsiyet);
        formData.append('DogumTarihi', OyuncuDogumTarihi);
        formData.append('DogumYeri', OyuncuDogumYeri);
        formData.append('Biyografi', OyuncuBiyografi);

        $.ajax({
            url: '/AdminPanel/Oyuncu/Add',
            type: 'post',
            dataType: 'json',
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                $("#frmOyuncuEkle")[0].reset();
                $("#modalOyuncuEkle").modal("hide");
                $("#tblOyuncu").DataTable().destroy();
                DataTableGenerate();
                swal.close();
                if (response.result) {
                    Swal.fire({
                        title: "Başarılı",
                        text: response.mesaj,
                        icon: "success"
                    });
                }
            },
            error: function () {
                swal.close();
                Swal.fire({
                    title: "Hata",
                    text: "İşlem sırasında bir hata oluştu",
                    icon: "error"
                });
            }
        });
    });

    $(document).on('change', '.form-check-input', function () {
        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        var id = $(this).attr('oyuncuid');
        var aktifpasif = $(this).is(':checked');

        $.ajax({
            url: "/AdminPanel/Oyuncu/AktifPasif",
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
                        icon: "success",
                        willClose: function () {
                            // Tabloyu yeniden yükle
                            DataTableGenerate();
                        }
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

    $(document).on('click', '.btnSil', function () {


        var id = $(this).attr('oyuncuid');

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
                    url: "/AdminPanel/Oyuncu/Delete",
                    type: "post",
                    dataType: "json",
                    data: { id: id },
                    success: function (r) {
                        if (r.result) {
                            $("#tblOyuncu").DataTable().destroy();
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

    $(document).on('click', '.btnDuzenle', function () {
        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        var id = $(this).attr('oyuncuid');
        $("#GId").val(id);

        $.ajax({
            url: "/AdminPanel/Oyuncu/Getir",
            type: "post",
            dataType: "json",
            data: { id: id },
            success: function (r) {
                swal.close();
                if (r.result && r.model) {
                    $("#GAdi").val(r.model.adi || '');
                    $("#GSoyadi").val(r.model.soyadi || '');
                    $("#GCinsiyet").val(r.model.cinsiyet === true ? '1' : '0');
                    $("#GDogumTarihi").val(r.model.dogumTarihi || '');
                    $("#GDogumYeri").val(r.model.dogumYeri || '');
                    $("#GBiyografi").val(r.model.biyografi || '');
                    $("#modalOyuncuGuncelle").modal("show");
                } else {
                    Swal.fire({
                        title: "HATA",
                        text: r.mesaj || "Oyuncu bilgileri alınamadı",
                        icon: "error"
                    });
                }
            },
            error: function () {
                swal.close();
                Swal.fire({
                    title: "HATA",
                    text: "İşlem sırasında bir hata oluştu",
                    icon: "error"
                });
            }
        });
    });

    
    $(document).on('click', '#btnOyuncuGuncelle', function () {
        // Get the form element for validation
        var form = document.getElementById('frmOyuncuGuncelle');

        
        if (!form.checkValidity()) {
            form.reportValidity();
            return;
        }

        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        var formData = new FormData();

        var OyuncuId = $('#GId').val();
        var OyuncuAdi = $('#GAdi').val();
        var OyuncuSoyadi = $('#GSoyadi').val();
        var OyuncuCinsiyet = $('#GCinsiyet').val();
        var OyuncuDogumTarihi = $('#GDogumTarihi').val();
        var OyuncuDogumYeri = $('#GDogumYeri').val();
        var OyuncuBiyografi = $('#GBiyografi').val();

        formData.append('id', OyuncuId || '');
        formData.append('adi', OyuncuAdi || '');
        formData.append('soyadi', OyuncuSoyadi || '');
        formData.append('cinsiyet', OyuncuCinsiyet || '');

       
        if (OyuncuDogumTarihi && OyuncuDogumTarihi !== '') {
            formData.append('dogumTarihi', OyuncuDogumTarihi);
        }

        formData.append('dogumYeri', OyuncuDogumYeri || '');
        formData.append('biyografi', OyuncuBiyografi || '');

        $.ajax({
            url: "/AdminPanel/Oyuncu/Update",
            type: "post",
            dataType: "json",
            data: formData,
            contentType: false,
            processData: false,
            success: function (r) {
                $("#tblOyuncu").DataTable().destroy();
                DataTableGenerate();
                $("#modalOyuncuGuncelle").modal("hide"); // Close the modal after successful update

                swal.close();
                if (r.result) {
                    Swal.fire({
                        title: "İŞLEM BAŞARILI",
                        text: r.mesaj,
                        icon: "success"
                    });
                } else {
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
});

