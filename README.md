# WorkedHourControl

Projeto desenvolvido para testar conhecimento em C#, dotnet core e um pouco de frontend Angular.

## Getting started

### Visual Studio
- Marque o WorkedHourControl.Api como projeto princial
- Dê play
- Um console e um navegador serão abertos

### Linha de Comando
- Abrir o console de sua preferência
- Executar o comando: `dotnet run --project WorkedHourControl`
- No navegador, acessar [essa url](https://localhost:5001/)

## Frontend
Frontend foi desenvolvido utilizando Angular, mas não está seguindo as melhores práticas.

A *home* do sistema possui dicas de utilização.

## Backend
A arquitetura escolhida foi a Hexagonal (Ports and Adapters).
A *application* e o *domain* estão isolados. A porta de entrada da aplicação é a *API* e a *Infra* é responsável pela comunicacão externa.

O banco de dados escolhido a princípio foi o *sqlite*, pois não possui dependências externas para funcionar.

O desenvolvimento não foi feito com base nos princípios do TDD. Os testes foram feitos apenas no final do desenvolvimento e não criam uma boa cobertura de código. Os testes desenvolvidos são apenas uma pequena demonstração.

### O que não foi feito
- Criptografica de senha;
- Logs em pontos críticos;
- Tratamento de erros eficaz;
