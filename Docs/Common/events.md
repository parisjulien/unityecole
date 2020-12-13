# Unity Project: Survival Adventure - Documentation - Events

You can find a bundle of typed `UnityEvent` implementations in the directory `/Assets/_GAME/_FINAL/Common/Events`. These scripts are mostly use to allow components to trigger feedbacks at the appropriate time.

## Usage example

Here is an example of how to use the `Vector3` event implementation:

```cs
using UnityEngine;
using Final;

public class Vector3EventExample : MonoBehaviour
{
    public Vector3Event onRotate;

    public void RotateToward(Vector3 _Direction)
    {
        if (_Direction != Vector3.zero)
        {
            _Direction.Normalize();
            transform.forward = _Direction;
            onRotate.Invoke(_Direction);
        }
    }
}
```

This component will look like this in the inspector:

![`Vector3EventExample` component inspector preview](./Images/vector3-event-example.jpg)

Click on the *+* button in order to add callbacks to the `onRotate` event. This way, you can create a script that will do something each time the object rotates using the `OnRotate()` method!

## How to create custom typed `UnityEvent`

As an example, here is the implementation of `Vector3Event`:

```cs
using UnityEngine;
using UnityEngine.Events;

namespace Final
{

	[System.Serializable]
	public class Vector3Event : UnityEvent<Vector3> { }

}
```

You can create any `UnityEvent` implementation you want by inheriting `UnityEngine.Events.UnityEvent<T0>`.

As you can notice, we added `[System.Serializable]` attribute on the class. This makes the class serializable for Unity, so it's able to draw the appropriate `UnityEvent` field in the inspector.

## Event implementations

- `Vector3Event`