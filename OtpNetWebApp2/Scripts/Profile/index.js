// => Apresenta dialog caso o cliente selecionado esteja bloqueado
function VerifCliente(element, url, reload) {

    if (typeof reload == "undefined") {
        reload = false;
    }

    var val = false;
    $.ajax({
        url: url,
        type: "POST",
        data: $(element).serialize(),
        async: false,
        context: val,
        success: function (retorno) {            
            val = false;

            switch (retorno) {
                case 1:
                    $('#stepform').attr('action', "https://localhost:44326/Step/Step1");
                    val = true;
                    break;                
                case 8:
                    $('#stepform').attr('action', "https://localhost:44326/Profile/Error");
                    val = true;
                    break;
            }
        },
        complete: function () {

        }
    });

    return val;
}