# Unity Project: Survival Adventure - Documentation - Characters

All scripts and assets relative to characters are in directory `Assets/_GAME/_FINAL/Characters`.

## Directory structure

- [`/Actions`](./Actions/README.md): Small components that represents character actions
- [`/Demos`](./Demos/README.md): Usage examples of player and NPC features
- [`/Player`](./Player/README.md): Components and assets relative to the player
- *AC_Character_01.controller*: The `AnimatorController` asset used on the base character
- [`CharacterAnimatorUtility`](./character-animator-utility.md): This component can be used for animated character to play animations from `UnityEvent`s
- *PF_Character_Base*: The base character prefab. Use it as parent prefab for player or NPCs (by making *Prefab Variants*)

## Graphics

The graphics assets used for characters are in directory `Assets/_GRAPH/Kenney - Characters`.

This directory contains several ones:

- `/Animations`: Animation assets picked from [Mixamo](https://www.mixamo.com)
- `/Materials`: Contains several materials for all available [Kenney's *Animated Characters*](https://www.kenney.nl/assets/animated-characters) packages' skins
- `/Models`: The common character mesh asset
- `/Textures`: Skin textures collection for the character model