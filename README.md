# Encurtador de Download

## Introdução

O encurtador de Downloads é um Software criado no intuito de facilitar a interação com pacotes e suas dependências para usuários de Linux. Ele comporta formato .deb, e futuramente terá compatibilidade com tantos outros formatos de pacotes.

## Sobre o programa

O programa consiste numa janela principal onde se localizam as principais ações com os pacotes (Instalar, desinstalar, achar packages no sistema, reparos, etc...). Certos botões direcionarão o usuário para uma janela de resolução específica, e outras poderão ser resolvidas por ali mesmo.

## Como usar:

### Instalando programas:

O usuário terá um botão chamado Selecionar. Esse botão é o que permitirá que o usuário encontre seu pacote que deseja baixar, e então poderá fazer inúmeras coisas a seguir:

1. O usuário poderá instalar o programa em sua máquina.
2. Poderá procurar por outro pacote do mesmo em seu computador.


### Desinstalando programas:

Caso o usuário pretenda desinstalar algum programa de seu computador, ele irá selecionar o arquivo de download do pacote que ele deseja deletar na aba Selecionar, e irá clicar em Localizar Pacotes. Então aparecerá uma janelinha de notificação informando o nome do pacote. Copie o nome do pacote, e clique em Deletar programa. Então aparecerá uma janela de aviso sobre a exclusão do pacote, e nessa janela haverá um campo de texto onde deve ser colocado o nome do pacote que foi copiado anteriormente. Após isso, terá duas opções de deletar: Apenas pacotes, ou deletar todos os arquivos do pacote. Se clicar no primeiro botão da esquerda para direita, você irá apenas deletar o pacote desejado. Caso queira uma limpeza mais profunda, o segundo botão é a melhor opção. Pois ele deletará o pacote desejado, e alguns resquícios que ele deixa para trás.

- NOTA: Nem todos os resquícios são deletados, apenas os arquivos config criados pelo computador para o programa.


## Sistema de reparação de pacotes:

### Verificar se há dependências quebradas:

Caso queira verificar se há problema em um dos pacotes, poderá clicar em Reparar Pacote, e então será direcionado para uma segunda janela com várias opções. Caso queira corrigir as dependências de qualquer pacote no sistema, clique em "Corrigir Dependências". Caso queira finalizar o download de um programa que começou a baixar mas encerrou o download na metade, clique em "Finalizar Instalação de Pacotes". Caso queira achar algum pacote com problema, clique em "Ver Pacote(s) Quebrado(s)"


### Reparando pacote com download interrompido:

Se um pacote estava sendo instalado e foi interrompido na metade do processo, então execute "Finalizar Instalação de Pacotes". Em seguida, será executado um comando para poder retomar o download de seu pacote.


### Procurando por pacotes quebrados:

Caso queira ver se há algum pacote quebrado em seu sistema, pressione "Ver Pacotes(s) Quebrado(s)", e então aparecerá uma janela de notificação que irá avisar o usuário sobre algum pacote estar quebrado, ou se o sistema está ok.


### Procurando por atualizações:

Para ver se algum pacote precisa de atualizações, clique no botão "Verificar Atualizações" e ele lhe dará uma janela de notificação avisando se há ou não atualização a ser feita.


### Atualizando lista de pacotes:

Caso queira atualizar a lista de pacotes de seu sistema, clique em "Atualizar lista" e então será executado um código que irá atualizar a lista de pacotes em seu sistema.


### Atualizando tudo:

Se quiser atualizar todos os pacotes da sua máquina para as versões mais recentes nos repositórios configurados.


### Reinstalando Pacotes específicos:

Caso queira reinstalar um pacote no seu sistema, o usuário poderá escolher o arquivo no botão "Selecionar Arquivo", e então será aberto um Explorador de Arquivos. Após escolher o arquivo que corresponda a seu pacote, aperte em "Reinstalar pacote" e então ele executará um código que irá reinstalar seu pacote. Ao terminar, mostrará uma janela de notificação avisando se o progresso deu certo ou se houve algum problema.