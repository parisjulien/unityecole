# Unity Project: Survival Adventure - Documentation - Character Actions

Character actions are divided in very small components, making them easy to use, override and maintain.

In order to use theme, even for a player or an NPC, you should create a `-Controller` script that will references these actions components and use them when needed. For example, a player controller will interact with actions using input bindings, and enemy AIs will interact with actions using a behaviour tree or an *FSM* (*Finite State Machine*).

You can find all these components by clicking on *Add Component > _GAME > Characters > Actions*.

## Actions

- [Detection](./Detection/README.md)
- [Movements](./Movements/README.md)