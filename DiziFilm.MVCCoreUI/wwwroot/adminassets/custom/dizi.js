$(document).ready(function () {

   
    var table;

    function DataTableGenerate() {
        table = $('#tblDizi').DataTable({
            "dom": "Bfrtip",
            "responsive": true,
            "lengthChange": true,
            "pageLength": 10,
            "autoWidth": false,
            "language": {
                "url": "//cdn.datatables.net/plug-ins/1.10.21/i18n/Turkish.json"
            },
            ajax: {
                url: '/AdminPanel/Dizi/List',
                type: 'post'
            },
            columns: [
                { data: 'id', visible: false },
                { data: 'adi' },
                { data: 'turAdi' },
                { 
                    data: 'baslamaTarihi',
                    render: function(data) {
                        return data ? new Date(data).toLocaleDateString('tr-TR') : '-';
                    }
                },
                { 
                    data: 'bitisTarihi',
                    render: function(data) {
                        return data ? new Date(data).toLocaleDateString('tr-TR') : '-';
                    }
                },
                { data: 'sezonSayisi' },
                { data: 'bolumSayisi' },
                { data: 'dilAdi' },
                { data: 'platformAdi' },
                {
                    data: 'aktif',
                    render: function (data, type, row) {
                        var diziid = row["id"];
                        var aktifDurum = row["aktif"];
                        var checkedAttr = aktifDurum ? "checked" : "";
                        return "<div class='d-flex justify-content-between'><div class='form-check form-switch ms-2'><input class='form-check-input' type='checkbox' " + checkedAttr + " diziid='" + diziid + "'/></div></div>";
                    }
                },
                {
                    data: 'id',
                    render: function (data) {
                        return "<div class='d-flex gap-2'>" +
                               "<button class='btn btn-info btn-sm btnDuzenle' diziid='" + data + "'><i class='fas fa-pencil-alt'></i></button>" +
                               "<button class='btn btn-danger btn-sm btnSil' diziid='" + data + "'><i class='fas fa-trash'></i></button>" +
                               "</div>";
                    }
                }
            ]
        });
    };

    $(function () {
        DataTableGenerate();
        loadDropdownData();
    });

    
    function loadDropdownData() {
        // Türler
        $.ajax({
            url: "/AdminPanel/Dizi/GetTurler",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $("#filmTurleriSelect").empty();
                if (data.data) {
                    $.each(data.data, function (index, item) {
                        $("#filmTurleriSelect").append('<option value="' + item.id + '">' + item.turAdi + '</option>');
                    });
                } 
                // Select2 varsa trigger et
                if ($.fn.select2) {
                    $("#filmTurleriSelect").trigger("change");
                }
            },
            error: function (xhr, status, error) {
                
            }
        });

        // Diller
        $.ajax({
            url: "/AdminPanel/Dizi/GetDiller",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $("#DilId").empty();
                if (data.data) {
                    $.each(data.data, function (index, item) {
                        $("#DilId").append('<option value="' + item.id + '">' + item.dilAdi + '</option>');
                    });
                } 
                
                if ($.fn.select2) {
                    $("#DilId").trigger("change");
                }
            },
            error: function (xhr, status, error) {
               
            }
        });

        // Platformlar
        $.ajax({
            url: "/AdminPanel/Dizi/GetPlatformlar",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $("#PlatformId").empty();
                if (data.data) {
                    $.each(data.data, function (index, item) {
                        $("#PlatformId").append('<option value="' + item.id + '">' + item.platformAdi + '</option>');
                    });
                } 
               
                if ($.fn.select2) {
                    $("#PlatformId").trigger("change");
                }
            },
            error: function (xhr, status, error) {
                
            }
        });

        // Yönetmenler
        $.ajax({
            url: "/AdminPanel/Dizi/GetYonetmenler",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $("#Yonetmenler").empty();
                if (data.data) {
                    $.each(data.data, function (index, item) {
                        $("#Yonetmenler").append('<option value="' + item.id + '">' + item.adi + '</option>');
                    });
                } 
               
                if ($.fn.select2) {
                    $("#Yonetmenler").trigger("change");
                }
            },
            error: function (xhr, status, error) {
                
            }
        });

        // Oyuncular
        $.ajax({
            url: "/AdminPanel/Dizi/GetOyuncular",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $("#Oyuncular").empty();
                if (data.data) {
                    $.each(data.data, function (index, item) {
                        $("#Oyuncular").append('<option value="' + item.id + '">' + item.adi + '</option>');
                    });
                } else {
                  
                }
                
                if ($.fn.select2) {
                    $("#Oyuncular").trigger("change");
                }
            },
            error: function (xhr, status, error) {
               
            }
        });

    
        loadUpdateFormDropdowns();
    }

    
    function loadUpdateFormDropdowns() {
        // Türler (Güncelleme formu)
        $.ajax({
            url: "/AdminPanel/Dizi/GetTurler",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $("#GTurler").empty();
                if (data.data) {
                    $.each(data.data, function (index, item) {
                        $("#GTurler").append('<option value="' + item.id + '">' + item.turAdi + '</option>');
                    });
                }
                // Select2 varsa trigger et
                if ($.fn.select2) {
                    $("#GTurler").trigger("change");
                }
            }
        });

        // Diller (Güncelleme formu)
        $.ajax({
            url: "/AdminPanel/Dizi/GetDiller",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $("#GDilId").empty();
                if (data.data) {
                    $.each(data.data, function (index, item) {
                        $("#GDilId").append('<option value="' + item.id + '">' + item.dilAdi + '</option>');
                    });
                }
                // Select2 varsa trigger et
                if ($.fn.select2) {
                    $("#GDilId").trigger("change");
                }
            }
        });

        // Platformlar (Güncelleme formu)
        $.ajax({
            url: "/AdminPanel/Dizi/GetPlatformlar",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $("#GPlatformId").empty();
                if (data.data) {
                    $.each(data.data, function (index, item) {
                        $("#GPlatformId").append('<option value="' + item.id + '">' + item.platformAdi + '</option>');
                    });
                }
                // Select2 varsa trigger et
                if ($.fn.select2) {
                    $("#GPlatformId").trigger("change");
                }
            }
        });

        // Yönetmenler (Güncelleme formu)
        $.ajax({
            url: "/AdminPanel/Dizi/GetYonetmenler",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $("#GYonetmenler").empty();
                if (data.data) {
                    $.each(data.data, function (index, item) {
                        $("#GYonetmenler").append('<option value="' + item.id + '">' + item.adi + '</option>');
                    });
                }
                // Select2 varsa trigger et
                if ($.fn.select2) {
                    $("#GYonetmenler").trigger("change");
                }
            }
        });

        // Oyuncular (Güncelleme formu)
        $.ajax({
            url: "/AdminPanel/Dizi/GetOyuncular",
            type: "GET",
            dataType: "json",
            success: function (data) {
                $("#GOyuncular").empty();
                if (data.data) {
                    $.each(data.data, function (index, item) {
                        $("#GOyuncular").append('<option value="' + item.id + '">' + item.adi + '</option>');
                    });
                }
                // Select2 varsa trigger et
                if ($.fn.select2) {
                    $("#GOyuncular").trigger("change");
                }
            }
        });
    }

    // Dizi Ekleme İşlemi
    $("#btnDiziKaydet").click(function () {
        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        var formData = new FormData();
        var DiziAdi = $("#adi").val();
        var Aciklama = $("#aciklama").val();
        var Turler = $("#turler").val();
        var DilId = $("#DilId").val();
        var PlatformId = $("#PlatformId").val();
        var BaslamaTarihi = $("#baslamaTarihi").val();
        var BitisTarihi = $("#bitisTarihi").val();
        var SezonSayisi = $("#sezonSayisi").val();
        var BolumSayisi = $("#bolumSayisi").val();
        var Yonetmenler = $("#Yonetmenler").val();
        var Oyuncular = $("#Oyuncular").val();

        formData.append("adi", DiziAdi);
        formData.append("aciklama", Aciklama);
        formData.append("turler", Turler);
        formData.append("dilId", DilId);
        formData.append("platformId", PlatformId);
        formData.append("baslamaTarihi", BaslamaTarihi);
        formData.append("bitisTarihi", BitisTarihi);
        formData.append("sezonSayisi", SezonSayisi);
        formData.append("bolumSayisi", BolumSayisi);

        if (Yonetmenler) {
            for (var i = 0; i < Yonetmenler.length; i++) {
                formData.append("yonetmenIds[]", Yonetmenler[i]);
            }
        }

        if (Oyuncular) {
            for (var i = 0; i < Oyuncular.length; i++) {
                formData.append("oyuncuIds[]", Oyuncular[i]);
            }
        }

        $.ajax({
            url: "/AdminPanel/Dizi/DiziEkle",
            type: "post",
            dataType: "json",
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                $("#frmDiziEkle")[0].reset();
                $("#modalDiziEkle").modal("hide");
                $("#tblDizi").DataTable().destroy();
                DataTableGenerate();
                swal.close();

                if (response.result) {
                    Swal.fire({
                        title: "BAŞARILI",
                        text: response.mesaj,
                        icon: "success"
                    });
                } else {
                    Swal.fire({
                        title: "HATA",
                        text: response.mesaj || "Bir hata oluştu",
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

    $(document).on('change', '.form-check-input', function () {
        var swal = Swal.fire({
            title: "LÜTFEN BEKLEYİNİZ...",
            html: "İşleminiz Yapılıyor",
            timerProgressBar: true,
            didOpen: () => {
                Swal.showLoading();
            },
        });

        var id = $(this).attr('diziid');
        var aktifpasif = $(this).is(':checked');

        $.ajax({
            url: "/AdminPanel/Dizi/AktifPasif",
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

    function afisiBuyut(afisUrl, diziAdi) {
        Swal.fire({
            title: diziAdi,
            imageUrl: afisUrl,
            imageWidth: 800,
            imageHeight: 'auto',
            imageAlt: diziAdi + ' Afişi',
            showCloseButton: true,
            confirmButtonText: 'Kapat',
            customClass: {
                image: 'img-fluid'
            }
        });
    }

    // Düzenleme butonuna tıklandığında
    $(document).on('click', '.btnDuzenle', function () {
        var diziid = $(this).attr('diziid');
        $('#modalDiziGuncelle').modal('show');
        
        // Dizi bilgilerini getir
        $.ajax({
            url: '/AdminPanel/Dizi/GetDiziById',
            type: 'GET',
            data: { id: diziid },
            success: function (response) {
                if (response.result) {
                    var dizi = response.data;
                    
                    // Form alanlarını doldur
                    $('#GAdi').val(dizi.adi);
                    $('#GAciklama').val(dizi.aciklama);
                    $('#GBaslamaTarihi').val(dizi.baslamaTarihi);
                    $('#GBitisTarihi').val(dizi.bitisTarihi);
                    $('#GSezonSayisi').val(dizi.sezonSayisi);
                    $('#GBolumSayisi').val(dizi.bolumSayisi);
                    $('#GDilId').val(dizi.dilId);
                    $('#GPlatformId').val(dizi.platformId);
                    
                    // Dizi ID'sini gizli alana ekle
                    $('#frmDiziGuncelle').append('<input type="hidden" id="GId" name="id" value="' + diziid + '">');
                    
                    // Yönetmen ve oyuncuları seç
                    if (dizi.yonetmenler && dizi.yonetmenler.length > 0) {
                        $('#GYonetmenler').val(dizi.yonetmenler).trigger('change');
                    }
                    
                    if (dizi.oyuncular && dizi.oyuncular.length > 0) {
                        $('#GOyuncular').val(dizi.oyuncular).trigger('change');
                    }
                } else {
                    Swal.fire({
                        title: "HATA",
                        text: response.mesaj || "Dizi bilgileri alınamadı.",
                        icon: "error"
                    });
                }
            },
            error: function () {
                Swal.fire({
                    title: "HATA",
                    text: "Dizi bilgileri alınırken bir hata oluştu.",
                    icon: "error"
                });
            }
        });
    });

 

});
$(document).on('click', '#btnTmdbAra', function () {
    const query = $('input[name="Adi"]').val();
    if (!query) {
        Swal.fire({
            title: "Uyarı",
            text: "Lütfen dizi adını giriniz.",
            icon: "warning"
        });
        return;
    }

    $('#tmdbSonuclar').html('<div class="text-center"><div class="spinner-border text-primary" role="status"><span class="visually-hidden">Yükleniyor...</span></div></div>');

    $.ajax({
        url: "/AdminPanel/Dizi/SearchTMDB",
        type: "GET",
        data: { query: query },
        success: function (response) {
            if (!response.data || response.data.length === 0) {
                $('#tmdbSonuclar').html('<div class="alert alert-warning">Sonuç bulunamadı.</div>');
                return;
            }

            let html = '<div class="row">';
            response.data.forEach(d => {
                const posterUrl = d.poster_path ? 
                    `https://image.tmdb.org/t/p/w200${d.poster_path}` : 
                    '/adminassets/images/no-poster.jpg';
                
                html += `
                    <div class="col-md-4 mb-3">
                        <div class="card h-100 tmdb-item" data-id="${d.id}" style="cursor:pointer;">
                            <img src="${posterUrl}" class="card-img-top" alt="${d.name}">
                            <div class="card-body">
                                <h6 class="card-title">${d.name}</h6>
                                <p class="card-text small text-muted">
                                    ${d.first_air_date ? new Date(d.first_air_date).getFullYear() : 'Tarih belirtilmemiş'}
                                </p>
                            </div>
                        </div>
                    </div>`;
            });
            html += '</div>';

            $('#tmdbSonuclar').html(html);
        },
        error: function (xhr, status, error) {
            Swal.fire({
                title: "Hata",
                text: "TMDB araması sırasında bir hata oluştu.",
                icon: "error"
            });
        }
    });
});

$(document).on('click', '.tmdb-item', function () {
    const id = $(this).data('id');
    
    Swal.fire({
        title: "Lütfen Bekleyiniz",
        text: "Dizi bilgileri alınıyor...",
        allowOutsideClick: false,
        didOpen: () => {
            Swal.showLoading();
        }
    });

    $.ajax({
        url: "/AdminPanel/Dizi/GetTMDBDetails",
        type: "GET",
        data: { id: id },
        success: function (response) {
            if (response.result && response.data) {
                const d = response.data;
                $('input[name="Adi"]').val(d.name);
                $('input[name="BaslamaTarihi"]').val(d.first_air_date);
                $('input[name="SezonSayisi"]').val(d.number_of_seasons);
                $('input[name="BolumSayisi"]').val(d.number_of_episodes);
                $('textarea[name="Aciklama"]').val(d.overview);

                Swal.fire({
                    title: "Başarılı",
                    text: `${d.name} bilgileri otomatik dolduruldu.`,
                    icon: "success"
                });
            } else {
                Swal.fire({
                    title: "Hata",
                    text: "Dizi bilgileri alınamadı.",
                    icon: "error"
                });
            }
        },
        error: function () {
            Swal.fire({
                title: "Hata",
                text: "Dizi bilgileri alınırken bir hata oluştu.",
                icon: "error"
            });
        }
    });
});
