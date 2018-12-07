$('#buscaUsuario').on('keyup', function () {
    FiltrarAmigo();
    FiltrarOutros() 
});
function FiltrarAmigo() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscaUsuario");
    filter = input.value.toUpperCase();
    table = document.getElementById("tabelaAmigo");
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
function FiltrarOutros() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("buscaUsuario");
    filter = input.value.toUpperCase();
    table = document.getElementById("tabelaOutros");
    tr = table.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}