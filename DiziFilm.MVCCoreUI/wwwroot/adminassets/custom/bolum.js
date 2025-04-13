var table;
function DataTableGenerate() {
    if ($.fn.DataTable.isDataTable('#tblBolum')) {
        $('#tblBolum').DataTable().destroy();
    }

    table = $('#tblBolum').DataTable({
        "responsive": false,
        "autoWidth": false,
        "processing": true,
        "serverSide": true,
        ajax: {
            url: '/AdminPanel/Bolum/List',
            type: 'POST',
        },
        columns: [
            { data: "id", visible: false },
            { data: "adi" },
            { data: "bolumAdi" },
            { data: "sezonNo" },
            { data: "bolumNo" },
            { data: "sure" },
            { data: "bolumTarihi" },
            { data: 'id' },
            { data: 'id' }
        ],
        columnDefs: [
            {
                targets: 1,
                render: function (data, type, row, meta) {
                    return row.adi;
                }
            },
            {
                targets: 5,
                render: function (data, type, row, meta) {
                    if (!data || data === '-') return '-';
                    return data;
                }
            },
            {
                targets: 6,
                render: function (data, type, row, meta) {
                    if (!data || data === '-') return '-';
                    return data;
                }
            },
            {
                targets: 7,
                render: function (data, type, row, meta) {
                    return "<button class='btn btn-primary btnDuzenle' data-bolumid='" + data + "'>DÜZENLE</button>";
                }
            },
            {
                targets: 8,
                render: function (data, type, row) {
                    var bolumid = row["id"];
                    var aktifDurum = row["aktif"];
                    var checkedAttr = aktifDurum ? "checked" : "";

                    return "<div class='d-flex justify-content-between'><div class='form-check form-switch ms-2'><input class='form-check-input' type='checkbox' " + checkedAttr + " data-bolumid='" + bolumid + "'/></div></div>";
                }
            }
        ],
        initComplete: function (settings, json) {
            console.log('DataTable initialized successfully');
        },
        drawCallback: function () {
        }
    });
}

$(function () {
    DataTableGenerate();
});

//DİZİLERİ GETİR
function loadDiziler(selectedDiziId, selectedSezonId) {
    $.ajax({
        url: '/AdminPanel/Bolum/GetDiziler',
        type: 'GET',
        success: function (data) {
            console.log('Diziler data:', data);

            var diziSelect = $('select[asp-for=DiziListe]');
            diziSelect.empty();
            diziSelect.append('<option value="0">Dizi Seçiniz</option>');

            if (data && data.length > 0) {
                $.each(data, function (i, dizi) {
                    var option = $('<option></option>').val(dizi.id).text(dizi.text);
                    if (dizi.id == selectedDiziId) {
                        option.attr('selected', 'selected');
                    }
                    diziSelect.append(option);
                });

                
                if (selectedDiziId && selectedDiziId != 0) {
                    loadSezonlar(selectedDiziId, selectedSezonId);
                }
            }
        },
        error: function (xhr, status, error) {
            

            Swal.fire({
                title: "HATA",
                text: "Diziler yüklenirken bir hata oluştu!",
                icon: "error"
            });
        }
    });
}

//SEZONLARI GETİR
function loadSezonlar(diziId, selectedSezonId) {
    $.ajax({
        url: '/AdminPanel/Bolum/GetSezonlar',
        type: 'GET',
        data: { id: diziId },
        success: function (data) {

            var sezonSelect = $('#sezonId');
            sezonSelect.empty();
            sezonSelect.append('<option value="0">Sezon Seçiniz</option>');

            if (data && data.length > 0) {
                $.each(data, function (i, sezon) {
                    var option = $('<option></option>')
                        .val(sezon.id)
                        .text(sezon.text)
                        .data('dizi-id', sezon.diziId);
                    
                    if (sezon.id == selectedSezonId) {
                        option.attr('selected', 'selected');
                    }
                    sezonSelect.append(option);
                });
            }
        },
        error: function (xhr, status, error) {
        }
    });
}



// Event delegasyonu ile click ve change eventlerini yönetme (modern yaklaşım)
$(document).on('click', '.btnDuzenle', function () {
    var bolumId = $(this).data('bolumid');
    getBolumById(bolumId);
});

//AKTİF PASİF

