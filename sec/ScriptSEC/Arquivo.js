$('#addPreferencia').on('click', function () {
    var nomePref = $('#txtPreferencia').val();
    $.ajax({
        type: 'POST',
        url: baseUrl + 'FileUpload/AddPreferencia',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify({ "nome": nomePref }),
        success: function (resp) {
            if (resp === null) {
                alert("Digite o nome!");
            }
            else {
                var html = '';
                html += ' <div class="form-check form-check-inline">';
                html += '<input class="form-check-input" type="checkbox" name="Prefs" value="' + resp.Id + '">';
                html += '<label class="form-check-label">' + resp.Descricao + '</label>';
                html += '</div>';
                $('.DivPreferencias').append(html);
                $('#txtPreferencia').val("");
            }

        },
        error: function (error) { console.log(error); }
    }).fail(function (error) { console.log(error); });
});