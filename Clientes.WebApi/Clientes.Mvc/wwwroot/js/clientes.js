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
            usuarioInsercao: "admin"
        };

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
            cidade: $("#Cidade").val(),
            uf: $("#UF").val(),
            cep: $("#CEP").val()
        };

        $.ajax({
            url: window.apiBaseUrl + "/clientes" + clienteId,
            method: "PUT",
            data: JSON.stringify(cliente),
            contentType: "application/json",
            success: function () {
                alert("Cliente atualizado com sucesso!");
                window.location.href = "/Clientes/Index";
            },
            error: function () {
                alert("Erro ao atualizar cliente.");
            }
        });
    });

    // Delete Cliente
    $("#form-delete-cliente").submit(function (e) {
        e.preventDefault();
        let clienteId = $("#CodigoCliente").val();

        $.ajax({
            url: window.apiBaseUrl + "/clientes" + clienteId,
            method: "DELETE",
            success: function () {
                alert("Cliente excluído!");
                window.location.href = "/Clientes/Index";
            },
            error: function () {
                alert("Erro ao excluir cliente.");
            }
        });
    });
});
