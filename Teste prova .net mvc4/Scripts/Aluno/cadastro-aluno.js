function inicio() {
    $(document).ready(function () {
        cadastroAluno.init();        
    });
}



var cadastroAluno = {

    init: function () {
        cadastroAluno.bind();
        cadastroAluno.mask();
    },

    bind: function () {
        $('#bt-salvar').on("click", function () {
            cadastroAluno.salvar();
        })
    },

    mask: function () {
        $('#id-cpf').mask('999.999.999-99');
        $('#id-rg').mask('99-999-999-9');
        $('#id-dtNasc').mask('00/00/0000');
    },

    recuperarDados: function(){
        var dados = {
            Nome: $('#id-nome').val(),
            Cpf: $('#id-cpf').val(),
            Rg: $('#id-rg').val(),
            DtNasc: $('#id-dtNasc').val(),
            Curso: 1
        }        
        return dados;
    },

    valid: function () {        
        var dados = this.recuperarDados();
        var valido = true;        
        if (dados.Nome.length < 5) {
            alert("nome deve contem pelo menos 5 caracteres!");
            valido = false;
        }
        if (dados.Cpf == "") { alert("cpf invalido"); valido = false; }
        if (dados.Rg == "") { alert("rg invalido"); valido = false;}
        var dia = parseInt(dados.DtNasc.substring(0, 2));        
        var mes = parseInt(dados.DtNasc.substring(3, 5));
        var ano = parseInt(dados.DtNasc.substring(6, 14));        
        if (dia < 0 || dia > 31) {
            alert("dia invalido!");
            return false;
        }
        if (mes < 1 || mes > 12) {
            alert("mes invalido");
            return false;
        }
        if (ano < 1910) {
            alert("ano invalido");
            return false;
        }
        alert(""+valido);
        return valido;
    },

    salvar: function () {

        $.ajax({
            type: "POST",
            dataType: "JSON",
            url: "http://localhost:52574/Aluno/Salvar",
            data: { dadosAluno: JSON.stringify(cadastroAluno.recuperarDados()), dtNasc: $('#id-dtNasc').val() },
            async: false,
            success: function (response) {
                if (response)
                    alert("sucesso");
                else
                    alert("problema");
            },
            failure: function (msg, status) {
                alert("failure");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }            
        });       
    }
};