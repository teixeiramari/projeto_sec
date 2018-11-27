$('#anexarPref').on('click', function () {
    $('#modalPreferencia').modal('show');
});
$('#addPref').on('click', function () {
    $('#AdicionarPref').modal('show');
});
$('.close-pref').on('click', function () {
    var pref = parseInt($(this).attr('ref'));
    $(this).parent().remove();
    $.ajax({
        type: 'POST',
        url: baseUrl + 'Inicio/ExcluirPrefencia',
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: JSON.stringify({ "pref": pref }),
        success: function (data) {
          
            console.log(data);
        },
        error: function (error) { console.log(error); }
    }).fail(function (error) { console.log(error); });
});
