# Robot Pilot Game

## Portugu�s do Brasil

### Objetivo do Projeto:

Estou desenvolvendo um jogo 2D simples em uma aplica��o de console C#. O objetivo � ensinar conceitos b�sicos de programa��o a uma crian�a de 11 anos, transformando um jogo de papel e caneta que criamos em um software funcional.

### Descri��o do Jogo:
    Nome: "A Miss�o do Piloto" (baseado no prot�tipo "Magical YET Week").

    Plataforma: C# Console Application.

    Mec�nica: O jogador controla um personagem (o 'R' de Rob�/Piloto) em um mapa baseado em um grid (uma grade). O mapa cont�m inimigos ('I'), uma estrela colecion�vel ('*') e uma sa�da ('EXIT').

    Condi��o de Vit�ria: O jogador deve primeiro coletar a estrela ('*') e depois chegar � sa�da.

    Condi��o de Derrota/Obst�culo: O jogador n�o pode se mover para casas ocupadas por inimigos ('I').

### Plano de Implementa��o T�cnica (C#):

    Mapa do Jogo: Ser� representado por um array de duas dimens�es (matriz), como char[,] mapa.

    Game Loop: O jogo funcionar� dentro de um loop while, que continuar� rodando enquanto o jogo n�o terminar.

    Renderiza��o: A cada itera��o do loop, a tela do console ser� limpa (Console.Clear()) e o estado atual do mapa ser� desenhado na tela.

    Controle do Jogador: A entrada do jogador ser� capturada atrav�s de Console.ReadKey() para ler as setas do teclado em tempo real.

    L�gica de Movimento e Colis�o: Ser�o utilizadas estruturas condicionais (if/else if/else) para:

    Calcular a nova posi��o do jogador com base na tecla pressionada.

    Verificar o que existe na nova posi��o do mapa (espa�o vazio, inimigo, estrela ou sa�da).

    Atualizar a posi��o do jogador ou impedir o movimento.

    Gerenciamento de Estado: Vari�veis ser�o usadas para rastrear a posi��o atual do jogador (ex: int jogadorX, int jogadorY) e o estado do jogo (ex: bool pegouEstrela).

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

## English

### Project Objective:

I am developing a simple 2D game in a C# console application. The goal is to teach basic programming concepts to an 11-year-old child by turning a paper-and-pencil game we created into functional software.

### Game Description:
    Name: "The Pilot's Mission" (based on the prototype "Magical YET Week").

    Platform: C# Console Application.

    Mechanics: The player controls a character (the 'R' for Robot/Pilot) on a grid-based map. The map contains enemies ('I'), a collectible star ('*'), and an exit ('EXIT').

    Win Condition: The player must first collect the star ('*') and then reach the exit.

    Lose Condition/Obstacle: The player cannot move into spaces occupied by enemies ('I').

### Technical Implementation Plan (C#):

    Game Map: Will be represented by a two-dimensional array (matrix), such as char[,] map.

    Game Loop: The game will run inside a while loop, which will continue as long as the game is not over.

    Rendering: On each iteration of the loop, the console screen will be cleared (Console.Clear()) and the current state of the map will be drawn on the screen.

    Player Control: Player input will be captured using Console.ReadKey() to read the arrow keys in real time.

    Movement and Collision Logic: Conditional structures (if/else if/else) will be used to:

        Calculate the player's new position based on the key pressed.

        Check what exists at the new map position (empty space, enemy, star, or exit).

        Update the player's position or prevent movement.

    State Management: Variables will be used to track the player's current position (e.g., int playerX, int playerY) and the game state (e.g., bool collectedStar).