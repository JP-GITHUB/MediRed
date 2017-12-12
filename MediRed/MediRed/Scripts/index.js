function Modal1() {
    var htmlload = "<div class='modal fade' id='ModalLoading' role='dialog'><div class='modal-dialog'>";
    htmlload = htmlload + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>x</span></button>";
    htmlload = htmlload + "<div class='modal-content'><div class='modal-body' style='padding:40px 50px; text-align: center; clear: left;'>";
    htmlload = htmlload + "<div class='panel panel-default'>";
    htmlload = htmlload + "<div class='panel-heading'><h3 class='panel-title'>MediRed</h3></div>";
    htmlload = htmlload + "<div class='panel-body'>";
    htmlload = htmlload + "<h1><div class='spinner spinner-lg spinner-inline'></div>" + mensaje + "</h1>";
    htmlload = htmlload + "</div></div></div></div>";
    htmlload = htmlload + "</div></div>";
}



//Cargar Modal
var Mensajeria = {
    Exito: function (mensaje) {
        $("#mensajes").html("");
        var htmlAlert = "<div class='alert alert-success alert-dismissable'>";
        htmlAlert = htmlAlert + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>x</span></button>";
        htmlAlert = htmlAlert + "<span class='pficon pficon-close'></span></button>";
        htmlAlert = htmlAlert + "<span class='pficon pficon-ok'></span>";
        htmlAlert = htmlAlert + "<strong></strong>" + mensaje;
        htmlAlert = htmlAlert + "</div>";

        $("#mensajes").append(htmlAlert);
        $("#mensajes").focus();
    },
    Advertencia: function (mensaje) {
        $("#mensajes").html("");
        var htmlAlert = "<div class='alert alert-danger alert-dismissable'>";
        htmlAlert = htmlAlert + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>x</span></button>";
        htmlAlert = htmlAlert + "<span class='pficon pficon-close'></span></button>";
        htmlAlert = htmlAlert + "<span class='pficon pficon-error-circle-o'></span>";
        htmlAlert = htmlAlert + "<strong></strong>" + mensaje;
        htmlAlert = htmlAlert + "</div>";

        $("#mensajes").append(htmlAlert);
        $("#mensajes").focus();
    },

    CargardoInicio: function (mensaje) {
        var htmlload = "<div class='modal fade' id='ModalLoading' role='dialog'><div class='modal-dialog'>";        
        htmlload = htmlload + "<div class='modal-content'><div class='modal-body' style='padding:40px 50px; text-align: center; clear: left;'>";
        htmlload = htmlload + "<div class='panel panel-default'>";
        htmlload = htmlload + "<div class='panel-heading'><h3 class='panel-title'>MediRed</h3></div>";
        htmlload = htmlload + "<div class='panel-body'>";
        htmlload = htmlload + "<h1><div class='spinner spinner-lg spinner-inline'></div>" + mensaje + "</h1>";
        htmlload = htmlload + "</div></div></div></div>";
        htmlload = htmlload + "<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>x</span></button>";
        htmlload = htmlload + "</div></div>";

        $("#cargando").html(htmlload);
        $("#ModalLoading").modal({ backdrop: 'static', keyboard: false });
        return false;
    },

    CargardoFin: function () {
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
        $("#ModalLoading").modal("hide");
        $("#ModalLoading").remove();

        $(".modal").each(function () {
            $(this).modal("hide");
            $(this).removeClass('in')
            $(this).attr('aria-hidden', true)
            $(this).off('click.dismiss.modal');
            $(this).hide();
            $(this).remove();
        });

        $("#cargando").html("");
        return false;
    },
}