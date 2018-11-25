$(function () {
    $(".form-validate").validate({
        errorPlacement: function(error, element)
        {
            error.insertAfter(element);
        }
    });
    $(".form-validate-signin").validate({
        errorPlacement: function(error, element)
        {
            error.insertAfter(element);
        }
    });
    $(".form-validate-signup").validate({
        rules: {
            age: {
                range: [0,100]
            }
        },
        errorPlacement: function(error, element)
        {
            error.insertAfter(element);
        }
    });

});

$(document).ready(function() {
    $.extend(jQuery.validator.messages, {
        required: "Este campo es requerido.",
        remote: "Por favor arregla este campo.",
        email: "Por favor, introduce una dirección de correo electrónico válida.",
        url: "Por favor introduzca un URL válido.",
        date: "Por favor introduzca una fecha valida.",
        dateISO: "Por favor ingrese una fecha válida (ISO) s.",
        number: "Por favor ingrese un número valido.",
        digits: "Por favor ingrese solo dígitos.",
        creditcard: "Por favor, introduzca un número de tarjeta de crédito válida.",
        equalTo: "Ingrese los mismos valores.",
        accept: "Por favor ingrese un valor con una extensión válida.",
        maxlength: $.validator.format("Ingrese no más de {0} caracteres."),
        minlength: $.validator.format("Por favor ingrese al menos {0} caracteres."),
        rangelength: $.validator.format("Por favor, introduzca un valor entre {0} y {1} caracteres de longitud."),
        range: $.validator.format("Ingrese un valor entre {0} y {1} caracteres de longitud."),
        max: $.validator.format("Ingrese un valor entre {0} y {1}."),
        min: $.validator.format("Ingrese un valor mayor o igual que {0}.")
    });
});


$.datepicker.regional['es'] = {
 closeText: 'Close',
 prevText: '<Ant',
 nextText: 'Sig>',
 currentText: 'Hoy',
 monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
 monthNamesShort: ['Jan','Feb','Mar','Apr', 'May','Jun','Jul','Aug','Sep', 'Oct','Nov','Dic'],
 dayNames: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'],
 dayNamesShort: ['Sun','Mon','Tue','Wed','Thu','Fri','Sat'],
 dayNamesMin: ['Su','Mo','Tu','We','Th','Fr','Sa'],
 weekHeader: 'Sm',
 dateFormat: 'dd/mm/yy',
 firstDay: 1,
 isRTL: false,
 showMonthAfterYear: false,
 yearSuffix: ''
 };
 $.datepicker.setDefaults($.datepicker.regional['es']);
$(function () {
$("#fecha").datepicker();
});