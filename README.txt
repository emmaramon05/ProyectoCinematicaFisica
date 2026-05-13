Proyecto 1: Cinemática – Hoop Shoot

Descripción del juego

Este proyecto consiste en un juego de baloncesto basado en las mecánicas de cinemática vistas en clase.
El objetivo del jugador es calcular correctamente la trayectoria parabólica de la pelota para conseguir encestar el máximo número de veces posible antes de que termine el tiempo.

Cada canasta suma 10 puntos al marcador y la partida dura un total de 3 minutos, durante los cuales el jugador puede lanzar tantas pelotas como quiera.

El juego implementa:

Tiro parabólico mediante fórmulas cinemáticas.
Visualización de la trayectoria del proyectil.
Sistema de puntuación.
Temporizador de partida.
Varias cámaras para mejorar la experiencia de juego.


Mecánicas implementadas

Tiro parabólico
La pelota sigue una trayectoria calculada utilizando fórmulas de cinemática y físicas de proyectiles.

Predicción de trayectoria
Antes de lanzar la pelota, el jugador puede visualizar la trayectoria mediante un Line Renderer, lo que permite ajustar dirección y fuerza antes del disparo.

Sistema de puntuación
Cada canasta correcta añade 10 puntos al marcador.
El marcador se actualiza en tiempo real.
Cada vez que el jugador encesta, la velocidad de movimiento de la canasta aumenta en 0,5.
La velocidad inicial de la canasta comienza en 0.

Temporizador
La partida tiene una duración de 3 minutos.
Al finalizar el tiempo, el juego termina automáticamente.

Sistema de cámaras
El juego cuenta con 3 cámaras intercambiables para visualizar el lanzamiento desde diferentes perspectivas.


Controles

Tecla	        Función
WASD	        Controlar dirección de la pelota
Q / E	        Disminuir / aumentar fuerza
ESPACIO	        Lanzar pelota
1 / 2 / 3	Cambiar entre cámaras


Decisiones de diseño

Jugabilidad simple y arcade
Se optó por una jugabilidad sencilla y rápida centrada en la precisión del lanzamiento y el cálculo de la parábola.

Sistema de cámaras
Las diferentes cámaras permiten al jugador observar mejor la trayectoria del balón y escoger la perspectiva más cómoda.

Tiempo limitado
El límite de 3 minutos aporta dinamismo y hace que el jugador intente optimizar sus lanzamientos para conseguir la mayor puntuación posible.

Aspectos técnicos implementados
Física de proyectiles usando cinemática.
Detección de colisiones para contabilizar canastas.
Predicción de trayectoria con Line Renderer.
Gestión de cámaras.
Sistema UI para score y temporizador.

Gameplay

[PONER ENLACE AQUÍ]

Integrantes del grupo
Jose Maria Marin Morillas	
Emma Ramon Perez-Gil	
Pablo Morell Viadel

Tecnologías utilizadas
Unity
C#
Rigidbody Physics
Line Renderer