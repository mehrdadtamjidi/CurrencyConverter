$(document).ready(function () {

});

function ShowModalSabt() {
    $.ajax({
        url: "/ConversionRate/Add",
        method: "GET",
        dataType: "html",
        success: function (data) {
            $('#ConversionRateModalbody').html(data);
            $('#ConversionRateModal').modal();
            $('#Title').text('Add ConversionRate');
            //Enable Validate in Partial
            reparseform();
        },
        error: function () {

        },
        beforeSend: function () {

        }
    });

}

function ShowModalEdit(Id) {
    $.ajax({
        url: "/ConversionRate/Edit",
        type: "GET",
        dataType: "html",
        data: {
            Id: Id
        },
        success: function (data) {
            $('#ConversionRateModalbody').html(data);
            $('#ConversionRateModal').modal();
            $('#Title').text('Edit ConversionRate');
            //Enable Validate in Partial
            reparseform();
        },
        error: function () {

        },
        beforeSend: function () {

        }
    });

}

function Delete(Id) {
    title = 'Warning'
    text = 'Are you sure you want to delete it?';
    $.confirm({
        icon: 'fa fa-warning',
        type: 'red',
        title: title,
        content: text,
        closeIcon: true,
        rtl: true,
        buttons: {
            ok: {
                text: "Confirm",
                keys: ['enter'], // کليد صفحه کليد براي اين دکمه
                btnClass: 'btn-danger',
                action: function () {
                    $.ajax({
                        type: "POST",
                        url: '/ConversionRate/Delete',
                        data: {
                            Id: Id
                        },
                        success: function (data) {
                            if (data.Status) {
                                toastr.success("The information was successfully deleted", "Message");
                                setTimeout(function () {
                                    location.reload();
                                }, 2000);
                            }
                        else {
                             toastr.error('An error occurred', 'Message');
                         }
                        },
                        error: function () {
                            toastr.error('Failed', 'Message');
                        }
                    })
                }
            },
            cancel: {
                text: "Cancel",
                keys: ['esc'],
                action: function () {
                }
            }
        }
    });

}

function GetToken() {
    return $('input:hidden[name="__RequestVerificationToken"]').val();
}

$(document).on('click', '#btnAddConversionRate', function () {
        var form = $("#frmAddConversionRate");
        if (!form.valid())
            return;

        $.ajax({
        url: "/ConversionRate/Add",
        method: "POST",
        data: form.serialize(),
        headers: { 'X-XSRF-TOKEN-LoanFund': GetToken() },
        success: function (data) {
            if (data.status) {
                $('#ConversionRateModal').modal('hide');
                toastr.success("date insert", "Message");
                setTimeout(function () {
                    location.reload();
                }, 2000);
            } else {
                toastr.error('date error', 'Message');
            }
        },
        error: function () {

        },
        beforeSend: function () {

        }
    });
    console.log(frmAddConversionRate);
});

$(document).on('click', '#btnEditConversionRate', function () {
    var form = $("#frmEditConversionRate");
    if (!form.valid())
        return;

    $.ajax({
        url: "/ConversionRate/Edit",
        method: "POST",
        data: form.serialize(),
        headers: { 'X-XSRF-TOKEN-LoanFund': GetToken() },
        success: function (data) {
            if (data.status) {
                $('#ConversionRateModal').modal('hide');
                toastr.success("date edit", "Message");
                setTimeout(function () {
                    location.reload();
                }, 2000);
            } else {
                toastr.error('date error', 'Message');
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
