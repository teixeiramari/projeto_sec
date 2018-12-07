$('#addMsg').on('click', function () {
    var msg = $('#textoChat').val();
    var select = parseInt($('#slcAmigo').val());

    if (msg === null || msg === "") {
        alert("Digite o texto!");
    }
    else if (select <= 0 || isNaN(select)) {
        alert("Selecione um usuário para o chat!");
    }
    else {
        var html = '';
        html += '<div class="caixaTotal" style="display: block"><div class="caixaChat">' + msg + '</div><img src="' + baseUrl + 'Content/Imagens/user-circle-solid.svg" style="width: 30px; height: 30px;" /></div>';
        $('.chamadas').append(html);
        $('#textoChat').val("");
        event.stopPropagation();
    }
});
$('.ligar').on('click', function () {
    $('#exampleModal').modal('show');
});