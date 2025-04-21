
function consultarCEP(cepInput) {
    console.log(cepInput)
    const cep = cepInput.value.replace(/\D/g, '');

    // Verifica se o CEP possui o tamanho correto
    if (cep.length !== 8) {
        exibirMensagem("CEP inválido. Informe os 8 dígitos do CEP.", cepInput);
        return;
    }

    // Mostra indicador de carregamento
    //exibirMensagem("Consultando CEP...", cepInput);

    // Faz a consulta na API do ViaCEP usando fetch
    //fetch(`https://viacep.com.br/ws/${cep}/json/`)
    //    .then(response => {
    //        if (!response.ok) {
    //            throw new Error('Falha na consulta do CEP');
    //        }
    //        return response.json();
    //    })
    //    .then(data => {
    //        if (data.erro) {
    //            exibirMensagem("CEP não encontrado.", cepInput);
    //            return;
    //        }

    //        //// Preenche os campos com os dados retornados
    //        //logradouroInput.value = data.logradouro;
    //        //bairroInput.value = data.bairro;
    //        //cidadeInput.value = data.localidade;
    //        //ufInput.value = data.uf;
    //        //complementoInput.value = data.complemento || '';

    //        //// Foca no campo de número após preencher os dados
    //        //numeroInput.focus();

    //        // Remove mensagem de carregamento
    //        removerMensagem(cepInput);

    //        return data;
    //    })
    //    .catch(error => {
    //        exibirMensagem("Erro ao consultar o CEP. Por favor, tente novamente.", cepInput);
    //        console.error("Erro na requisição:", error);
    //    });

    return fetch(`https://viacep.com.br/ws/${cep}/json/`)
        .then(response => {
            if (!response.ok) throw new Error('CEP não encontrado');
            return response.json();
        });
}


// Função para exibir mensagens ao usuário
function exibirMensagem(texto, zipCodeElement) {
    const parentElement = zipCodeElement.parentElement;
    const spanElement = parentElement.querySelector("span");
    spanElement.textCont = texto;
}

// Função para remover mensagens
function removerMensagem(zipCodeElement) {
    const parentElement = zipCodeElement.parentElement;
    const spanElement = parentElement.querySelector("span");
    spanElement.textCont = "";
}