# Unity Project: Survival Adventure - Documentation - `PlayerController`

![`PlayerController` component inspector preview](./Images/player-controller-inspector.jpg)

This component binds the player actions to the referenced `InputActionAsset`, and these actions come from [character action components](../Actions/README.md).

## Settings

- **Controls**: The `InputActionAsset` to use for the player. It must contain the actions described in [Inputs](../../Inputs/README.md) docs
- **Movement**: The [`DirectionalMovement`](../Actions/Movements/directional-movement.md) action component to use for moving the player

## Behavior

The `Player Controller` binds the actions in the `Awake()` message method.

The *Player* action map from the referenced `InputActionAsset` is enabled or disabled respectively in `OnEnable()` and `OnDisable()` message methods. So you can hide the player in the scene by deactivating its `GameObject` safely.

The player movement is applied in the `Update()` message method, by calling the `Move()` method on the reference `DirectionMovement` component.