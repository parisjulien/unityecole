# Unity Project: Survival Adventure - Documentation - `DirectionMovement`

This is the base class for all *directional* movement action component.

A *directional* movement component expects a direction in order to move, and should be updated manually.

## Create your own directional movement action component

In order to create your own direction movement action component, you can create a new class that inherit from `DirectionMovement`. Then, override the `Move()` method to define your custom behavior.

### Example

Here is an example of a custom directional movement action component that makes an object move by directly changing its transform position:

```cs
using UnityEngine;
using Final;

public class DirectionalMovementExample : DirectionalMovement
{
    public float speed = 6f;

    public override bool Move(Vector3 _Direction, float _DeltaTime)
    {
        _Direction.Normalize();
        transform.position += _Direction * speed * _DeltaTime;
    }
}
```

## API

### `Move()`

```cs
public abstract bool Move(Vector3 _Direction, float _DeltaTime)
```

Makes the object move in the given direction, by changing its transform position.

* `Vector3 _Direction`: The direction you want the object to move.
* `float _DeltaTime`: The elapsed time since the last frame.

Returns `true` if the object has moved successfully, otherwise `false`.