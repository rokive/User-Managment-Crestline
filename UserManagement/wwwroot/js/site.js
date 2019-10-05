// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('#Answer').keyup(function () {
        userNameAndAnswerSame();
    });
    $('#UserName').keyup(function () {
        userNameAndAnswerSame();
        $('.error').text('');
    });
    function userNameAndAnswerSame() {
        var userName = $('#UserName').val();
        var answer = $('#Answer').val();
        if (userName.trim() == answer.trim()) {
            $('span[data-valmsg-for="Answer"]').addClass('field-validation-error').text('Security answer and user name same');
            $("#btnSubmit").attr("disabled", "disabled");
        }
        else {
            $("#btnSubmit").removeAttr("disabled");
            $('span[data-valmsg-for="Answer"]').removeClass('field-validation-error').html('');
        }
    }
});