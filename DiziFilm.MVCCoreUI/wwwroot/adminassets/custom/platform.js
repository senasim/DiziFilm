var table;
var filepond;

function DataTableGenerate() {
    table = $("#tblPlatform").DataTable({
        "dom": "Bfrtip",
        "responsive": true,
        "lengthChange": true,
        "pageLength": 10,
        "autoWidth": false,
        ajax: { url: '/AdminPanel/Platform/List', type: 'post' },
        columns: [
            { data: 'id', visible: false },
            { data: 'platformAdi' },
            { data: 'logo' },
            { data: 'id' },
            { data: 'aktif' },
        ],
        columnDefs: [
            {
                targets: 2,
                render: function (data, type, row, meta) {
                    if (data == null || data === "") {
                        return "<img src='/adminassets/images/page-img/03.jpg' width='60px' />";
                    }
                    else {
                        return "<img logoName='" + row["logoAdi"] + "' class='logoimage' src='" + data + "' width='60px' /> ";
                    }
                }
            },
            {
                targets: 3,
                render: function (data, type, row) {
                    return "<a class='btn btn-info btnDuzenle' yonetmenid=" + data + ">   <i class='fas fa-pencil-alt'></i> DÜZENLE</a>";
                }
            },
            {
                targets: 4,
                render: function (data, type, row) {
                    return data ? "<span class='badge bg-success'>Aktif</span>" : "<span class='badge bg-danger'>Pasif</span>";
                }
            }
        ]
    });
}

// PLATFORM EKLEME
$(document).ready(function () {
    DataTableGenerate();

    // FilePond'u başlat
    FilePond.registerPlugin(
        FilePondPluginImagePreview,
        FilePondPluginFileValidateType,
        FilePondPluginFileValidateSize
    );

    filepond = FilePond.create(document.querySelector('input[type="file"].filepond'), {
        labelIdle: 'Logo yüklemek için <span class="filepond--label-action">tıklayın</span> veya sürükleyin',
        labelFileProcessing: 'Yükleniyor',
        labelFileProcessingComplete: 'Yüklendi',
        labelTapToCancel: 'iptal etmek için tıklayın',
        labelFileWaitingForSize: 'boyut hesaplanıyor',
        labelFileLoadError: 'Yükleme hatası',
        labelFileProcessingError: 'Yükleme hatası',
        labelFileProcessingRevertError: 'Geri alma hatası',
        labelFileRemoveError: 'Silme hatası',
        labelFileRevertError: 'Geri alma hatası',
        labelFileProcessingAborted: 'Yükleme iptal edildi',
        labelFileProcessingComplete: 'Yükleme tamamlandı',
        labelFileProcessingUndo: 'geri alınıyor',
        acceptedFileTypes: ['image/*'],
        maxFileSize: '5MB',
        server: {
            url: '/AdminPanel/Platform/Upload',
            process: {
                method: 'POST',
                withCredentials: false,
                headers: {},
                timeout: 7000,
                onload: (response) => {
                    try {
                        const result = JSON.parse(response);
                        if (result.success) {
                            $("#logoPath").val(result.filePath);
                            return result.filePath;
                        }
                        return response;
                    } catch (e) {
                        console.error("Yanıt ayrıştırma hatası:", e);
                        return response;
                    }
                },
                onerror: (response) => {
                    console.error("Yükleme hatası:", response);
                    return response.data;
                }
            }
        }
    });

    // FilePond olaylarını dinle
    filepond.on('addfile', (error, file) => {
        if (error) {
            console.error("Dosya ekleme hatası:", error);
            return;
        }
        console.log("Dosya eklendi:", file.filename);
    });

    filepond.on('processfile', (error, file) => {
        if (error) {
            console.error("Dosya işleme hatası:", error);
            return;
        }
        console.log("Dosya işlendi:", file.filename);
    });

    filepond.on('processfilerevert', (file) => {
        console.log("Dosya geri alındı:", file.filename);
    });

    filepond.on('removefile', (file) => {
        console.log("Dosya kaldırıldı:", file.filename);
        $("#logoPath").val("");
    });

    $("#btnPlatformEkle").on("click", function () {
        if ($("#txtAd").val().trim() === "") {
            Swal.fire({
                title: 'Uyarı!',
                text: 'Platform adı boş olamaz!',
                icon: 'warning',
                confirmButtonText: 'Tamam'
            });
            return;
        }

        submitForm();
    });

    // Form gönderme fonksiyonu
    function submitForm() {
        var formData = new FormData(document.getElementById("frmPlatformEkle"));
        
        // Logo yolunu kontrol et
        var logoPath = $("#logoPath").val();
        if (!logoPath) {
            console.log("Logo yolu boş, form gönderiliyor...");
        } else {
            console.log("Logo yolu:", logoPath);
        }
        
        $.ajax({
            url: "/AdminPanel/Platform/Add",
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response.success) {
                    Swal.fire({
                        title: 'Başarılı!',
                        text: 'Platform başarıyla eklendi.',
                        icon: 'success',
                        confirmButtonText: 'Tamam'
                    }).then(() => {
                        table.ajax.reload();
                        $('#modalPlatformEkle').modal('hide');
                        $('#frmPlatformEkle')[0].reset();
                        filepond.removeFiles();
                        $("#logoPath").val("");
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
            error: function (xhr, status, error) {
                console.error("Ajax hatası:", error);
                Swal.fire({
                    title: 'Hata!',
                    text: 'İşlem sırasında bir hata oluştu.',
                    icon: 'error',
                    confirmButtonText: 'Tamam'
                });
            }
        });
    }
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

    var id = $(this).attr('platformid');
    var aktifpasif = $(this).is(':checked');

    $.ajax({
        url: "/AdminPanel/Platform/AktifPasif",
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