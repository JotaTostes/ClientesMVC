$(document).ready(function () {
    $("#form-create-telefone").submit(function (e) {
        e.preventDefault();

        let clienteId = $("#CodigoCliente").val();

        let telefone = {
            codigoCliente: clienteId,
            numeroTelefone: $("#NumeroTelefone").val(),
            codigoTipoTelefone: $("#CodigoTipoTelefone").val(),
            operadora: $("#Operadora").val(),
            ativo: $("#Ativo").is(":checked"),
            usuarioInsercao: "admin"
        };

        $.ajax({
            url: "/api/clientes/" + clienteId + "/telefones",
            method: "POST",
            data: JSON.stringify(telefone),
            contentType: "application/json",
            success: function () {
                alert("Telefone cadastrado com sucesso!");
                window.location.href = "/Telefones/Index?clienteId=" + clienteId;
            },
            error: function () {
                alert("Erro ao cadastrar telefone.");
            }
        });
    });


    $("#form-edit-telefone").submit(function (e) {
        e.preventDefault();

        let clienteId = $("#CodigoCliente").val();
        let numeroTelefone = $("#NumeroTelefone").val();

        let telefone = {
            codigoCliente: clienteId,
            numeroTelefone: numeroTelefone,
            codigoTipoTelefone: $("#CodigoTipoTelefone").val(),
            operadora: $("#Operadora").val(),
            ativo: $("#Ativo").is(":checked")
        };

        $.ajax({
            url: "/api/clientes/" + clienteId + "/telefones/" + numeroTelefone,
            method: "PUT",
            data: JSON.stringify(telefone),
            contentType: "application/json",
            success: function () {
                alert("Telefone atualizado!");
                window.location.href = "/Telefones/Index?clienteId=" + clienteId;
            },
            error: function () {
                alert("Erro ao atualizar telefone.");
            }
        });
    });

    $("#form-delete-telefone").submit(function (e) {
        e.preventDefault();

        let clienteId = $("#CodigoCliente").val();
        let numeroTelefone = $("#NumeroTelefone").val();

        $.ajax({
            url: "/api/clientes/" + clienteId + "/telefones/" + numeroTelefone,
            method: "DELETE",
            success: function () {
                alert("Telefone excluído!");
                window.location.href = "/Telefones/Index?clienteId=" + clienteId;
            },
            error: function () {
                alert("Erro ao excluir telefone.");
            }
        });
    });

    $(".btn-excluir").click(function () {
        if (!confirm("Deseja realmente excluir este telefone?")) return;

        let clienteId = $(this).data("cliente");
        let numeroTelefone = $(this).data("numero");

        $.ajax({
            url: "/api/clientes/" + clienteId + "/telefones/" + numeroTelefone,
            method: "DELETE",
            success: function () {
                $("tr[data-numero='" + numeroTelefone + "']").remove();
            },
            error: function () {
                alert("Erro ao excluir telefone.");
            }
        });
    });

    $(".btn-editar").click(function () {
        let clienteId = $(this).data("cliente");
        let numeroTelefone = $(this).data("numero");
        window.location.href = "/Telefones/Edit?clienteId=" + clienteId + "&numeroTelefone=" + numeroTelefone;
    });
});
