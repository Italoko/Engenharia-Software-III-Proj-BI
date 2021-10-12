let listagemProduto = {
    obterProdutos: () => {
        HTTPClient.get("/Produto/ObterProdutos")
            .then(result => {
                return result.json();
            })
            .then(dados => {
                listagemProduto.carregarProdutos(dados);
            })
            .catch(() => {
                alert("Não foi possível obter os produtos.");
            })
    },
    carregarProdutos: (dados) => {
        lines = ``;
        btns = `<td class="icones-centro">
                        <button class="btn btn-primary" data-toggle="modal" data-target="#modalEditar"><i class="fa fa-pencil" aria-hidden="true"></i></button>
                        <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#modalExcluir"><i class="fa fa-trash-o" aria-hidden="true"></i></button>
                </td>`;

        if (dados.produtos.length == 0)
            lines = "<h2>Não ha produtos para listar... </h2>";
        else {
            for (let i = 0; i < dados.produtos.length; i++) {
                lines += `
                    <td>${dados.produtos[i].id}</td>
                    <td>${dados.produtos[i].nome}</td>
                    <td>${dados.produtos[i].quantidade}</td>
                    <td>R$ ${dados.produtos[i].precoVenda}</td>
                    ${btns}
                    </tr>`;
            }
        }
        document.getElementById("tBodylistagem").innerHTML = lines;
    },
    enviar: () => {
        let dados = {
            //id: document.getElementById("listagem").children getElementById("id").value,
            nome: document.getElementById("produto").value,
            categoriaId: 1,
            quantidade: document.getElementById("quantidade").value,
            valor: document.getElementById("valor").value,
        }

        if (dados.nome == "")
            alert("Nome é obrigatório");
        else if (dados.categoriaId == "")
            alert("Categoria é obrigatório");
        else if (dados.quantidade == "")
            alert("Quantidade é obrigatório");
        else if (dados.quantidade < 0)
            alert("Quantidade não pode ser negativo");
        else if (dados.valor == "")
            alert("Valor é obrigatório");
        else if (dados.valor < 0)
            alert("Valor não pode ser negativo");
        else {
                HTTPClient.post("Produto/Gravar", dados)
                    .then(result => {
                        return result.json();
                    })
                    .then(dados => {
                        alert(dados.msg);
                    })
                    .catch(() => {
                        console.log("Deu erro no Produto/Gravar");
                    });
             }
    }
}

document.addEventListener("DOMContentLoaded", () => {
    listagemProduto.obterProdutos();
});