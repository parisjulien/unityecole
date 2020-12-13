# Unity Project: Survival Adventure - Documentation - Character Movements

Movement action components are divided in two categories:

- *Directional* movement: Expect a direction, and are updated manually
- *Target* movement: Expect a target, and can be updated manually or automatically (e.g. using a *NavMesh*)

## Classes

- [`Directional Movement`](./directional-movement.md): Base class for all directional movement action components
- [`Directional Transform Movement`](./directional-transform-movement.md): Moves an entity toward a direction by changing its transform position
- [`Movement`](./movement.md): Base class for all movement action components
- [`Target Movement`](./target-movement.md): Base class for all target movement action components