var table;

function DataTableGenerate() {
    if ($.fn.DataTable.isDataTable('#tblFilmler')) {
        $('#tblFilmler').DataTable().destroy();
    }

    table = $("#tblFilmler").DataTable({
        "dom": "Bfrtip",
        "responsive": true,
        "lengthChange": true,
        "pageLength": 10,
        "autoWidth": false,
        ajax: {
            url: '/AdminPanel/Film/List',
            type: 'post',
            dataSrc: function (json) {
                return json.data;
            }
        },
        columns: [
            { data: 'id', visible: false },
            { data: null }, 
            { data: 'turler' }, 
            { data: 'aciklama' },
            { data: 'sure' },
            { data: 'cikisTarihi' },
            { data: 'dilAdi' },
            { data: 'platformlar' },
            {
                data: 'id',
                render: function (data, type, row, meta) {
                    return "<a href='/AdminPanel/Film/Edit/" + data + "' class='btn btn-info btnDuzenle'><i class='fas fa-pencil-alt'></i> DÜZENLE</a>";
                }
            },
            {
                data: 'aktif',
                render: function (data, type, row) {
                    var filmid = row["id"];
                    var aktifDurum = row["aktif"];
                    var checkedAttr = aktifDurum ? "checked" : "";

                    return "<div class='d-flex justify-content-between'><div class='form-check form-switch ms-2'><input class='form-check-input' type='checkbox' " + checkedAttr + " filmid='" + filmid + "'/></div></div>";
                }
            }
        ],
        columnDefs: [
            {
                targets: 1,
                render: function (data, type, row, meta) {
                    var thumbnailUrl = row.thumbnail || '/adminassets/images/avatars/01.png';
                    var posterUrl = row.poster || '/adminassets/images/avatars/01.png';
                    return '<div class="film-container d-flex align-items-center">' +
                        '<img src="' + thumbnailUrl + '" class="film-thumbnail me-2" style="width: 50px; height: 50px; object-fit: cover; border-radius: 4px; cursor: pointer;" ' +
                        'onclick="afisiBuyut(\'' + posterUrl + '\', \'' + row.adi + '\')" ' +
                        'alt="' + row.adi + '">' +
                        '<span class="film-adi">' + row.adi + '</span>' +
                        '</div>';
                }
            },
            {
                targets: 2,
                render: function (data, type, row, meta) {
                    if (data && Array.isArray(data) && data.length > 0) {
                        return data.join(', ');
                    }
                    return '-';
                }
            },
            {
                targets: 4,
                render: function (data) {
                    if (!data || data === '-') return '-';
                    return data;
                }
            },
            {
                targets: 5,
                render: function (data, type, row) {
                    if (!data || data === '-') return '-';
                    return data;
                }
            },
            {
                targets: 7,
                render: function (data) {
                    if (!data || data.length === 0) return '-';
                    return data.join(', ');
                }
            }
        ],
        initComplete: function (settings, json) {
           
        },
        drawCallback: function () {
            // Arama Yapıldığında, Sayfalama Yapıldığında, Sıralama Yapıldığında Draw yapılıyor
           
        }
    });
}

$(function () {
    
    DataTableGenerate();

    
    if (new URLSearchParams(window.location.search).get('refresh') === 'true') {
        setTimeout(function () {
            DataTableGenerate();
        }, 500);
    }
});

function afisiBuyut(afisUrl, filmAdi) {
    Swal.fire({
        title: filmAdi,
        imageUrl: afisUrl,
        imageWidth: 800,
        imageHeight: 'auto',
        imageAlt: filmAdi + ' Afişi',
        showCloseButton: true,
        confirmButtonText: 'Kapat',
        customClass: {
            image: 'img-fluid'
        }
    });
}

$(document).on('change', '.form-check-input', function () {
    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading();
        },
    });

    var id = $(this).attr('filmid');
    var aktifpasif = $(this).is(':checked');

    $.ajax({
        url: "/AdminPanel/Film/AktifPasif",
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