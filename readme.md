# Joc de plataformes Bàsic

Pixel Art Assets per Jugadors i mapa

## Nivell1

- **Jugador**
  - Animació bàsica asset
  - Moviment bàsic dreta esquerra amb tecles
  - Salt. Només salta quan està tocant el terra(versió simple)
- **Enemic**. Moviment patrulla bàsic dreta esquerra. Gira quan toca Tilemap (detecta col.isió)
- **FaceRock**. Moviment patrulla bàsic amunt i avall entre 2 punts "a piñón"
- **Comentaris explicatius**
- **Codi ben estructurat**, ben indentat i fàcil de llegir
- **Recol.lecció de fruites**
    - Tenen diferents valors (apple 5pt, síndria 1pt)
    - La poma dóna inmunitat
        - canvi de color
        - canvi de mida
        - no mor quan li cau una bomba

- **Canvis d'escena**
   - Associat a botó escena inicial
   - Associat al punt de canvi de nivell en detectar col.lisió

- **Música de fons** (nivell1)
- **Fonts** diferents pels botons i misstges (DaFont.com)
- **Tags vs Name** per detectar l'objecte col.lisionat
- **Cauen bombes aleatòriament**
    - Empty object **Crear bomes**
    - Maten el Player si no és inmune. Desapareixen quan toquen el Tilemap


## Nivell2
- **Mapa més gran**
- **La càmera segueix el protagonista**
- **Spawpoint**. Quan mor però li queden vides torna al principi
- **Pou**. Si el player cau del mapa mor. Detecta col.lisió amb empty object


# To Do
- Fons nivell 2
- Efectes sonors
- Posar pantall Game Over
    - Tancar joc
    - Recomançar
- Efecte desaparèixer fruites
- Intercanvi animacions Player. Idle-Running-Jump????