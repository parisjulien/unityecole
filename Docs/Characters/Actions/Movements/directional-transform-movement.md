# Unity Project: Survival Adventure - Documentation - `DirectionTransformMovement`

Makes an object move in a direction by changing its transform position.

![`Directional Transform Movement` component inspector preview](./Images/directional-transform-movement-inspector.jpg)

## Settings

- **Speed**: Defines the movement speed of the object (in units/s).
- **Look In Movement Direction**: If `true`, makes the object rotate toward its movement direction.

### Events

You can attach callbacks to the following events:

- `OnBeginMove`: Called when the object starts moving.
- `OnUpdateMove`: Called each time `Move()` is called with a non-zero direction vector. Emits the movement direction as parameter.
- `OnEndMove`: Called when the object stops moving.

## API

### `Move()`

```cs
public override bool Move(Vector3 _Direction, float _DeltaTime)
```

Makes the object move in the given direction, by changing its transform position. Note that if **Look In Movement Direction** option is set to `true`, the object will also rotate toward the given direction.

You should call this method even if the given direction is 0, in order to trigger the events as expected.

* `Vector3 _Direction`: The direction you want the object to move.
* `float _DeltaTime`: The elapsed time since the last frame.

Returns `true` if the object has moved successfully, otherwise `false`.