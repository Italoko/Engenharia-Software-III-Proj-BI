carregaFrete = {
    init: () => {
        carregaFrete.obterFrete();
    },
    obterFrete: () => {
        HTTPClient.get("/Carrinho/ObterFrete?valor=132")
            .then(result => {
                return result.json();
            })
            .then(dados => {
                carregaFrete.exibirFrete(dados);
            })
            .catch(() => {
                alert("Não foi possível recuperar o frete.");
            })
    },
    exibirFrete: (dados) => {
        let bodyResultado = document.getElementById("carregaFrete");

        let linhas = `<div class="col text-right">R$${dados}</div>`;

        bodyResultado.innerHTML = linhas;
    }
}

document.addEventListener("DOMContentLoaded", () => {

    carregaFrete.init();

});