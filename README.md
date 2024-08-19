# API de Notas Fiscais

Esta API foi desenvolvida com o objetivo principal de permitir que uma aplicação frontend consuma informações referentes a notas fiscais. Além disso, todas as operações de CRUD (Criar, Ler, Atualizar e Excluir) são suportadas.

Atualmente, a API fornece funcionalidades de CRUD para:

- **Notas Fiscais**
- **Status das Notas Fiscais**

## Autenticação

Este é um projeto fictício, por isso, não há necessidade de autenticação para acessar a API.

## Pré-requisitos

Certifique-se de ter os seguintes recursos instalados em sua máquina:

- **Docker**
- **.NET 8 SDK**

Não é necessário instalar um servidor de banco de dados, pois o Docker cuidará disso para você.

## Configuração e Execução

### 1. Subir a Aplicação

Execute o seguinte comando para criar e iniciar os containers da aplicação, na pasta que se encontra o arquivo docker-compose.yml :

```bash
docker-compose up

```

### 2. Banco de Dados

O banco de dados será criado automaticamente. Para facilitar o processo, um script de popular o banco de dados com alguns registros será anexado.

### 3. Criação e edição de uma nota fiscal

Estrutura de Dados da Nota Fiscal

Aqui está o formato necessário para criar uma nota fiscal, através do swagger ou postman:

```bash
{
  "nomePagador": "string",
  "numeroIdentificacao": "string", // O número deve estar entre 1 e 999999
  "dataEmissao": "2024-08-19T23:18:10.996Z",
  "dataVencimento": "2024-08-19T23:18:10.996Z",
  "dataCobranca": "2024-08-19T23:18:10.996Z", // Opcional
  "dataPagamento": "2024-08-19T23:18:10.996Z", // Opcional
  "valor": 0,
  "documentoNotaFiscal": "string",
  "documentoBoletoBancario": "string",
  "idStatusNotaFiscal": 0
}
```

### 4. Atualização de Nota Fiscal
Para atualizar uma nota fiscal, o formato é o mesmo, porém com a inclusão do ID no corpo da requisição:

```
{
  "id": 0, // Inclua o ID da nota fiscal a ser atualizada
  "nomePagador": "string",
  "numeroIdentificacao": "string", // O número deve estar entre 1 e 999999
  "dataEmissao": "2024-08-19T23:18:10.996Z",
  "dataVencimento": "2024-08-19T23:18:10.996Z",
  "dataCobranca": "2024-08-19T23:18:10.996Z", // Opcional
  "dataPagamento": "2024-08-19T23:18:10.996Z", // Opcional
  "valor": 0,
  "documentoNotaFiscal": "string",
  "documentoBoletoBancario": "string",
  "idStatusNotaFiscal": 0
}
```

### 5. Considerações Finais
A utilização desta API é bastante intuitiva, e as operações seguem os padrões esperados para manipulação de dados. Em caso de dúvidas, verifique a documentação ou entre em contato.

