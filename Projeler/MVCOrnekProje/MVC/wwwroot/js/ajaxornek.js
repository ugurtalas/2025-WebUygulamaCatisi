$(function () {

    $(document).delegate(".VeriGonder", "click", function () {
        Veri = { Ad : "İkra", Soyad:"TALAŞ" }
        $.ajax({
            url: "/request/AjaxModelAl",
            type: "post",
            data: Veri,
            ContentType: "html",
            success: function (result) {
                alert("Veriler Başaıyla Gönderildi");
            }
        });
        
    });


    $(document).delegate(".VeriAl", "click", function () {
     
        $.ajax({
            url: "/request/AjaxModelGetir",
            type: "post",
           
            ContentType: "html",
            success: function (result) {

                var Cevap = JSON.p
                arse(result);
                alert(Cevap.Ad);
            }
        });

    });



});