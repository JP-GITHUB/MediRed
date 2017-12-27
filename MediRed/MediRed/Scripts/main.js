$(function () {
    $(".validate-rut").change(function () {
        $(this).val($(this).val().replace(/[^a-zA-Z 0-9-]+/g, ''));

        if ($(this).val() != "") {
            if (!checkRut($(this).val())) {
                $("input[type=submit]").attr("disabled", true);
                $(".validation-summary-valid ul").append("<li class='li-invalid-rut'>" + "El rut ingresado es inválido" + "</li>");
                $(".msg-validate-rut").html("* El rut ingresado es inválido");
            } else {
                $("input[type=submit]").attr("disabled", false);
                $(".msg-validate-rut").html("");
                $(".li-invalid-rut").remove();
            }
        } else {
            $("input[type=submit]").attr("disabled", false);
            $(".msg-validate-rut").html("");
            $(".li-invalid-rut").remove();
        }
    });
});