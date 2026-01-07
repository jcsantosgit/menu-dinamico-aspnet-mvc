# Menu Dinâmico com ASP.NET MVC

Este projeto é um exemplo prático (PoC - Proof of Concept) criado para demonstrar a implementação de um menu dinâmico multinível utilizando a plataforma ASP.NET MVC.

> **Observação:** Este foi um projeto teste criado apenas para fins de demonstração e aprendizado sobre a criação de menus dinâmicos.

## 📋 Funcionalidades

O projeto oferece as seguintes funcionalidades principais:

*   **Renderização Dinâmica de Menu:** O menu é construído dinamicamente com base nos dados armazenados, permitindo múltiplos níveis de aninhamento (menus e submenus) de forma recursiva.
*   **Gerenciamento de Menus:**
    *   **Listagem:** Visualização de todos os itens de menu cadastrados.
    *   **Cadastro:** Adição de novos itens de menu, com a possibilidade de definir:
        *   Nome do item.
        *   Action e Controller (para roteamento).
        *   Menu Pai (para criar hierarquias).
    *   **Remoção:** Exclusão de itens de menu (com validação para proteger o menu raiz).
*   **Persistência em Memória:** Para simplificar o exemplo, os dados são armazenados em uma lista estática em memória (`MenuRepository`), simulando um banco de dados.

## 🚀 Tecnologias Utilizadas

*   **ASP.NET MVC 5:** Framework web principal.
*   **C#:** Linguagem de programação backend.
*   **Razor:** Engine de visualização.
*   **Bootstrap 4:** Framework CSS para estilização responsiva e componentes de UI (Navbar, Dropdowns).
*   **jQuery:** Biblioteca JavaScript utilizada pelos plugins do Bootstrap e validação.

## 🏗 Estrutura do Projeto

A solução está dividida em dois projetos principais:

### 1. ControleMenu.App (Camada de Aplicação)
Contém a lógica de apresentação e controle da aplicação web.
*   **Controllers:**
    *   `GerenciarMenuController`: Responsável pelas operações de CRUD dos menus.
    *   `HomeController`: Controlador padrão da página inicial.
*   **Models:**
    *   `MenuViewModel`: Responsável por transformar as entidades em modelos de visualização e construir a árvore hierárquica do menu (método `ConstruirMenu` e `EstruturarMenu`).
*   **Views:**
    *   `Shared/_Menu.cshtml` e `Shared/_Submenu.cshtml`: Partial views que implementam a renderização recursiva do menu no frontend.

### 2. ControleMenu.Service (Camada de Serviço/Dados)
Contém as entidades e a lógica de acesso a dados.
*   **Entities:**
    *   `Menu`: Classe que representa a estrutura de dados do menu (Id, Nome, Acao, Controlador, IdPai).
*   **Repository:**
    *   `MenuRepository`: Implementa as operações de acesso aos dados (Listar, Adicionar, Remover) utilizando uma lista em memória.

## ⚙️ Como Executar

1.  Abra o arquivo `ControleMenu.sln` no Visual Studio.
2.  Restaure os pacotes NuGet da solução.
3.  Defina o projeto `ControleMenu.App` como projeto de inicialização (Set as StartUp Project).
4.  Execute a aplicação (F5 ou Ctrl+F5).

A aplicação iniciará com alguns dados de exemplo pré-carregados para demonstração.
