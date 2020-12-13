# Unity Project: Survival Adventure

This project has been made for educational purposes. Feel free to clone it, use and modify the existing scripts.

It's developed using *Unity 2019.4.11f1*, and should work fine with all *2019.4.x* versions.

## Project purposes and instructions

### Instructions

As an exercise, the instructions of this project are simple: create a survival adventure game. That being said, **the game must have all the following features**:

- **Hostile entities** with simple AI patterns (basically getting closer to the player, attack, flee, and restart)
- **Friendly entities** which you can talk to, meaning you must implement a **dialog system**
- **Hunger, fatigue and health values** that can increase/decrease along time or because of player actions (and so, no health or extreme hunger or fatigue leads to losing the game)

Note that **these features can be tweaked in a more original way**. For example, you can replace *hunger* and *health* by *work* and *insanity* for a game where you have to survive to a new job in an open space office. The theme is entirely up to you!

**You are free to define your own design**:

- No need of a win condition, but you can for example give the player a way to "escape" your level and finish the game
- No need of several zones or levels, but you can for example allow the player enter into houses or caves
- No need of progression system such as experience and levels, but you can for example add one to require your players to train and become stronger before going farther in your world
- No need for the NPCs (*Non-Playable Characters*) to give you something else than just informations, but you can for example make ones that give you objects, or even quests!
- ...

**It's a game, just make it fun!**

### Teached lessons

This project shows some features of Unity such as:

- The new input system and how to use it with several devices
- Efficient components architecture
- Animators with high quality animations (from [Mixamo](https://www.mixamo.com) and blend trees
- Shaders and advanced effects (using *Shader Graph*)
- URP Lighting
- NavMesh and AI
- Events system
- UI
- ...

## Project structure

- `/_AUDIO`: Contains all audio assets of the project
- `/_GAME`: Contains all game scripts, prefabs, demo scenes, etc.
    - `/_FINAL`: Contains the game project, as it should be once finished. Note that this is my very own version, but you can of course make your own project based on this, with your own assets and mechanics!
- `/_GRAPH`: Contains all graphics assets of the project. Think of it as your assets bank. Prefabs made from this directory should be placed in `/_GAME` directory
- `/_SCENES`: Contains the main project scenes
    - `/_FINAL`: As for `/_GAME` directory, it contains the game scenes of the project once finished. Consider it as an example, feel free to create your own scenes!
- `/URP`: Contains presets and settings of the Unity's *URP* (*Universal Render Pipeline*)

## Documentation

Learn more about the final project in the documentation in `/Docs` directory.

[=> See documentation](./Docs/README.md)

## Credits

The imported graphics and audio assets are all from [**Kenney**](https://www.kenney.nl).