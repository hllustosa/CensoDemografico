# Aplicativo de Censo

O Aplicativo do Censo foi desenvolvido com base na arquitetura de microsservi�os. A aplica��o consiste de 3 microsservi�os, a saber:

 - **People**: Respons�vel pelo CRUD dos dados de cada cidad�o. Este microsservi�o utiliza-se do MongoDB para manter uma cole��o de documentos com os dados b�sicos de cada pessoa.
 - **Statistics**: Respons�vel por manter contadores com os dados estat�sticos agrupados. Este microsservi�o mant�m um conjunto de cole��es (tamb�m no MongoDB) com os dados agrupados por categorias baseadas nas caracter�sticas de cada pessoa.
 - **FamilyTree**: Respons�vel por manter as �rvores geneal�gicas de cada cidad�o. As �rvores s�o montadas e atualizadas � medida em que novas pessoas s�o cadastradas no sistema. Este microsservi�o utiliza um banco de dados de grafos (Neo4J) para permitir a consulta em diversos n�veis na �rvore geneal�gica. 
 
 Os microsservi�os se comunicam utilizando o um Event Bus baseado em RabbitMQ.

![Arquitetura](https://i.ibb.co/fDpr1Tr/arquitetura.jpg)

### Execu��o

A aplica��o est� baseda em Containers e pode ser executada com o seguinte comando (depende de um ambiente contendo git CLI, docker e docker-compose)

	git clone https://github.com/hllustosa/CensoDemografico
	cd CensoDemografico/ 
	docker-compose up

A aplica��o estar� acess�vel em http://localhost:8080/    

### Pipeline e Link para o AKS
[![Build Status](https://dev.azure.com/hermanolustosa/Census/_apis/build/status/hllustosa.CensoDemografico?branchName=master)](https://dev.azure.com/hermanolustosa/Census/_build/latest?definitionId=1&branchName=master)

A aplica��o est� integrada ao [Azure DevOps](https://dev.azure.com/hermanolustosa/Census) e possui um deploy baseado em kubernetes na AKS. [Link aqui](http://40.119.48.137/).

Um v�deo demonstrativo tamb�m est� dispon�vel [neste link](https://youtu.be/HneqbjmSPPQ).
