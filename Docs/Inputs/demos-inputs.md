# Unity Project: Survival Adventure - Documentation - `Demo_Inputs` component

![`Demo_Inputs` component inspector preview](./Images/demos-inputs-inspector.jpg)

## Usage

This component binds actions on the referenced `InputActionAsset`. The configured actions must be *Move* (`Vector2`) and *Fire* (button).

You can create an `InputActionAsset` by clicking on *Assets > Create > Input Action*. Double-click on the asset to edit it. See the [official *Input System* documentation](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/) to learn how to configure it.

When running *Play Mode*, the `GameObject` with this component will move along X and Z axes when using the *Move* action, and simply log "Fire!" in the console when using the *Fire* action.

### Actions Bindings

The actions bindings are made in the `Awake()` message method of the script.

When *Move* action is performed or cancelled, a cache variable `m_MovementDirection` is updated. Then, in the `Update()` message method, the object is moved by changing its transform position.

When *Fire* action is performed, the `Fire()` method is called directly.

### Public API

#### `Move()`

```cs
public void Move(Vector2 _Direction, float _DeltaTime)
```

Makes the object move in the given direction.

* `Vector2 _Direction`: The direction you want the object to move.
* `float _DeltaTime`: The elapsed time since the last frame.

#### `Fire()`

```cs
public void Fire()
```

Make the entity fire.

In the case of this demo, it just logs "Fire!" in the console.