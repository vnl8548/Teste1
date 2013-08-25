function inicio() {
    $(document).ready(function () {        
        buscaAluno.init();                
    });
}

var buscaAluno = {

    init: function () {
        buscaAluno.bind();
        buscaAluno.mask();
    },

    bind: function () {
        $('#id-select').change( function () {            
            $('#id-palavra').val('');
            buscaAluno.mask();
        })
        $('#bt-busca').on('click', function () {
            if (buscaAluno.valid() == true) {
                buscaAluno.busca();
            }
        })
    },

    mask: function () {        
        var selecionado = $('#id-select').val();        
        if (selecionado == "cpf") {            
            $('#id-palavra').mask('999.999.999-99');
        }
        if (selecionado == "rg") {
            $('#id-palavra').mask('99-999-999-9');
        }
    },

    valid: function(){
        var valido = true;
        if ($('#id-palavra').val().length < 3) {
            valido = false;
        }
        return valido;
    },

    busca: function () {
        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "http://localhost:52574/Aluno/FazBusca",
            data: { palavraChave: $('#id-palavra').val(), filtro: $('#id-select').val() },
            async: false,
            success: function (response) {
                if (response != null) {
                    alert("Busca concluida");
                    buscaAluno.preencheTabela(response);
                }
                else {
                    alert("problema");
                }
            },
            failure: function (msg, status) {
                alert("failure");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        });
    },

    preencheTabela: function (dados) {
        $('td').replaceWith('');
        var json = jQuery.parseJSON(dados);
        for (i = 0; i < json.Alunos.length; i++) {                        
            $('table').append('<tr>'
             +'           <td>'+json.Alunos[i].Id+'</td>'
             +'           <td>'+json.Alunos[i].Nome+'</td>'
             +'           <td>'+json.Alunos[i].Cpf+'</td>'
             +'       </tr>'
            );
        }
    }
};