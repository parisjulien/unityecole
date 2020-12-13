# Unity Project: Survival Adventure - Documentation - `TargetMovement`

This is the base class for all *target* movement action component.

A *target* movement component expects a target position to reach, and should update automatically.

## Create your own target movement action component

In order to create your own target movement action component, you can create a new class that inherit from `TargetMovement`. Then, override the `MoveTo()` methods to define your custom behavior.

### Example

Here is an example of a custom target movement action component that makes an object follow a target by changing its transform position:

```cs
using UnityEngine;
using Final;

public class TargetMovementExample : TargetMovement
{
    public Transform followedObject = null;
    public float speed = 6f;
    private Vector3 targetPosition = Vector3.zero;

    private void Update()
    {
        MoveTo(followedObject);

        Vector3 toTarget = targetPosition - transform.position;
        toTarget.Normalize();
        transform.position += toTarget * speed * Time.deltaTime;
    }

    public override bool MoveTo(Vector3 _Target)
    {
        targetPosition = _Target;
        return true;
    }

    public override bool MoveTo(Transform _Target)
    {
        return MoveTo(_Target.position);
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