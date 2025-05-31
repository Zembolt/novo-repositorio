RELATÓRIO TÉCNICO – GIZMO NA ERA JURÁSSICA
1. Introdução
Este relatório técnico descreve os aspectos estruturais e funcionais do jogo Gizmo na Era Jurássica, um plataforma 2D voltado para crianças e adolescentes, desenvolvido para PC e dispositivos móveis. Inclui informações sobre mecânicas, física, IA, sistema de som e requisitos mínimos.
2. Estrutura do Jogo
2.1 Engine e Ferramentas Utilizadas
•	Engine: Unity (versão recomendada: 2021 ou superior)
•	Linguagem de programação: C#
•	Bibliotecas: TextMeshPro (para interface), Cinemachine (para movimentação de câmera), NavMesh (caso haja NPCs com IA), Physics2D (colisões e física)
•	Sistema de áudio: Unity Audio Mixer
2.2 Mecânica e Física
O jogo utiliza um sistema de controle de personagem baseado em física 2D, incluindo:
•	Pulo duplo: Modificado pela altura máxima e velocidade do personagem.
•	Escudo de energia: Implementado via Timer para tempo limitado de ativação.
•	Interação com objetos: Ativado por OnTriggerEnter2D em elementos como alavancas e trampolins.
2.3 Inteligência Artificial (IA)
•	Rexcroc (Inimigo/Obstáculo):
o	Algoritmo de perseguição .
o	Estados de comportamento: patrulha, perseguição e animações de reação.
o	Implementação para mudar seu comportamento conforme o progresso do jogador.
3. Interface e HUD
A UI será crucial para fornecer informações ao jogador.
•	Contador de Moedas: Um elemento de texto ancorado no canto superior esquerdo da tela, atualizado em tempo real sempre que uma moeda é coletada.
•	Barra de Energia do Escudo: Um elemento visual (barra ou círculo) posicionado de forma proeminente na tela, indicando a duração restante do escudo de energia quando ativado. A barra diminuirá gradualmente durante o uso.
•	Minimapa: Um pequeno mapa no canto da tela mostrando a posição do jogador e, crucialmente, um ícone indicando a posição de Rexcroc em relação ao jogador. A implementação do minimapa exigirá o rastreamento da posição de ambos os personagens na cena.
3.1 Controles
•	PC: Movimento com teclas WASD / pulo e duplo pulo com barra de espaço .
4. Sistema de Progressão e Salvamento
O progresso do jogador é salvo usando:
•	PlayerPrefs: Para armazenar número de moedas coletadas e cena atual.
5. Áudio e Trilha Sonora
•	Músicas: Trilhas dinâmicas que mudam dependendo do momento do jogo (exploração, perseguição).
•	Efeitos sonoros: Passos, coleta de moeda, som do escudo ativando e rugidos do Rexcroc.
•	Sistema de áudio: Unity Audio Mixer para balancear volumes dos efeitos e músicas.
•	Estilo Cartoon / Cores Vivas: A implementação exigirá assets visuais (sprites e   

•	animações) que sigam esse estilo. A escolha de paletas de cores vibrantes será essencial.
•	Animações Suaves: As animações dos personagens precisarão ser fluidas e bem interpoladas para transmitir a sensação de movimento e personalidade.
•  Músicas Animadas e Batidas Eletrônicas: A implementação envolverá a integração de trilhas sonoras e efeitos sonoros que combinem elementos orgânicos (com toques modernos (batidas eletrônicas) para criar uma atmosfera envolvente e animada. O sistema de áudio da engine será utilizado para reproduzir e gerenciar os sons.
6. Conclusão
Gizmo na Era Jurássica é um jogo leve e divertido, voltado para o público infantojuvenil. Seu sistema de mecânicas simples, animações fluidas e IA interativa garantem uma experiência dinâmica, tornando-o um jogo de plataforma cativante. A implementação técnica permite uma jogabilidade fluida e responsiva em diferentes dispositivos, garantindo desempenho otimizado e interface intuitiva.


