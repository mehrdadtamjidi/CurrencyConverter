$(document).ready(function () {

});


function GetToken() {
    return $('input:hidden[name="__RequestVerificationToken"]').val();
}

$(document).on('click', '#btnConvert', function () {

    var fromCurrency = $("#FromCurrencyId option:selected").text();
    var toCurrency = $("#ToCurrencyId option:selected").text();
    var amount = $("#Amount").val();
    var form = $("#frmCurrencyConverter");
        if (!form.valid())
            return;
        $.ajax({
            url: "/CurrencyConverter/Convert",
        method: "POST",
        data: form.serialize(),
        headers: { 'X-XSRF-TOKEN-LoanFund': GetToken() },
        success: function (data) {
            if (data.FinalAmount > 0) {
                $('#fromCurrencyres').text(amount + ' ' + fromCurrency + ' =');
                $('#toCurrencyres').text(data.FinalAmount + ' ' + toCurrency);
                $('#PathCurrency').text("("+ data.Path + ")");
            } else {
                $('#fromCurrencyres').text(amount + ' ' + fromCurrency + ' =');
                $('#toCurrencyres').text(0);
                $('#PathCurrency').text("(No path found)");
                toastr.error('No path found', 'Message');
            }
        },
        error: function () {

        },
        beforeSend: function () {

        }
    });
});

function reparseform() {
    $("form").removeData("validator");
    $("form").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse("form");
}
