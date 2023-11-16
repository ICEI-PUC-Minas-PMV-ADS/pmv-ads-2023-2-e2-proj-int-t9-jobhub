# Programação de Funcionalidades

Nesta seção são apresentadas as telas desenvolvidas para cada uma das funcionalidades
do sistema. O respectivo endereço (URL) e outras orientações de acesso são são
apresentadas na sequência.

## 1. HOMEPAGE (RF-04)
![Homepage](img/Homepage2.png)
Nesta sesssão, o usuario, assim que abrir verá a lista de vagas disponiveis no momento.
|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-004| O site deve apresentar uma lista de vagas na página principal | HomeController.cs / Index.cs.html / Vaga.cs | 


## 2. CRIAR VAGA (RF-06)
![Homepage](img/Criarvaga2.png)
Nesta sessão, a empresa poderá criar a vaga.
|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-006| O usuário empregador deve poder criar vagas| VagaController.cs / Vaga.cs / Categoria.cs / CreateVaga.cshtml | 

## 3. EXCLUIR VAGA (RF-07)
![Homepage](img/Listadevagas2.png)
Nesta sessão, a empresa verá as vagas criadas e poderá excluí-las.
|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-007| O usuário empregador deve poder excluir vagas | VagaController.cs / VagaRepository.cs / CategoriaRepository.cs / List.cshtml | 

## 4. EDITAR VAGA (RF-08)
![Homepage](img/Editarvaga.png)
Nesta sessão, a empresa poderá editar a vaga já criada.
|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-008| O usuário empregador deve poder editar vagas | VagaController.cs / VagaRepository.cs / CategoriaRepository.cs / Edit.cshtml | 

## 5. CADASTRO E LOGIN DO USUÁRIO (RF-01)
![Homepage](img/LoginFuncionalidade.png)
Nesta sessão, o usuário poderá realizar seu login ao preencher os requisitos.
|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-001| O site deve conter um sistema de cadastro e login do usuário | UsuariosController.cs / Usuario.cs / Login.cshtml / Create.cshtml | 

## Requisitos em Desenvolvimento
|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-002| O usuário deve conseguir personalizar seu perfil    | Em desenvolvimento |
|RF-003| O usuário deve conseguir aplicar seu currículo em vagas disponíveis | Em desenvolvimento | 
|RF-005| O usuário deve ter opções de filtro para a pesquisa de vagas | Em desenvolvimento| 
|RF-009| O usuário empregador poderá visualizar currículos cadastrados a sua vaga | Em desenvolvimento | 
|RF-010| O site deve conter um sistema de cadastro e login do usuário empregador   | Em desenvolvimento |
|RF-011| O usuário empregador deve conseguir personalizar o perfil da empresa | Em desenvolvimento | 



