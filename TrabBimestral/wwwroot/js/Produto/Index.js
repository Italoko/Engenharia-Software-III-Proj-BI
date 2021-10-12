let indexProduto = {

    produtoId: 0,

    enviar: () => {
        if (location.href.toLowerCase() == "http://localhost:64184/Produto/Index".toLowerCase())
            let fornecedor = document.getElementById("fornecedor").value;
       
        let dados = {
            id: indexProduto.produtoId,
            nome: document.getElementById("produto").value,
            categoriaId: 1,//document.getElementById("selCategoria").value,
            quantidade: document.getElementById("quantidade").value,
            valor: document.getElementById("valor").value,
            fornecedor: fornecedor  
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
        else if(dados.fornecedor == "")
            alert("fornecedor é obrigatório");
        else {
            HTTPClient.post("Produto/Gravar", dados)
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