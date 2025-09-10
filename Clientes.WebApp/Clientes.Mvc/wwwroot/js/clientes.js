$(document).ready(function () {
    // Create Cliente
    $("#form-create-cliente").submit(function (e) {
        e.preventDefault();

        let cliente = {
            razaoSocial: $("#RazaoSocial").val(),
            nomeFantasia: $("#NomeFantasia").val(),
            tipoPessoa: $("#TipoPessoa").val(),
            documento: $("#Documento").val(),
            endereco: $("#Endereco").val(),
            complemento: $("#Complemento").val(),
            bairro: $("#Bairro").val(),
            cidade: $("#Cidade").val(),
            uf: $("#UF").val(),
            cep: $("#CEP").val(),
            usuarioInsercao: "admin",
            telefones: []
        };

        $("#tabela-telefones tbody tr").each(function () {
            let numero = $(this).find("input[name*='.Numero']").val();
            let operadora = $(this).find("input[name*='.Operadora']").val();
            let codigoTipoTelefone = $(this).find("select.tipo-telefone").val();

            if (numero && codigoTipoTelefone) {
                cliente.telefones.push({
                    numeroTelefone: numero,
                    codigoTipoTelefone: codigoTipoTelefone,
                    operadora: operadora
                });
            }
        });

        $.ajax({
            url: window.apiBaseUrl + "/clientes",
            method: "POST",
            data: JSON.stringify(cliente),
            contentType: "application/json",
            success: function () {
                alert("Cliente cadastrado com sucesso!");
                window.location.href = "/Clientes/Index";
            },
            error: function (xhr) {
                console.error(xhr.responseText);
                alert("Erro: " + xhr.status + " - " + xhr.responseText);
            }
        });
    });

    // Edit Cliente
    $("#form-edit-cliente").submit(function (e) {
        e.preventDefault();

        let clienteId = $("#CodigoCliente").val();

        let cliente = {
            codigoCliente: clienteId,
            razaoSocial: $("#RazaoSocial").val(),
            nomeFantasia: $("#NomeFantasia").val(),
            tipoPessoa: $("#TipoPessoa").val(),
            documento: $("#Documento").val(),
            endereco: $("#Endereco").val(),
            complemento: $("#Complemento").val(),
            bairro: $("#Bairro").val(),
            cidade: $("#Cidade").val(),
            uf: $("#UF").val(),
            cep: $("#CEP").val(),
            telefones: []
        };

        $("#tabela-telefones tbody tr").each(function () {
            let numero = $(this).find("input[name*='.Numero']").val();
            let operadora = $(this).find("input[name*='.Operadora']").val();
            let codigoTipoTelefone = $(this).find("select.tipo-telefone").val();
            let codigoTelefone = $(this).find("input[name*='.CodigoTelefone']").val();

            if (numero && codigoTipoTelefone) {
                let telefone = {
                    numeroTelefone: numero,
                    codigoTipoTelefone: codigoTipoTelefone,
                    operadora: operadora
                };


                if (codigoTelefone) {
                    telefone.codigoTelefone = codigoTelefone;
                }

                cliente.telefones.push(telefone);
            }
        });

        console.log("Cliente a ser atualizado:", cliente);
        let requestUrl = window.apiBaseUrl + "/clientes/" + clienteId;
        $.ajax({
            url: requestUrl,
            method: "PUT",
            data: JSON.stringify(cliente),
            contentType: "application/json",
            success: function () {
                alert("Cliente atualizado com sucesso!");
                window.location.href = "/Clientes/Index";
            },
            error: function (xhr) {
                console.error(xhr.responseText);
                console.log("UrlRequisicao", requestUrl)
                alert("Erro: " + xhr.status + " - " + xhr.responseText);
            }
        });
    });

    $('.btn-excluir-ajax').on('click', function () {
        const clienteId = $(this).data('id');
        const clienteNome = $(this).data('nome');

        if (confirm(`Tem a certeza que deseja excluir o cliente "${clienteNome}"?`)) {
            $.ajax({
                url: window.apiBaseUrl + "/clientes/" + clienteId,
                method: 'DELETE',
                success: function () {
                    alert('Cliente excluído com sucesso!');
                    location.reload();
                },
                error: function () {
                    alert('Erro ao excluir cliente.');
                }
            });
        }
    });
    function aplicarMascaraDocumento() {
        var tipo = $("#TipoPessoa").val();
        var $doc = $("#Documento");

        if ($doc.length === 0) return;

        $doc.unmask();

        if (tipo === "F") {
            $doc.mask("000.000.000-00", { reverse: true });
        } else if (tipo === "J") {
            $doc.mask("00.000.000/0000-00", { reverse: true });
        }
    }

    aplicarMascaraDocumento();

    $("#TipoPessoa").change(function () {
        $("#Documento").val("");
        aplicarMascaraDocumento();
    });

    //// Delete Cliente
    //$("#form-delete-cliente").submit(function (e) {
    //    e.preventDefault();
    //    let clienteId = $("#CodigoCliente").val();

    //    $.ajax({
    //        url: window.apiBaseUrl + "/clientes" + clienteId,
    //        method: "DELETE",
    //        success: function () {
    //            alert("Cliente excluído!");
    //            window.location.href = "/Clientes/Index";
    //        },
    //        error: function () {
    //            alert("Erro ao excluir cliente.");
    //        }
    //    });
    //});
});