$(document).on('change', '.form-check-input', function () {
    var swal = Swal.fire({
        title: "LÜTFEN BEKLEYİNİZ...",
        html: "İşleminiz Yapılıyor",
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading();
        },
    });

    var id = $(this).data('bolumid');
    var aktifpasif = $(this).is(':checked');

    $.ajax({
        url: "/AdminPanel/Bolum/AktifPasif",
        type: "POST",
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
        error: function (xhr, status, error) {
            swal.close();
            console.error('AktifPasif error:', error);
            Swal.fire({
                title: "HATA",
                text: "İşlem sırasında bir hata oluştu.",
                icon: "error"
            });
        }
    });
});

// Modal için fonksiyonlar
function getBolumById(id) {
    $.ajax({
        url: "/AdminPanel/Bolum/GetBolum",
        type: "GET",
        data: { id: id },
        success: function (response) {
            if (response.result) {
                var bolum = response.model.bolum;
                var sezon = response.model.sezon;
                var dizi = response.model.dizi;

                
                $('#bolumId').val(bolum.id);
                $('#bolumAdi').val(bolum.bolumAdi);
                $('#bolumSayisi').val(bolum.bolumSayisi);
                $('#sure').val(bolum.sure);

                if (bolum.yayinTarihi) {
                    // Tarih formatını ISO'ya çevir (yyyy-MM-dd)
                    var date = new Date(bolum.yayinTarihi);
                    var formattedDate = date.toISOString().split('T')[0];
                    $('#yayinTarihi').val(formattedDate);
                }

                
                loadDiziler(dizi.id, bolum.sezonId);

                $('#bolumModalEkle').modal('show');
                $('#bolumModalLabel').text('Bölüm Düzenle');
            } else {
                Swal.fire({
                    title: "HATA",
                    text: response.message || "Bölüm bilgileri alınamadı!",
                    icon: "error"
                });
            }
        },
        error: function (xhr, status, error) {
            console.error('GetBolum error:', error);
            Swal.fire({
                title: "HATA",
                text: "Bölüm bilgileri alınırken bir hata oluştu!",
                icon: "error"
            });
        }
    });
}

$(document).ready(function () {
   
    $(document).on('click', '.btn-primary:contains("Bölüm Ekle")', function () {
        
        resetForm();

       
        $('#bolumModalEkle').modal('show');
        $('#bolumModalLabel').text('Bölüm Ekle');

        
        loadDiziler(0, 0);
    });

  
    function resetForm() {
        $('#bolumForm')[0].reset();
        $('#bolumId').val(0);

        $('select[asp-for=DiziListe]').empty().append('<option value="0">Dizi Seçiniz</option>');
        $('#sezonId').empty().append('<option value="0">Sezon Seçiniz</option>');
    }

    
    $(document).on('change', 'select[asp-for=DiziListe]', function () {
        var diziId = $(this).val();
        if (diziId && diziId != "0") {
            loadSezonlar(diziId, 0);
        } else {
            $('#sezonId').empty().append('<option value="0">Sezon Seçiniz</option>');
        }
    });

  
    $(document).on('click', '#btnBolumEkle', function () {
       
        var form = $('#bolumForm')[0];
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

        
        var formData = {
            Id: $('#bolumId').val(),
            BolumAdi: $('#bolumAdi').val(),
            SezonId: $('#sezonId').val(),
            BolumSayisi: $('#bolumSayisi').val(),
            Sure: $('#sure').val(),
            YayinTarihi: $('#yayinTarihi').val()
        };

      
        $.ajax({
            url: '/AdminPanel/Bolum/Add',
            type: 'POST',
            data: formData,
            success: function (response) {
                swal.close();

                if (response.result) {
                    $('#bolumModalEkle').modal('hide');

                    Swal.fire({
                        title: "İŞLEM BAŞARILI",
                        text: response.message || "Bölüm başarıyla kaydedildi!",
                        icon: "success",
                        willClose: function () {
                            
                            if (typeof DataTableGenerate === 'function') {
                                DataTableGenerate();
                            } else {
                                location.reload();
                            }
                        }
                    });
                } else {
                    
                    Swal.fire({
                        title: "HATA",
                        text: response.message || "Bölüm kaydedilirken bir hata oluştu!",
                        icon: "error"
                    });
                }
            },
            error: function (xhr, status, error) {
               
            }
        });
    });
});