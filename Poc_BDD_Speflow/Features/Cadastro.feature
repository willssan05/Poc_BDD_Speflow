# language: pt-br

Funcionalidade: Cadastro no Google
	A fim de utilizar os serviços do Google, eu realizo o cadastro de um novo usuário

Cenário: Realizar início de cadastro com sucesso
    Dado que eu acesse a página de cadastro do Google
    Quando preencho os dados para criar um usuário novo
      | Informações      | Valores           |
      | Nome             | Wilson            |
      | Sobrenome        | Barboza           |
      | Email            | wilsonbarboza2020 |
      | Senha            | Teste@123         |
      | Confirmar        | Teste@123         |
      E prossigo para tela seguinte
Então é apresentada tela para informar o número de celular

