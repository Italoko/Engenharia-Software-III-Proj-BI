let indexProduto = {

    produtoId: 0,

    /*init: () => {
        document.getElementById("selCategoria").innerHTML = "<option>carregando...</option>";
       document.getElementById("lblImagem").innerHTML = "Selecione uma imagem";
        document.getElementById("iCarregandoCategoria").classList.remove("d-none");
        indexProduto.obterCategorias();
    },*/

    enviar: () => {

        let dados = {
            id: indexProduto.produtoId,
            nome: document.getElementById("produto").value,
            categoriaId: 1,//document.getElementById("selCategoria").value,
            quantidade: document.getElementById("quantidade").value,
            valor: document.getElementById("valor").value
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
            HTTPClient.post("/Control/ProdutoControl/Gravar", dados)
                .then(result => {
                    return result.json();
                })
                .then(dados => {
                    if (dados.sucesso) {
                        indexProduto.produtoId = dados.produtoId;
                    }
                    alert(dados.msg);
                })
                .catch(() => {
                    console.log("Deu erro no Produto/Gravar");
                });
        }
    },

    /*obterCategorias: () => {

        HTTPClient.get("Control/ProdutoControl/ObterCategorias")
            .then(result => {
                return result.json();
            })
            .then(dados => {
                indexProduto.preencherCategorias(dados);
            })
            .catch(() => {
                alert("Não foi possível obter as categorias.");
            })
    },

    preencherCategorias: (dados) => {
        let selCategoria = document.getElementById("selCategoria");
        let opts = `<option></option>`;

        for (let i = 0; i < dados.categorias.length; i++)
        { opts += `<option value="${dados.categorias[i].id}">${dados.categorias[i].nome}</option>`; }

        selCategoria.innerHTML = opts;
        document.getElementById("iCarregandoCategoria").classList.add("d-none");
    }*/
}
/*
document.addEventListener("DOMContentLoaded", () => {
    indexProduto.init();
});*/