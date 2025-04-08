$(document).ready(function () {
    // Select2 kütüphanesini başlat
    $('.js-example-basic-multiple').select2({
        width: '100%'
    });

    $('.platformSelect').select2({
        width: '100%',
        dropdownParent: $('#platform-modal')
    });

    // Oyuncu Ekleme İşlemi
    $('#btnOyuncuEkle').click(function () {
        var oyuncuId = $('#oyuncuSecimi').val();
        var rolAdi = $('#rolAdi').val();

        if (!oyuncuId || !rolAdi) {
            Swal.fire({
                title: 'Hata!',
                text: 'Lütfen tüm alanları doldurunuz.',
                icon: 'error',
                confirmButtonText: 'Tamam'
            });
            return;
        }

        var oyuncuText = $('#oyuncuSecimi option:selected').text();
        var yeniSatir = `
            <tr class="text-center" id="oyuncu-${Date.now()}">
                <td>${oyuncuText}</td>
                <td>${rolAdi}</td>
                <td>
                    <div class="d-flex align-items-center justify-content-center">
                        <button type="button" class="btn btn-sm text-danger border-0 oyuncu-sil" data-id="${Date.now()}" title="Sil">
                            <i class="fa-solid fa-trash"></i>
                        </button>
                    </div>
                </td>
            </tr>
        `;

        $('#oyuncuTablosu tbody').append(yeniSatir);
        $('#oyuncu-modal').modal('hide');
        $('#frmOyuncuEkle')[0].reset();
    });

    // Yönetmen Ekleme İşlemi
    $('#btnYonetmenEkle').click(function () {
        var yonetmenId = $('#yonetmenSecimi').val();

        if (!yonetmenId) {
            Swal.fire({
                title: 'Hata!',
                text: 'Lütfen yönetmen seçiniz.',
                icon: 'error',
                confirmButtonText: 'Tamam'
            });
            return;
        }

        var yonetmenText = $('#yonetmenSecimi option:selected').text();
        var yeniSatir = `
            <tr class="text-center" id="yonetmen-${Date.now()}">
                <td>${yonetmenText}</td>
                <td>
                    <div class="d-flex align-items-center justify-content-center">
                        <button type="button" class="btn btn-sm text-danger border-0 yonetmen-sil" data-id="${Date.now()}" title="Sil">
                            <i class="fa-solid fa-trash"></i>
                        </button>
                    </div>
                </td>
            </tr>
        `;

        $('#yonetmenTablosu tbody').append(yeniSatir);
        $('#yonetmen-modal').modal('hide');
        $('#frmYonetmenEkle')[0].reset();
    });

    // Platform Ekleme İşlemi
    $('#btnPlatformEkle').click(function () {
        var seciliPlatformlar = $('#platformSecimi').val();

        if (!seciliPlatformlar || seciliPlatformlar.length === 0) {
            Swal.fire({
                title: 'Hata!',
                text: 'Lütfen en az bir platform seçiniz.',
                icon: 'error',
                confirmButtonText: 'Tamam'
            });
            return;
        }

        seciliPlatformlar.forEach(function (platformId) {
            var platformText = $('#platformSecimi option[value="' + platformId + '"]').text();
            var timestamp = Date.now();
            var yeniSatir = `
                <tr class="text-center" id="platform-${timestamp}-${platformId}">
                    <td>${platformText}</td>
                    <td>
                        <div class="d-flex align-items-center justify-content-center">
                            <button type="button" class="btn btn-sm text-danger border-0 platform-sil" data-id="${timestamp}-${platformId}" title="Sil">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>
                    </td>
                </tr>
            `;
            $('#platformTablosu tbody').append(yeniSatir);
        });

        $('#platform-modal').modal('hide');
        $('#frmPlatformEkle')[0].reset();
        $('#platformSecimi').val(null).trigger('change');
    });

    // Silme İşlemleri
    $(document).on('click', '.oyuncu-sil', function () {
        var id = $(this).data('id');
        Swal.fire({
            title: 'Emin misiniz?',
            text: "Bu oyuncu kaydı silinecek!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Evet, sil!',
            cancelButtonText: 'İptal'
        }).then((result) => {
            if (result.isConfirmed) {
                $(`#oyuncu-${id}`).remove();
            }
        });
    });

    $(document).on('click', '.yonetmen-sil', function () {
        var id = $(this).data('id');
        Swal.fire({
            title: 'Emin misiniz?',
            text: "Bu yönetmen kaydı silinecek!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Evet, sil!',
            cancelButtonText: 'İptal'
        }).then((result) => {
            if (result.isConfirmed) {
                $(`#yonetmen-${id}`).remove();
            }
        });
    });

    $(document).on('click', '.platform-sil', function () {
        var id = $(this).data('id');
        Swal.fire({
            title: 'Emin misiniz?',
            text: "Bu platform kaydı silinecek!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#d33',
            cancelButtonColor: '#3085d6',
            confirmButtonText: 'Evet, sil!',
            cancelButtonText: 'İptal'
        }).then((result) => {
            if (result.isConfirmed) {
                $(`#platform-${id}`).remove();
            }
        });
    });

    // Form Gönderimi
    $('#frmFilmEkle').submit(function (e) {
        e.preventDefault();

        var formData = new FormData(this);

        // Oyuncuları ekle
        var oyuncular = [];
        $('#oyuncuTablosu tbody tr').each(function () {
            var oyuncuId = $(this).find('td:first').text();
            var rol = $(this).find('td:nth-child(2)').text();
            oyuncular.push({ oyuncuId: oyuncuId, rol: rol });
        });
        formData.append('Oyuncular', JSON.stringify(oyuncular));

        // Yönetmenleri ekle
        var yonetmenler = [];
        $('#yonetmenTablosu tbody tr').each(function () {
            var yonetmenId = $(this).find('td:first').text();
            yonetmenler.push(yonetmenId);
        });
        formData.append('Yonetmenler', JSON.stringify(yonetmenler));

        // Platformları ekle
        var platformlar = [];
        $('#platformTablosu tbody tr').each(function () {
            var platformId = $(this).find('td:first').text();
            platformlar.push(platformId);
        });
        formData.append('Platformlar', JSON.stringify(platformlar));

        $.ajax({
            url: $(this).attr('action'),
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response.success) {
                    Swal.fire({
                        title: 'Başarılı!',
                        text: 'Film başarıyla eklendi.',
                        icon: 'success',
                        confirmButtonText: 'Tamam'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.href = '/AdminPanel/Film/Index';
                        }
                    });
                } else {
                    Swal.fire({
                        title: 'Hata!',
                        text: response.message || 'Bir hata oluştu.',
                        icon: 'error',
                        confirmButtonText: 'Tamam'
                    });
                }
            },
            error: function () {
                Swal.fire({
                    title: 'Hata!',
                    text: 'Bir hata oluştu.',
                    icon: 'error',
                    confirmButtonText: 'Tamam'
                });
            }
        });
    });
});
