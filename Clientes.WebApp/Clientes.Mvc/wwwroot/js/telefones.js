$(document).ready(function () {

    $('#tabela-telefones').find('input[name*="NumeroTelefone"]').mask('(00) 00000-0000');

    $(document).on('focus', 'input[name*="NumeroTelefone"]', function () {
        $(this).mask('(00) 00000-0000');
    });

    let contador = 0;

    $("#btn-add-telefone").click(function () {
        let $clone = $("#template-telefone").clone();
        $clone.removeAttr("id").show();


        $clone.find("input, select").each(function () {
            let name = $(this).attr("name");
            name = name.replace(/\d+/, contador);
            $(this).attr("name", name);
        });

        $("#tabela-telefones tbody").append($clone);

        carregarTiposTelefone($clone.find(".tipo-telefone"));
        contador++;
    });

    $(document).on("click", ".btn-remove-telefone", function () {
        $(this).closest("tr").remove();
        let numero = $(this).closest("tr").find("input[name*='NumeroTelefone']").val();
        $.ajax({
            url: window.apiBaseUrl + "/telefone/" + numero,
            method: 'DELETE',
            success: function (data) {
                alert("Telefone excluido com sucesso");
            },
            error: function (err) {
                console.error('Erro ao excluir telefone', err);
            }
        });
    });

    function carregarTiposTelefone(selectElement, valorSelecionado = null) {
        $.ajax({
            url: window.apiBaseUrl + "/telefone/tipos-telefone",
            method: 'GET',
            success: function (data) {
                $(selectElement).empty();
                data.forEach(function (tipo) {
                    $(selectElement).append(
                        $('<option>', {
                            value: tipo.codigoTipoTelefone,
                            text: tipo.descricao,
                            selected: tipo.codigoTipoTelefone === valorSelecionado
                        })
                    );
                });
            },
            error: function (err) {
                console.error('Erro ao carregar tipos de telefone', err);
            }
        });
    }

    $(".tipo-telefone").each(function () {
        let valorSelecionado = $(this).data("selected");
        carregarTiposTelefone(this, valorSelecionado);
    });
});
