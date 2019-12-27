$('.create_token').click(function () {
    var signing_key = $('.signing_key').val(),
        valid_issuer = $('.valid_issuer').val(),
        valid_audience = $('.valid_audience').val();
    var data = { 'signingkey': signing_key, 'validissuer': valid_issuer, 'validaudience': valid_audience };
    var dataEdited = JSON.stringify(data);
    $.ajax({
        type: 'POST', url: '/api/TokenApi', data: dataEdited, success: function (result) {
            $('#bearer_div').hide();
            $('#bearer_div_error').hide();
            if (result.isValid) {
                if ($('#bearer_div').is(':hidden')) {
                    $('#bearer_div').show();
                }
                $('.bearer_token').text('');
                $('.bearer_token').text(result.accessToken);
            } else {
                if ($('#bearer_div_error').is(':hidden')) {
                    $('#bearer_div_error').show();
                }
                $('.error_token').text('');
                $('.error_token').text(result.errorMessage);
            }
        }, contentType: 'application/json'
    });
});