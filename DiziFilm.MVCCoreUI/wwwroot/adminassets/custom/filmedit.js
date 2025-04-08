$(function () {
    $('#GAciklama').summernote({
        height: 150
    });
    $('.js-example-basic-multiple').select2({
        placeholder: "Türleri seçiniz",
        allowClear: true
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

        var id = $(this).attr('filmid');
        $("#GFilmId").val(id);

        $.ajax({
            url: "/AdminPanel/Film/GetFilm",
            type: "post",
            dataType: "json",
            data: { id: id },
            success: function (r) {
                if (r.result) {
                  
                    $("#GAdi").val(r.model.adi);
                    $('#GAciklama').summernote('code', r.model.aciklama);
                    $("#GSure").val(r.model.sure);

                    if (r.model.cikisTarihi) {
                        $("#GCikisTarihi").val(formatDateForInput(r.model.cikisTarihi));
                    }

                    if (r.model.dilId) {
                        $("#GDilId").val(r.model.dilId);
                        $("#GDilId").trigger("change");
                    }

                    
                    if (r.model.filmTurs && r.model.filmTurs.length > 0) {
                        var turIds = r.model.filmTurs.map(function (tur) {
                            return tur.turId;
                        });
                        $("#GFilmTurs").val(turIds).trigger('change');
                    }

                    swal.close();
                    window.location.href = "/AdminPanel/Film/Edit/" + id;
                } else {
                    swal.close();
                    Swal.fire({
                        title: "HATA",
                        text: r.message || "Film bilgileri yüklenirken bir hata oluştu.",
                        icon: "error"
                    });
                }
            },
            error: function () {
                swal.close();
                Swal.fire({
                    title: "HATA",
                    text: "İşlem sırasında bir hata oluştu.",
                    icon: "error"
                });
            }
        });
    });

    $("#frmFilmEdit").submit(function (e) {
        e.preventDefault();

        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        var formData = new FormData(this);
        if ($("#GFilmTurs").val()) {
            var selectedTurler = $("#GFilmTurs").val();
            for (var i = 0; i < selectedTurler.length; i++) {
                formData.append("SelectedTurIds[]", selectedTurler[i]);
            }
        }

        $.ajax({
            url: '/AdminPanel/Film/Edit',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (r) {
                swal.close();
                if (r.result) {
                    Swal.fire({
                        title: "İŞLEM BAŞARILI",
                        text: "Film başarıyla güncellendi.",
                        icon: "success",
                        confirmButtonText: "Tamam"
                    }).then((result) => {
                        window.location.href = '/AdminPanel/Film/Index';
                    });
                } else {
                    Swal.fire({
                        title: "HATA",
                        text: r.message || "Film güncellenirken bir hata oluştu.",
                        icon: "error",
                        confirmButtonText: "Tamam"
                    });
                }
            },
            error: function () {
                swal.close();
                Swal.fire({
                    title: "HATA",
                    text: "İşlem sırasında bir hata oluştu.",
                    icon: "error",
                    confirmButtonText: "Tamam"
                });
            }
        });
    });

    // Oyuncu düzenle butonu
    $(document).on('click', '.oyuncu-duzenle', function () {
        var id = $(this).data('id');
        var oyuncuId = $(this).data('oyuncu-id');
        var rol = $(this).data('rol');

        $("#oyuncuEditId").val(id);
        $("#oyuncuSecimi").val(oyuncuId).trigger('change');
        $("#rolAdi").val(rol);

        $("#oyuncu-modal-label").text("Oyuncu Düzenle");
        var oyuncuModal = new bootstrap.Modal(document.getElementById('oyuncu-modal'));
        oyuncuModal.show();
    });

    // Oyuncu ekle butonu
    $(document).on('click', '.btn-oyuncu-ekle', function () {
        $("#oyuncuEditId").val(0);
        $("#oyuncuSecimi").val("").trigger('change');
        $("#rolAdi").val("");

        $("#oyuncu-modal-label").text("Oyuncu Ekle");
        var oyuncuModal = new bootstrap.Modal(document.getElementById('oyuncu-modal'));
        oyuncuModal.show();
    });

    // Oyuncu kaydetme
    $("#btnOyuncuEdit").on('click', function () {
        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        var id = $("#oyuncuEditId").val();
        var oyuncuId = $("#oyuncuSecimi").val();
        var rol = $("#rolAdi").val();
        var filmId = $("#GFilmId").val();

        if (!oyuncuId || !rol) {
            swal.close();
            Swal.fire({
                title: "HATA",
                text: "Lütfen oyuncu ve rol alanlarını doldurunuz!",
                icon: "error"
            });
            return;
        }

        $.ajax({
            url: '/AdminPanel/Film/SaveOyuncu',
            type: 'POST',
            data: {
                id: id,
                filmId: filmId,
                oyuncuId: oyuncuId,
                rol: rol
            },
            success: function (r) {
                swal.close();
                if (r.result) {
                    if (id == 0) {
                        window.location.reload();
                    } else {
                        $(`#oyuncu-${id} td:eq(1)`).text(rol);
                        $(`#oyuncu-${id}`).find('.oyuncu-duzenle').attr('data-rol', rol);
                    }

                    var oyuncuModal = bootstrap.Modal.getInstance(document.getElementById('oyuncu-modal'));
                    oyuncuModal.hide();

                    Swal.fire({
                        title: "İŞLEM BAŞARILI",
                        text: "Oyuncu bilgileri kaydedildi.",
                        icon: "success",
                        timer: 1500,
                        showConfirmButton: false
                    });
                } else {
                    Swal.fire({
                        title: "HATA",
                        text: r.message || "Oyuncu kaydedilirken bir hata oluştu.",
                        icon: "error"
                    });
                }
            },
            error: function () {
                swal.close();
                Swal.fire({
                    title: "HATA",
                    text: "İşlem sırasında bir hata oluştu.",
                    icon: "error"
                });
            }
        });
    });

    // Oyuncu silme
    $(document).on('click', '.oyuncu-sil', function () {
        var id = $(this).data('id');

        Swal.fire({
            title: "SİLME İŞLEMİ",
            text: "Bu oyuncuyu silmek istediğinize emin misiniz?",
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
                    url: '/AdminPanel/Film/DeleteOyuncu',
                    type: 'POST',
                    data: { id: id },
                    success: function (r) {
                        swal.close();
                        if (r.result) {
                            $(`#oyuncu-${id}`).remove();

                            Swal.fire({
                                title: "İŞLEM BAŞARILI",
                                text: "Oyuncu başarıyla silindi.",
                                icon: "success",
                                timer: 1500,
                                showConfirmButton: false
                            });
                        } else {
                            Swal.fire({
                                title: "HATA",
                                text: r.message || "Oyuncu silinirken bir hata oluştu.",
                                icon: "error"
                            });
                        }
                    },
                    error: function () {
                        swal.close();
                        Swal.fire({
                            title: "HATA",
                            text: "İşlem sırasında bir hata oluştu.",
                            icon: "error"
                        });
                    }
                });
            }
        });
    });

    // Yönetmen düzenle butonu
    $(document).on('click', '.yonetmen-duzenle', function () {
        var id = $(this).data('id');
        var yonetmenId = $(this).data('yonetmen-id');

        $("#yonetmenEditId").val(id);
        $("#yonetmenSecimi").val(yonetmenId).trigger('change');

        $("#yonetmen-modal-label").text("Yönetmen Düzenle");
        var yonetmenModal = new bootstrap.Modal(document.getElementById('yonetmen-modal'));
        yonetmenModal.show();
    });

    // Yönetmen ekle butonu
    $(document).on('click', '.btn-yonetmen-ekle', function () {
        $("#yonetmenEditId").val(0);
        $("#yonetmenSecimi").val("").trigger('change');

        $("#yonetmen-modal-label").text("Yönetmen Ekle");
        var yonetmenModal = new bootstrap.Modal(document.getElementById('yonetmen-modal'));
        yonetmenModal.show();
    });

    // Yönetmen kaydetme
    $("#btnYonetmenEdit").on('click', function () {
        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        var id = $("#yonetmenEditId").val();
        var yonetmenId = $("#yonetmenSecimi").val();
        var filmId = $("#GFilmId").val();

        if (!yonetmenId) {
            swal.close();
            Swal.fire({
                title: "HATA",
                text: "Lütfen yönetmen seçiniz!",
                icon: "error"
            });
            return;
        }

        $.ajax({
            url: '/AdminPanel/Film/SaveYonetmen',
            type: 'POST',
            data: {
                id: id,
                filmId: filmId,
                yonetmenId: yonetmenId
            },
            success: function (r) {
                swal.close();
                if (r.result) {
                    // Sayfayı yenile
                    window.location.reload();
                } else {
                    Swal.fire({
                        title: "HATA",
                        text: r.message || "Yönetmen kaydedilirken bir hata oluştu.",
                        icon: "error"
                    });
                }
            },
            error: function () {
                swal.close();
                Swal.fire({
                    title: "HATA",
                    text: "İşlem sırasında bir hata oluştu.",
                    icon: "error"
                });
            }
        });
    });

    // Yönetmen silme
    $(document).on('click', '.yonetmen-sil', function () {
        var id = $(this).data('id');

        Swal.fire({
            title: "SİLME İŞLEMİ",
            text: "Bu yönetmeni silmek istediğinize emin misiniz?",
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
                    url: '/AdminPanel/Film/DeleteYonetmen',
                    type: 'POST',
                    data: { id: id },
                    success: function (r) {
                        swal.close();
                        if (r.result) {
                            $(`#yonetmen-${id}`).remove();

                            Swal.fire({
                                title: "İŞLEM BAŞARILI",
                                text: "Yönetmen başarıyla silindi.",
                                icon: "success",
                                timer: 1500,
                                showConfirmButton: false
                            });
                        } else {
                            Swal.fire({
                                title: "HATA",
                                text: r.message || "Yönetmen silinirken bir hata oluştu.",
                                icon: "error"
                            });
                        }
                    },
                    error: function () {
                        swal.close();
                        Swal.fire({
                            title: "HATA",
                            text: "İşlem sırasında bir hata oluştu.",
                            icon: "error"
                        });
                    }
                });
            }
        });
    });

    // Platform düzenle butonu
    $(document).on('click', '.platform-duzenle', function () {
        var id = $(this).data('id');
        var platformId = $(this).data('platform-id');

        $("#platformEditId").val(id);
        $("#platformSecimi").val(platformId).trigger('change');

        $("#platform-modal-label").text("Platform Düzenle");
        var platformModal = new bootstrap.Modal(document.getElementById('platform-modal'));
        platformModal.show();
    });

    // Platform ekle butonu
    $(document).on('click', '.btn-platform-ekle', function () {
        $("#platformEditId").val(0);
        $("#platformSecimi").val("").trigger('change');

        $("#platform-modal-label").text("Platform Ekle");
        var platformModal = new bootstrap.Modal(document.getElementById('platform-modal'));
        platformModal.show();
    });

    // Platform kaydetme
    $("#btnPlatformEdit").on('click', function () {
        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        var id = $("#platformEditId").val();
        var platformIds = $("#platformSecimi").val();
        var filmId = $("#GFilmId").val();

        if (!platformIds || platformIds.length === 0) {
            swal.close();
            Swal.fire({
                title: "HATA",
                text: "Lütfen en az bir platform seçiniz!",
                icon: "error"
            });
            return;
        }

        $.ajax({
            url: '/AdminPanel/Film/SavePlatforms',
            type: 'POST',
            data: {
                filmId: filmId,
                platformIds: JSON.stringify(platformIds)
            },
            success: function (r) {
                swal.close();
                if (r.result) {
                    // Sayfayı yenile
                    window.location.reload();
                } else {
                    Swal.fire({
                        title: "HATA",
                        text: r.message || "Platform kaydedilirken bir hata oluştu.",
                        icon: "error"
                    });
                }
            },
            error: function () {
                swal.close();
                Swal.fire({
                    title: "HATA",
                    text: "İşlem sırasında bir hata oluştu.",
                    icon: "error"
                });
            }
        });
    });

    // Platform silme
    $(document).on('click', '.platform-sil', function () {
        var id = $(this).data('id');

        Swal.fire({
            title: "SİLME İŞLEMİ",
            text: "Bu platformu silmek istediğinize emin misiniz?",
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
                    url: '/AdminPanel/Film/DeletePlatform',
                    type: 'POST',
                    data: { id: id },
                    success: function (r) {
                        swal.close();
                        if (r.result) {
                            $(`#platform-${id}`).remove();

                            Swal.fire({
                                title: "İŞLEM BAŞARILI",
                                text: "Platform başarıyla silindi.",
                                icon: "success",
                                timer: 1500,
                                showConfirmButton: false
                            });
                        } else {
                            Swal.fire({
                                title: "HATA",
                                text: r.message || "Platform silinirken bir hata oluştu.",
                                icon: "error"
                            });
                        }
                    },
                    error: function () {
                        swal.close();
                        Swal.fire({
                            title: "HATA",
                            text: "İşlem sırasında bir hata oluştu.",
                            icon: "error"
                        });
                    }
                });
            }
        });
    });

    // Yardımcı fonksiyonlar
    function formatDateForInput(dateString) {
        var date = new Date(dateString);
        var year = date.getFullYear();
        var month = (date.getMonth() + 1).toString().padStart(2, '0');
        var day = date.getDate().toString().padStart(2, '0');
        return `${year}-${month}-${day}`;
    }
});